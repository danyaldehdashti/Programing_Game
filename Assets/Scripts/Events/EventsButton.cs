using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using EventType = Models.EventType;

namespace Events
{
    public class EventsButton : MonoBehaviour ,IEventsButton
    {
        [SerializeField] private Button button;

        [SerializeField] private TMP_Text typeText;

        private UnityEvent<EventType> _onClick;

        private EventType _eventType;

        public void InvokeData(UnityEvent<EventType> eventsView,EventType eventType)
        {
            typeText.text = eventType.ToString();
            _eventType = eventType;
            _onClick = eventsView;
            button.onClick.AddListener(OnClick);
        }

        private void OnClick() => _onClick.Invoke(_eventType);
    }

    public interface IEventsButton
    {
        void InvokeData(UnityEvent<EventType> eventsView, EventType eventType);
    }
}