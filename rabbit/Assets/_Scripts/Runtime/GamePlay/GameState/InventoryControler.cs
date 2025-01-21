
using UnityEngine;
using UnityEngine.Events;
using Runtime.GamePlay.GameState;
using Runtime.GamePlay.Manager;
public class InventoryController : MonoBehaviour
{
    public static InventoryController Instance { get; private set; }
    
    // Events
    public event UnityAction<int, int> OnFruitCollected; // Current amount, Required amount
    public event UnityAction OnLevelComplete;
    
    // Current level data
    private FruitType currentFruitType;
    private int requiredAmount;
    private int collectedAmount;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void InitializeLevel(LevelData levelData)
    {
        currentFruitType = levelData.requiredFruitType;
        requiredAmount = levelData.requiredAmount;
        collectedAmount = 0;
        
        // Thông báo trạng thái ban đầu
        OnFruitCollected?.Invoke(collectedAmount, requiredAmount);
    }
    
    public void CollectFruit(FruitType fruitType)
    {
        // Chỉ thu thập nếu đúng loại fruit cho level hiện tại
        if (fruitType != currentFruitType) return;
        
        collectedAmount++;
        OnFruitCollected?.Invoke(collectedAmount, requiredAmount);
        
        // Kiểm tra hoàn thành
        if (collectedAmount >= requiredAmount)
        {
            OnLevelComplete?.Invoke();
            GameManager.Instance.EndLevel(true);
        }
    }
    
    public float GetProgress()
    {
        return (float)collectedAmount / requiredAmount;
    }
    
    public FruitType GetCurrentFruitType()
    {
        return currentFruitType;
    }
    
    public void ResetCollection()
    {
        collectedAmount = 0;
        OnFruitCollected?.Invoke(collectedAmount, requiredAmount);
    }
}