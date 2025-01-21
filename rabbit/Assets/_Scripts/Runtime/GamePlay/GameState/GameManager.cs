namespace Runtime.GamePlay.Manager
{
  using UnityEngine;
using UnityEngine.Events;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    public event UnityAction<float> OnTimeUpdated;
    public event UnityAction<GameState> OnGameStateChanged;
    
    [Header("Level Settings")]
    [SerializeField] private float levelTimeLimit = 180f; // 3 minutes
    
    private float currentLevelTime;
    private GameState currentGameState;
    
    public float CurrentTime => currentLevelTime;
    public GameState CurrentGameState => currentGameState;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void Start()
    {
        StartLevel();
    }
    
    private void Update()
    {
        if (currentGameState == GameState.Playing)
        {
            UpdateGameTime();
        }
    }
    
    private void UpdateGameTime()
    {
        currentLevelTime += Time.deltaTime;
        OnTimeUpdated?.Invoke(currentLevelTime);
        
        if (currentLevelTime >= levelTimeLimit)
        {
            EndLevel(false);
        }
    }
    
    public void StartLevel()
    {
        currentLevelTime = 0f;
        SetGameState(GameState.Playing);
    }
    
    public void PauseGame()
    {
        if (currentGameState == GameState.Playing)
        {
            SetGameState(GameState.Paused);
            Time.timeScale = 0f;
        }
    }
    
    public void ResumeGame()
    {
        if (currentGameState == GameState.Paused)
        {
            SetGameState(GameState.Playing);
            Time.timeScale = 1f;
        }
    }
    
    public void EndLevel(bool success)
    {
        SetGameState(success ? GameState.LevelComplete : GameState.LevelFailed);
        Time.timeScale = 0f;
    }
    
    private void SetGameState(GameState newState)
    {
        currentGameState = newState;
        OnGameStateChanged?.Invoke(currentGameState);
    }
}

public enum GameState
{
    MainMenu,
    Playing,
    Paused,
    LevelComplete,
    LevelFailed
}
}