using System.Collections.Generic;
using Models;
using UnityEngine;

namespace LevelEditor
{
    public class PlaygroundEditorView : MonoBehaviour,IPlaygroundEditorView
    {
        private List<PieceEditor> _levelPieceEditors = new List<PieceEditor>();

        public void SpawnPlayGround(int numberOfPiece,PieceEditor piecePrefab)
        {
            for (int i = 0; i < numberOfPiece; i++)
            {
                PieceEditor pieceEditor = Instantiate(piecePrefab, transform);
                pieceEditor.id = i;
                _levelPieceEditors.Add(pieceEditor);
            }
        }

        public void SetDataToPiece(int index, string type, string height)
        {
            _levelPieceEditors[index].GetData(type,height);
        }

        public void SetExistData(List<PieceModel> data)
        {
            if(data == null) return;
            
            
            foreach (var piece in _levelPieceEditors)
            {
                piece.GetData("Type", "");
            }

            if (data.Count != 0)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    PieceModel pieceModel = data[i];
                    string pieceNameType = "";
                    foreach (var typeName in pieceModel.eventTypes)
                        pieceNameType += typeName.ToString() + "    ";
                        
                    
                    _levelPieceEditors[data[i].pieceIndex].GetData(pieceNameType, pieceModel.heightCount.ToString());
                }
            }

        }
    }

    public interface IPlaygroundEditorView
    {
        void SpawnPlayGround(int numberOfPiece, PieceEditor piecePrefab);
        void SetDataToPiece(int index, string type, string height);
        void SetExistData(List<PieceModel> data);
    }
}