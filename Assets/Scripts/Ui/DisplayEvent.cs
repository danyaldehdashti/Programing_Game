using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Ui
{
    public class DisplayEvent : MonoBehaviour,IDisplayEvent
    {
        [SerializeField] private TMP_Text typeDisplay;

        [SerializeField] private Button removeButton;
        
        private UnityEvent<int> _onClick;

        private int _id;

        public void GetData(int index, string type, UnityEvent<int> unityEvent)
        {
            _id = index;
            typeDisplay.text = type;
            removeButton.onClick.AddListener(RemoveEvent);
            _onClick = unityEvent;
        }

        public void SetIdAgain(int index) =>
            _id = index;
        

        private void RemoveEvent() => _onClick.Invoke(_id);
    }

    public interface IDisplayEvent
    {
        void GetData(int index, string type, UnityEvent<int> unityEvent);
        void SetIdAgain(int index);
    }
}