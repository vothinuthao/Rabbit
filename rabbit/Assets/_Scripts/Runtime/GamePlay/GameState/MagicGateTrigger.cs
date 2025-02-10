
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Runtime.GamePlay.GameState
{
    public class MagicGateTrigger: MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Player Enter Final Gate!");
                if (InventoryController.Instance != null && InventoryController.Instance.IsRequirementMet())
                {
                    LevelManager.Instance.LoadNextLevel();
                }
                else
                {
                    Debug.Log("Requirement not met yet!");
                }
            }
        }
    }
}