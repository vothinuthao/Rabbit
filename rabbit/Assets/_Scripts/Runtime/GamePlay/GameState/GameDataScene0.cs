using UnityEngine;
using System.Collections.Generic;
using Assets.Code.States;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class GameDataScene0 : MonoBehaviour
{
    public GameObject itemCollectionMisson;
    public List<GameObject> cameras;
    public Button clickToPlay;
    public string playGameScene1 = "Scene1";
    private float timeRemaining = 150f;
    private int sceneBeginningScore;

    public GameDataScene0(GameObject itemCollectionMisson)
    {
        this.itemCollectionMisson = itemCollectionMisson;
    }

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
            Debug.LogError("gameDataScene0Ref is null!");
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
            Debug.LogError("gameDataScene0Ref is null!");
        }
        
    }
    
    
}