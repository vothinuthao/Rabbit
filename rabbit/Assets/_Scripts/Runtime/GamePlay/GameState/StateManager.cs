using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets._Scripts.Runtime.GamePlay.GameState
{
    public class StateManager : MonoBehaviour
    {
        public static StateManager Instance { get; private set; }
        public int world { get; private set; } = 1;
        public int stage { get; private set; } = 1;

        public int totalFruits { get; private set; } = 0; // Quản lý số trái cây
        public Item[] items;

        private void Awake()
        {
            if (Instance != null)
            {
                DestroyImmediate(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        private void OnDestroy()
        {
            if (Instance == this)
            {
                Instance = null;
            }
        }

        private void Start()
        {
            Application.targetFrameRate = 60;
            NewGame();
        }

        public void NewGame()
        {
            foreach (Item item in items)
            {
                item.quantity = 1;
            }

            LoadLevel(1, 1);
        }

        public void GameOver()
        {
            NewGame();
        }

        public void LoadLevel(int world, int stage)
        {
            this.world = world;
            this.stage = stage;

            SceneManager.LoadScene($"{world}-{stage}");
        }

        public void NextLevel()
        {
            LoadLevel(world, stage + 1);
        }

        public void ResetLevel(float delay)
        {
            CancelInvoke(nameof(ResetLevel));
            Invoke(nameof(ResetLevel), delay);
        }

        public void ResetLevel()
        {


            //if (lives > 0)
            //{
            //    LoadLevel(world, stage);
            //}
            //else
            //{
            //    GameOver();
            //}
        }




    }
}