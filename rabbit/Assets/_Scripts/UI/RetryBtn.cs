using System;
using Runtime.GamePlay.Manager;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Runtime.GamePlay.GameState
{
    public class RetryBtn: MonoBehaviour
    {
        public Button retryButton;

         private void Start()
         {
             if (retryButton != null)
             {
                 retryButton.onClick.AddListener(RetryButtonClicked);
             }
         }

        
        public void RetryButtonClicked()
        {
            // GameManager.Instance.GoToMainMenu();
            LevelManager.Instance.RestartCurrentLevel();
        }
    }
}