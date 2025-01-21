using System.Collections;
using UnityEngine;
using TMPro;
using TMPro.Examples;
using UnityEngine.UI;

namespace Assets._Scripts.Runtime.GamePlay.GameState
{
    public class ButtonController : MonoBehaviour
    {
        public TextMeshProUGUI timerText;
        private float timeRemaining = 150f;
        public Button clickToPlay;
        public Button playAgain;
        public Image itemCollectionMisson;
        public Image carrotUI;
        public Image grapeUI;
        public Image strawberryUI;
        public Image orangeUI;
        public Image gameOver;
        public Image missonUI;
        public Image backgroundFruitUI;

        private bool _isStartGame = false;
        void Start()
        {
            carrotUI.gameObject.SetActive(false);
            strawberryUI.gameObject.SetActive(false);
            grapeUI.gameObject.SetActive(false);
            orangeUI.gameObject.SetActive(false);
            playAgain.gameObject.SetActive(false);
            gameOver.gameObject.SetActive(false);
            missonUI.gameObject.SetActive(false);
            backgroundFruitUI.gameObject.SetActive(false);
            _isStartGame = false;
        }
        void Update()
        {
            if (_isStartGame) 
                TimerCountdown();
        }
        public void TimerCountdown()
        {
            if (timeRemaining > 0)
            {
               
                    timeRemaining -= Time.deltaTime;
                    if (timeRemaining < 0) timeRemaining = 0; // Đảm bảo không giảm dưới 0
                    UpdateTimer();
                
            }
            else
            {
                gameOver.gameObject.SetActive(true);
                _isStartGame = false;
                playAgain.gameObject.SetActive(true);
            }

        }
        public void NewGameButton()
        {
            itemCollectionMisson.gameObject.SetActive(false);
            clickToPlay.gameObject.SetActive(false);
            carrotUI.gameObject.SetActive(true);
            strawberryUI.gameObject.SetActive(true); 
            grapeUI.gameObject.SetActive(true);
            orangeUI.gameObject.SetActive(true);
            missonUI.gameObject.SetActive(true);
            backgroundFruitUI.gameObject.SetActive(true);
            _isStartGame = true;
        }

        public void PlayAgain()
        {
            playAgain.gameObject.SetActive(false); // Ẩn nút "Play Again"
            StateManager.Instance.NewGame(); // Bắt đầu lại trò chơi
            timeRemaining = 150f;
            _isStartGame = true;
        }
        private void UpdateTimer()
        {
            timerText.text = Mathf.Floor(timeRemaining).ToString();
        }
    }
}
