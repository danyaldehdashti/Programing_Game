using System;
using System.Collections.Generic;
using Models;
using Playground;
using UnityEngine;
using UnityEngine.Serialization;

namespace LevelEditor
{
    public class PlaygroundEditorController : MonoBehaviour,IPlaygroundEditorController
    {

        private PlaygroundEditorModel _playgroundEditorModel;

        private PlaygroundEditorView _playgroundEditorView;
        
        public static PlaygroundEditorController Instance { get; private set; }
        private void Awake() 
        {
            if (Instance != null && Instance != this) 
            { 
                Destroy(this); 
            } 
            else 
            { 
                Instance = this; 
            }

            _playgroundEditorView = GetComponent<PlaygroundEditorView>();
            _playgroundEditorModel = GetComponent<PlaygroundEditorModel>();

            _playgroundEditorView.SpawnPlayGround(_playgroundEditorModel.numberOfPiece,
                _playgroundEditorModel.piecePrefab);
        }

       

        public void InvokeNewPiece(int id) =>
            DataSetPanelController.Instance.OnChosePiece(id);
        

        public void SetExistPieceData(List<PieceModel> data) =>
            _playgroundEditorView.SetExistData(data);

        public void SetDataToPiece(int index, string type, string height) =>
            _playgroundEditorView.SetDataToPiece(index, type, height);
    }

    public interface IPlaygroundEditorController
    {
        void InvokeNewPiece(int id);
        void SetExistPieceData(List<PieceModel> data);
        void SetDataToPiece(int index, string type, string height);
    }
}
