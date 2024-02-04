using System;
using System.Collections.Generic;
using UnityEngine.Serialization;

namespace Models
{
    [Serializable]
    public class PieceModel
    {
        public int pieceIndex;
        
        public List<EventType> eventTypes = new List<EventType>();
        
        public int heightCount;

        public bool CheckIsConfirmEvent()
        {
            foreach (var eT in eventTypes)
            {
                if (eT == EventType.Confirm)
                    return true;
            }

            return false;
        }
    }
    
    public enum EventType
    {
        Forward,
        Jump,
        TurnRight,
        TurnLeft,
        Confirm,
        Null
    }
}