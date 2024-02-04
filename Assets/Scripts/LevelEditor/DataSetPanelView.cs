using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace LevelEditor
{
    public class DataSetPanelView : MonoBehaviour,IDataSetPanelView
    {
        
        [Header("Element")]

        [SerializeField] private Button applayButton;
        
        [SerializeField] private Button deletePieceButton;

        [SerializeField] private Button resetAllLevel;

        [SerializeField] private GameObject dataSetPanel;
        
        [SerializeField] private TMP_Text pieceIndexText;
        
        [Header("Setting")]
        
        [SerializeField] private TMP_Dropdown setPieceType1;
        
        [SerializeField] private TMP_Dropdown setPieceType2;
        
        [SerializeField] private TMP_InputField heightInputField;
        
        //For 3 Data For Events
        //Todo: Fix This
        public UnityAction<int,int,int> OnSetPieceType;


        public void SetDataToInputField(List<string> list)
        { 
            setPieceType1.AddOptions(list);
            setPieceType2.AddOptions(list);
            heightInputField.text = 1.ToString();
        }
        
        public void OnChosePiece( int index)
        {
            applayButton.onClick.AddListener(OnApply);
            deletePieceButton.onClick.AddListener(RemovePiece);
            resetAllLevel.onClick.AddListener(ResetLevel);

            dataSetPanel.SetActive(true);
            pieceIndexText.text = "Your Chose : " + index;
        }

        private void OnApply()
        {
            OnSetPieceType.Invoke(setPieceType1.value,setPieceType2.value,int.Parse(heightInputField.text));
        }

        private void OnAddExtandEvent()
        {
            
        }


        private void RemovePiece() =>
            DataSetPanelController.Instance.RemovePiece();


        private void ResetLevel() =>
            DataSetPanelController.Instance.ResetLevel();

    }

    public interface IDataSetPanelView
    {
        void SetDataToInputField(List<string> list);
        void OnChosePiece(int index);
    }
}
