using System;
using Ui;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay
{
    public class GamePlayView : MonoBehaviour
    {
        [SerializeField] private Button checkWinButton;
        
        [SerializeField] private Button resetButton;
        
        [SerializeField] private Button backButton;


        private void Start()
        {
            checkWinButton.onClick.AddListener(GamePlayController.Instance.CheckWin);
            resetButton.onClick.AddListener(GamePlayController.Instance.ResetAll);
            backButton.onClick.AddListener(OnClickBackButton);
            
        }

        private void OnClickBackButton()
        {
            MainMenuController.Instance.OpenView();
            Destroy(gameObject);
        }
    }
}