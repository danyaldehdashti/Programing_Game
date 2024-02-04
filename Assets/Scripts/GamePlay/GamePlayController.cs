using System.Collections.Generic;
using Models;
using Playground;
using Ui;
using UnityEngine;
using UnityEngine.Events;
using EventType = Models.EventType;

namespace GamePlay
{
    public class GamePlayController : MonoBehaviour
    {
        private GamePlayModel _gamePlayModel;

        [HideInInspector]
        public UnityEvent<string,int> addNewEvent = new UnityEvent<string,int>();
        
        public static GamePlayController Instance { get; private set; }
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

            _gamePlayModel = GetComponent<GamePlayModel>();
        }

        public void InvokeStartGame(LevelModel levelModel)
        {
            _gamePlayModel.SetData(levelModel);
            PlaygroundController.Instance.StartCreate(levelModel);
        }

        public List<EventType> GetExistEventsInThisLevel() =>
             _gamePlayModel.GetLevelModel().GetExistEventsInThisLevel();
        
        
        public void AddNewEvent(EventType eventType)
        {
            _gamePlayModel.AddNewEvent(eventType);
            addNewEvent.Invoke(eventType.ToString(),_gamePlayModel.GetMaxEventsCount());
        }
        
        public void RemoveEvent(int index) 
        {
            _gamePlayModel.RemoveEvent(index);
        }
        

        public void ResetAll()
        {
            _gamePlayModel.ResetAll();
            DisplayEventsController.Instance.ResetAll();
        }

        public void CheckWin()
        {
            if (_gamePlayModel.CheckWin())
            {
                Debug.Log("Win");
            }
            else
            {
                Debug.Log("Lose");
            }
        }
    }
    
}
