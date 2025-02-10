using Runtime.GamePlay.GameState;
using UnityEngine.SceneManagement;

namespace Runtime.GamePlay.Manager
{ 
    using UnityEngine;
    using UnityEngine.Events;
    public class GameManager : MonoBehaviour
    {
    public static GameManager Instance { get; private set; }
    
    //public event UnityAction<float> OnTimeUpdated;
    public event UnityAction<GameState> OnGameStateChanged;
    
    [Header("Level Settings")]
    //[SerializeField] private float levelTimeLimit = 180f; // 3 minutes
    
    private float currentLevelTime;
    private GameState currentGameState;
    
    // public float CurrentTime => currentLevelTime;
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
        GoToMainMenu();
    }
    
    private void Update()
    {
        // if (currentGameState == GameState.Playing)
        // {
        //     UpdateGameTime();
        // }
    }
    
    // private void UpdateGameTime()
    // {
    //     currentLevelTime += Time.deltaTime;
    //     OnTimeUpdated?.Invoke(currentLevelTime);
    //     
    //     if (currentLevelTime >= levelTimeLimit)
    //     {
    //         EndLevel(false);
    //     }
    // }
    
    public void StartLevel()
    {
       // currentLevelTime = 0f;
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
       if (!success) // Kiểm tra nếu màn chơi thất bại
           {
               SceneManager.LoadScene("LoseScreen");
           }
    }
    
    private void SetGameState(GameState newState)
    {
        currentGameState = newState;
        OnGameStateChanged?.Invoke(currentGameState);
    }
    public void GoToMainMenu()
    {
        SetGameState(GameState.MainMenu);
        Time.timeScale = 1f;

        // Reset dữ liệu level
       //LevelManager.Instance.RestartCurrentLevel();

        // Reset dữ liệu inventory
        // if (InventoryController.Instance != null)
        // {
        //     InventoryController.Instance.ResetData();
        // }

        SceneManager.LoadScene("MainMenu");
    }
    // private void OnEnable()
    // {
    //     GameManager.Instance.OnGameStateChanged += HandleGameStateChanged;
    // }
    //
    // private void OnDisable()
    // {
    //     GameManager.Instance.OnGameStateChanged -= HandleGameStateChanged;
    // }
    //
    // private void HandleGameStateChanged(GameState newState)
    // {
    //     if (newState == GameState.MainMenu)
    //     {
    //         SceneManager.LoadScene("MainMenu");
    //     }
    // }
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