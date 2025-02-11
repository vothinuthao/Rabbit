using Runtime.GamePlay.Manager;

namespace Runtime.GamePlay.GameState
{
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using System.Collections.Generic;

    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance { get; private set; }

        [Header("Level Configuration")] [SerializeField]
        private List<LevelData> levels;

        [SerializeField] private int currentLevelIndex = 0;

        public LevelData CurrentLevel => levels[currentLevelIndex];

        private void Awake()
        {
            // Singleton setup
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
            // Nếu không có levels nào, log lỗi
            if (levels == null || levels.Count == 0)
            {
                Debug.LogError("No levels assigned to LevelManager!");
                return;
            }
            
        }

        public void LoadLevel(int levelIndex)
        {
            // Kiểm tra index hợp lệ
            if (levelIndex < 0 || levelIndex >= levels.Count)
            {
                Debug.LogError($"Invalid level index: {levelIndex}");
                return;
            }

            currentLevelIndex = levelIndex;
            LoadCurrentLevel();
        }

        public void LoadCurrentLevel()
        {
            // Kiểm tra chỉ số level hợp lệ
            if (currentLevelIndex < 0 || currentLevelIndex >= levels.Count)
            {
                Debug.LogError($"Invalid level index: {currentLevelIndex}");
                return;
            }

            LevelData levelToLoad = levels[currentLevelIndex];

            // Kiểm tra tên scene hợp lệ
            if (string.IsNullOrEmpty(levelToLoad.sceneName))
            {
                Debug.LogError("Scene name is empty or invalid!");
                return;
            }
            Debug.Log($"Loading current level: {levelToLoad.sceneName}");
            if (InventoryController.Instance != null)
            {
                InventoryController.Instance.ResetData();
            }
            // Khởi tạo dữ liệu cho level mới
            if (InventoryController.Instance != null)
            {
                InventoryController.Instance.InitializeLevel(levelToLoad);
            }
            else
            {
                Debug.LogError("InventoryController is not initialized!");
            }

            // Đảm bảo thời gian chạy bình thường
            Time.timeScale = 1f;

            // Tải scene tương ứng
            SceneManager.LoadScene(levelToLoad.sceneName);
        }

        public void LoadNextLevel()
        {
            // Kiểm tra còn level tiếp theo không
            if (currentLevelIndex + 1 < levels.Count)
            {
                Debug.Log($"Loading next level: {levels[currentLevelIndex + 1].sceneName}");
                LoadLevel(currentLevelIndex + 1);
            }
            else
            {
                // Game complete logic
                Debug.Log("Congratulations! All levels completed!");
                GameManager.Instance.EndLevel(true);
                // Có thể thêm logic để quay lại menu hoặc restart game
            }
        }

        public void RestartCurrentLevel()
        {
            LoadCurrentLevel();
            SoundManager.Instance.PlayBackgroundMusic();
        }

        public bool IsLastLevel()
        {
            return currentLevelIndex == levels.Count - 1;
        }

        public int GetTotalLevels()
        {
            return levels.Count;
        }

        public int GetCurrentLevelNumber()
        {
            return currentLevelIndex + 1; // +1 vì index bắt đầu từ 0
        }
        

#if UNITY_EDITOR
        // Helper function để kiểm tra setup trong Editor
        private void OnValidate()
        {
            if (levels != null && levels.Count > 0)
            {
                foreach (var level in levels)
                {
                    if (level == null)
                    {
                        Debug.LogWarning("Null level data detected in LevelManager!");
                    }
                    else if (string.IsNullOrEmpty(level.sceneName))
                    {
                        Debug.LogWarning($"Empty scene name in level {level.levelNumber}");
                    }
                }
            }
        }
#endif
    }
}