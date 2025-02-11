
using System;
using UnityEngine;
using UnityEngine.Events;
using Runtime.GamePlay.GameState;
using Runtime.GamePlay.Manager;
public class InventoryController : MonoBehaviour
{
    public static InventoryController Instance { get; private set; }
    
    // Events
    public event UnityAction<int, int> OnFruitCollected; // Current amount, Required amount
   // public event UnityAction OnLevelComplete;
    
    // Current level data
    private FruitType currentFruitType;
    private int requiredAmount;
    private int collectedAmount;

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
            return;
        }
    }

    public void InitializeLevel(LevelData levelData)
    {
        currentFruitType = levelData.requiredFruitType;
        requiredAmount = levelData.requiredAmount;
        collectedAmount = 0;
        Debug.Log($"Initializing level: {levelData.sceneName}, Required Amount: {requiredAmount}");
        // Thông báo trạng thái ban đầu
        OnFruitCollected?.Invoke(collectedAmount, requiredAmount);
    }
    
    public bool CollectFruit(FruitType fruitType) // gợi ý nè => chỗ này chuyên void thaành bool , return ve 1 gia tri
    {
        // Chỉ thu thập nếu đúng loại fruit cho level hiện tại
        if (fruitType == currentFruitType)
        {
            collectedAmount++;
            OnFruitCollected?.Invoke(collectedAmount, requiredAmount);
            if (collectedAmount >= requiredAmount)
            {
                Debug.Log("Level complete!");
                //OnLevelComplete?.Invoke();
            }

            return true;
        }
        else
        {
            Debug.Log("Wrong fruit collected! Taking damage...");
            PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(); // Giảm máu khi thu thập sai trái cây
            }

            return false;
        }
       
        
    }

    public bool IsRequirementMet()
    {
        return collectedAmount >= requiredAmount;
    }
    
    // private void HandleFruitCollected(int currentAmount, int requiredAmount)
    // {
    //     Debug.Log($"HandleFruitCollected called: Current: {currentAmount}, Required: {requiredAmount}");
    // }
    //
    //
    // private void OnEnable()
    // {
    //     Debug.Log("FruitUIHandler OnEnable called.");
    //     if (InventoryController.Instance != null)
    //     {
    //         InventoryController.Instance.OnFruitCollected -= HandleFruitCollected; // Hủy đăng ký trước
    //         InventoryController.Instance.OnFruitCollected += HandleFruitCollected; // Đăng ký mới
    //     }
    //     else
    //     {
    //         Debug.LogError("InventoryController is not initialized!");
    //     }
    // }
    //
    // private void OnDisable()
    // {
    //     Debug.Log("FruitUIHandler OnDisable called.");
    //     if (InventoryController.Instance != null)
    //     {
    //         InventoryController.Instance.OnFruitCollected -= HandleFruitCollected; // Hủy đăng ký
    //     }
    // }
    public float GetProgress()
    {
        return (float)collectedAmount / requiredAmount;
    }
    
    public FruitType GetCurrentFruitType()
    {
        return currentFruitType; // học lại đoạn này tại sao phải làm như này ?
    }
    
    public void ResetCollection()
    {
        collectedAmount = 0;
        OnFruitCollected?.Invoke(collectedAmount, requiredAmount); // invoke của action , chú ý nha
    }
    public void ResetData()
    {
        currentFruitType = FruitType.None; // Reset loại trái cây
        requiredAmount = 0;               // Reset số lượng yêu cầu
        collectedAmount = 0;              // Reset số lượng đã thu thập

        //Debug.Log("Inventory data has been reset.");

        // Thông báo trạng thái ban đầu cho listener (nếu có)
        OnFruitCollected?.Invoke(collectedAmount, requiredAmount); // gút
    }
}