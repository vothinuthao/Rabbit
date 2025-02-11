using System;
using Runtime.GamePlay.Manager;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Runtime.GamePlay.GameState
{
    public class PlayAgainBtn: MonoBehaviour
    {
        public Button playAgainButton;

         private void Start()
         {
             if (playAgainButton != null)
             {
                 playAgainButton.onClick.AddListener(PlayAgainButtonClicked);
             }
         }

        public void PlayAgainButtonClicked()
        {
            GameManager.Instance.GoToMainMenu();
        }
        public void RetryButtonClicked()
        {
            LevelManager.Instance.RestartCurrentLevel();
        }
    }
}