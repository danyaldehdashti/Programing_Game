using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using UnityEngine;
using EventType = Models.EventType;


namespace LevelEditor
{
    public class DataSetPanelController : MonoBehaviour ,IDataSetPanelController
    {
        private DataSetPanelView _dataSetPanelView;

        private DataSetPanelModel _dataSetPanelModel;
        
        private PieceModel _pieceModel;

        private int _pieceId = 0;
        public static DataSetPanelController Instance { get; private set; }
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
            
            _dataSetPanelView = GetComponent<DataSetPanelView>();
            _dataSetPanelModel = GetComponent<DataSetPanelModel>();
        }
        
        private void OnEnable()
        {
            _dataSetPanelView.OnSetPieceType += OnSetPieceType;
        }
        
        private void OnDisable()
        {
            _dataSetPanelView.OnSetPieceType += OnSetPieceType;
        }

        private void Start()
        {
            _dataSetPanelView.SetDataToInputField(_dataSetPanelModel
                .GetDataSourceTypes());
        }

        public void OnChosePiece(int index)
        {
            _pieceModel = new PieceModel();
            _pieceModel.pieceIndex = index;
            _dataSetPanelView.OnChosePiece(index);
        }

        public void RemovePiece() =>
            _dataSetPanelModel.LevelAction(ActionState.Remove,_pieceModel);
        

        public void ResetLevel() =>
            _dataSetPanelModel.LevelAction(ActionState.Reset,_pieceModel);
        
        private void OnSetPieceType(int type1,int type2, int height)
        {
            List<EventType> eT = new List<EventType>();
            eT.Add((EventType)type1);
            if(type1 != type2)
                eT.Add((EventType)type2);

            if ((EventType)type2 == EventType.Null || (EventType)type1 == EventType.Null)
                _pieceModel.eventTypes = new List<EventType>();
            else
                _pieceModel.eventTypes = new List<EventType>(eT);
            
            
            _pieceModel.heightCount = height;
            _dataSetPanelModel.LevelAction(ActionState.Add,_pieceModel);
            
            
            string pieceNameType = "";
            foreach (var typeName in _pieceModel.eventTypes)
                pieceNameType += typeName.ToString() + "    ";
            
            PlaygroundEditorController.Instance.SetDataToPiece(_pieceModel.pieceIndex, pieceNameType,
                _pieceModel.heightCount.ToString());
        }
        
    }

    public interface IDataSetPanelController
    {
        void OnChosePiece(int index);
        void RemovePiece();
        void ResetLevel();
    }
}
