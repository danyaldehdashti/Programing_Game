using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Ui
{
    public class DisplayEventsView : MonoBehaviour,IDisplayEventsView
    {
        [SerializeField] private DisplayEvent displayEventPrefab;

        [SerializeField] private GameObject mainParent;
        
        [SerializeField] private GameObject functionParent;
        
        private List<DisplayEvent> _displayEvents = new List<DisplayEvent>();

        private UnityEvent<int> _onRemoveAction = new UnityEvent<int>();

        private void Start()
        {
            _onRemoveAction.AddListener(RemoveEvent);
        }

        public void AddNewEvent(string type,int maxEventCount)
        {
            if(maxEventCount <= _displayEvents.Count) return;
            
            DisplayEvent displayEvent = Instantiate(displayEventPrefab, mainParent.transform);
            
            _displayEvents.Add(displayEvent);
            
            displayEvent.GetData(_displayEvents.Count - 1, type,_onRemoveAction);
        }

        public void ResetAll()
        {
            foreach (var display in _displayEvents)
                Destroy(display.gameObject);

            _displayEvents = new List<DisplayEvent>();
        }
        

        private void RemoveEvent(int index)
        {
            DisplayEventsController.Instance.RemoveEvent(index);

            Destroy(_displayEvents[index].gameObject);
            _displayEvents.RemoveAt(index);
            
            SetNewIdToButtons();
        }

        private void SetNewIdToButtons()
        {
            if(_displayEvents.Count == 0) return;
                
            for (int i = 0; i < _displayEvents.Count; i++)
                _displayEvents[i].SetIdAgain(i);
            
        }
        
    }

    public interface IDisplayEventsView
    {
        void AddNewEvent(string type, int maxEventCount);
        void ResetAll();
    }
}