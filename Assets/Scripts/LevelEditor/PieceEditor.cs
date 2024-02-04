using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LevelEditor
{
    public class PieceEditor : MonoBehaviour,IPieceEditor
    {

        [SerializeField] private TMP_Text pieceType;

        [SerializeField] private TMP_Text pieceHeight;

        [SerializeField] private Button button;

        public int id;

        private void Awake()
        {
            button.onClick.AddListener(SendData);
            
        }

        public void GetData(string type, string height)
        {
            pieceType.text = type;
            pieceHeight.text = height;
        }

        private void SendData()
        {
            PlaygroundEditorController.Instance.InvokeNewPiece(id);
        }
        
    }

    public interface IPieceEditor
    {
        void GetData(string type, string height);
    }
}
