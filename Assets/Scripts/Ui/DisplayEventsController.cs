using System;
using GamePlay;
using UnityEngine;

namespace Ui
{
    public class DisplayEventsController : MonoBehaviour
    {
        private DisplayEventsView _displayEventsView;
        
        public static DisplayEventsController Instance { get; private set; }

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
            
            _displayEventsView= GetComponent<DisplayEventsView>();
        }

        private void Start()
        {
            GamePlayController.Instance.addNewEvent.AddListener(OnAddNewEvent);
        }

        private void OnAddNewEvent(string type,int maxCount) =>
            _displayEventsView.AddNewEvent(type,maxCount);

        public void RemoveEvent(int index) =>
            GamePlayController.Instance.RemoveEvent(index);
        
        public void ResetAll()
            => _displayEventsView.ResetAll();
    }
}
