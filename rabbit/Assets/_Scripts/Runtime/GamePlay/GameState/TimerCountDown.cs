// using System.Collections;
// using UnityEngine;
// using TMPro;
// using TMPro.Examples;
// using UnityEngine.UI;
//
// namespace Assets._Scripts.Runtime.GamePlay.GameState
// {
//     public class TimerCountDown : MonoBehaviour
//     {
//         public TextMeshProUGUI timerText;
//         private float timeRemaining = 150f;
//         public Button clickToPlay;
//         public Image itemCollectionMisson;
//
//         public void TimerCountdown()
//         {
//             if (timeRemaining > 0)
//             {
//                 timeRemaining -= Time.deltaTime;
//                 UpdateTimer();
//             }
//             else
//             {
//                 StateManager.Instance.GameOver();
//             }
//
//         }
//         public void NewGameButton()
//         {
//             itemCollectionMisson.gameObject.SetActive(false);
//             clickToPlay.gameObject.SetActive(false);
//         }
//
//         private void UpdateTimer()
//         {
//             timerText.text = Mathf.Floor(timeRemaining).ToString();
//         }
//     }
// }
