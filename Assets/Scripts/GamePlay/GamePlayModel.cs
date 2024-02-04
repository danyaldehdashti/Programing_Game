using System;
using System.Collections.Generic;
using Models;
using UnityEngine;
using EventType = Models.EventType;

namespace GamePlay
{
    public class GamePlayModel : MonoBehaviour, IGamePlayModel
    {
        
        private LevelModel _levelModel;

        private List<EventType> _inEventFromUser = new List<EventType>();

        public void SetData(LevelModel levelModel) => 
            _levelModel = levelModel;

        public void AddNewEvent(EventType eventType) =>
            _inEventFromUser.Add(eventType);
            
        
        public bool CheckWin()
        {
            var data = _levelModel.GetAllEventsRoadMap();
            if (data.Count != _inEventFromUser.Count) return false;
            
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i] != _inEventFromUser[i])
                    return false;
            }
            return true;
        } 
        
        public void RemoveEvent(int index) =>
            _inEventFromUser.RemoveAt(index);

        public void ResetAll() =>
            _inEventFromUser = new List<EventType>();

        public LevelModel GetLevelModel() =>
            _levelModel;
        

        public int GetMaxEventsCount() => _levelModel.GetAllEventsRoadMap().Count;

    }

    public interface IGamePlayModel
    {
        void SetData(LevelModel levelModel);
        void AddNewEvent(EventType eventType);
        bool CheckWin();
        void RemoveEvent(int index);
        void ResetAll();
        LevelModel GetLevelModel();
        int GetMaxEventsCount();
    }
    
}