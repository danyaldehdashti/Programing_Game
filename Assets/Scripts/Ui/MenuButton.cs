using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class MenuButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        
        [SerializeField] private TMP_Text textId;

        private Capture _captureId;
        
        private int _id;
        
        private void Awake()
        {
            button.onClick.AddListener(OnClick);
        }

        public void GetData(int id, Capture capture)
        {
            _id = id;
            textId.text = (id + 1).ToString();
            _captureId = capture;
        } 

        private void OnClick()
        {
            MainMenuController.Instance.OnClickLevel(_captureId,_id);
        }
    }
}