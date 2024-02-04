using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using UnityEngine;
using EventType = Models.EventType;

namespace LevelEditor
{
    public class DataSetPanelModel : MonoBehaviour,IDataSetPanelModel
    {
        [SerializeField] private LevelModel levelModel;

        private void Start()
        {
            PlaygroundEditorController.Instance.SetExistPieceData(levelModel.pieceModels);
        }

       

        public List<string> GetDataSourceTypes()
        {
            return Enum.GetNames(typeof(EventType)).ToList();
        }

        public void LevelAction(ActionState actionState,PieceModel pieceModel)
        {
            switch (actionState)
            {
                case ActionState.Add:
                    levelModel.AddNewPiece(pieceModel);
                    break;
                
                case ActionState.Remove:
                    //
                    levelModel.RemovePiece(false,pieceModel.pieceIndex);
                    break;
                
                case ActionState.Reset:
                    //
                    levelModel.RemovePiece(true,pieceModel.pieceIndex);
                    break;
            }
            PlaygroundEditorController.Instance.SetExistPieceData(levelModel.pieceModels);
        }
    }

    public interface IDataSetPanelModel
    {
        List<string> GetDataSourceTypes();
        void LevelAction(ActionState actionState,PieceModel pieceModel);
    }

    public enum ActionState
    {
        Add,
        Remove,
        Reset
    }

}