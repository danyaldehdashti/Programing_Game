using GamePlay;
using UnityEngine;

namespace Events
{
    public class EventsController : MonoBehaviour
    {
        private EventsView _eventsView;

        public static EventsController Instance { get; private set; }
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


            _eventsView = GetComponent<EventsView>();
        }

        private void Start()
        {
            _eventsView.GetUnityEvent().AddListener(GamePlayController.Instance.AddNewEvent);
            _eventsView.InitButtons(GamePlayController.Instance.GetExistEventsInThisLevel());
        }
    }
}