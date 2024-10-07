using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameData : MonoBehaviour
{
    //public TextMeshProUGUI timerText;
    //public Texture2D beginStateSplash;
   // public Texture2D lostStateSplash;
    //public Texture2D wonStateSplash;
    //public Dictionary<string, int> requiredItems = new Dictionary<string, int> { };
    //public Image missionLevel1; 
    public List<GameObject> cameras;
    public string playGameScene1 = "Scene1";
    private float timeRemaining = 150f;
    private int sceneBeginningScore;
    public GameObject itemCollectionMisson;
    public Button clickToPlay;
 
    [HideInInspector]
    public int playerLives;
    [HideInInspector]
    public int score;
 
    void Start ()
    {
        
        
    }
 
    public void ResetPlayer()
    {
        
    }
 
    public void SetPlayerLives(int livesSelected)
    {
        
    }
    public void SetScore()
    {
        sceneBeginningScore = score;
    }
    public void TimerCountdown()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerUI();
        }
        else
        {
            // Khi thời gian hết, thay đổi state sang LoseState
            Debug.Log("Hết thời gian!");
            // Chuyển sang LoseState...
        }
        
    }
    private void UpdateTimerUI()
    {
        //timerText.text = Mathf.Floor(timeRemaining).ToString();
    }
    public void ShowUI()
    {
        if (itemCollectionMisson != null)
        {
            itemCollectionMisson.SetActive(true);
        }
        else
        {
            Debug.LogError("itemCollectionMisson is null!");
        }
    }

    public void HideUI()
    {
        if (itemCollectionMisson != null)
        {
            itemCollectionMisson.SetActive(false);
        }
        else
        {
            Debug.LogError("itemCollectionMisson is null!");
        }
    }


}