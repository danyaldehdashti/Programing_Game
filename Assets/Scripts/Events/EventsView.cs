using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using EventType = Models.EventType;

namespace Events
{
    public class EventsView : MonoBehaviour,IEventsView
    {
        [SerializeField] private EventsButton eventsButtonPrefab;

        private UnityEvent<EventType> _onClickEvent = new UnityEvent<EventType>();

        public void InitButtons(List<EventType> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                EventsButton eventsButton = Instantiate(eventsButtonPrefab, transform);
                eventsButton.InvokeData(_onClickEvent,list[i]);
            }
        }

        public UnityEvent<EventType> GetUnityEvent() => _onClickEvent;
    }

    public interface IEventsView
    {
        void InitButtons(List<EventType> list);
        UnityEvent<EventType> GetUnityEvent();
    }
}