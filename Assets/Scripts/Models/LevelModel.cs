using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace Models
{
    [CreateAssetMenu(fileName = "LevelModel",menuName = "Model/LevelModel")]
    public class LevelModel : ScriptableObject
    {
        public int CaptureNumber;
        public int LevelNumber;
        public List<PieceModel> pieceModels;
        

        public void AddNewPiece(PieceModel pM)
        {
            if (pieceModels == null) pieceModels = new List<PieceModel>();

            for (int i = 0; i < pieceModels.Count; i++)
            {
                if (pieceModels[i].pieceIndex == pM.pieceIndex)
                {
                    pieceModels[i] = pM;
                    return;
                }
            }
            pieceModels.Add(pM);
            
        }

        public void RemovePiece(bool isRemoveAll,int id)
        {
            if (isRemoveAll)
            {
                pieceModels = new List<PieceModel>();
            }
            else
            {
                var data = pieceModels.Find(x => x.pieceIndex == id);
                pieceModels.Remove(data);
            }
        }

        public List<int> GetAllIndexId()
        {
            List<int> pieceIndexList = new List<int>();

            foreach (var piece in pieceModels)
            {
                pieceIndexList.Add(piece.pieceIndex);
            }
            
            return pieceIndexList;
        }

        public List<EventType> GetAllEventsRoadMap()
        {
            List<EventType> pieceTypes = new List<EventType>();

            foreach (var piece in pieceModels)
            {
                foreach (var eT in piece.eventTypes)
                {
                    pieceTypes.Add(eT);
                }
            }
            
            return pieceTypes;
        }

        public List<EventType> GetExistEventsInThisLevel()
        {
            List<EventType> eEvents = new List<EventType>();

            List<EventType> allEvents = GetAllEventsRoadMap();

            for (int i = 0; i < allEvents.Count; i++)
            {
                if(i == 0)
                    eEvents.Add(allEvents[i]);
                else if(!eEvents.Contains(allEvents[i]))
                {
                    eEvents.Add(allEvents[i]);
                }
            }
            
            return eEvents;
        }

        public PieceModel GetPieceData(int id) =>
            pieceModels.Find(x => x.pieceIndex == id);

    }
}