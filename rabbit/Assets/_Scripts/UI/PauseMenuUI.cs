
using Runtime.GamePlay.Manager;
using UnityEngine;
using UnityEngine.UI;

    public class PauseMenuUI : MonoBehaviour
    {
        public GameObject pauseMenuPanel;
        public Button resumeButton;
        public Button mainMenuButton;

        void Start()
        {
            if (pauseMenuPanel != null)
            {
                pauseMenuPanel.SetActive(false);
            }

            if (resumeButton != null)
            {
                resumeButton.onClick.AddListener(OnResumeButtonClicked);
            }

            if (mainMenuButton != null)
            {
                mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
            }
        }


        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameManager.Instance.CurrentGameState == GameState.Paused) 
                {
                    ResumeGame();
                }
                else
                {
                    PauseGame();
                }
            }
        }

        private void PauseGame()
        {
            GameManager.Instance.PauseGame();
            if (pauseMenuPanel != null)
            {
                pauseMenuPanel.SetActive(true);
            }
        }

        private void ResumeGame()
        {
            GameManager.Instance.ResumeGame();
            if (pauseMenuPanel != null)
            {
                pauseMenuPanel.SetActive(false);
            }
        }

        private void OnMainMenuButtonClicked()
        {
            GameManager.Instance.GoToMainMenu();
        }
        private void OnResumeButtonClicked()
        {
            ResumeGame();
        }
    }

