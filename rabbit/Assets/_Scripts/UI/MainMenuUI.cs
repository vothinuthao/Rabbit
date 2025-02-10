

using Runtime.GamePlay.Manager;

namespace Runtime.GamePlay.GameState
{
    using UnityEngine;

    public class MainMenuUI : MonoBehaviour
    {
        // Start is called before the first frame update
        public GameObject howToPlayPanel;

        public void TogglePanel()
        {
            bool isActive = howToPlayPanel.activeSelf;
            howToPlayPanel.SetActive(!isActive); // Đảo trạng thái hiển thị
        }

        public void StartGame()
        {
            Debug.Log("Start Game button clicked.");
            //SceneManager.LoadScene("CollectCarrot");
            LevelManager.Instance.LoadLevel(0);
            GameManager.Instance.StartLevel();
        }
    }
}
