using System;
using GamePlay;
using UnityEngine;

namespace Ui
{
    public class MainMenuController : MonoBehaviour
    {
        private MainMenuModel _mainMenuModel;

        private MainMenuView _mainMenuView;
        
        public static MainMenuController Instance { get; private set; }
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

            _mainMenuModel = GetComponent<MainMenuModel>();
            _mainMenuView = GetComponent<MainMenuView>();
        }
        
        private void Start()
        {
            _mainMenuView.CreatePanel(_mainMenuModel.GetData(Capture.One).Count,
                _mainMenuModel.GetData(Capture.Two).Count);
        }

        public void OpenView()
        {
            _mainMenuView.OpenView();
        }

        public void OnClickLevel(Capture capture,int index)
        {
            _mainMenuView.GoToGameScene();
            GamePlayController.Instance.InvokeStartGame(_mainMenuModel.GetData(capture)[index]);
        }
    }
}