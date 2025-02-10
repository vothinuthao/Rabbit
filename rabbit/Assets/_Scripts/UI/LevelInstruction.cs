using Runtime.GamePlay.GameState;
using TMPro;
using UnityEngine;

public class LevelInstruction : MonoBehaviour
{
    public TextMeshProUGUI levelInstructionText; // Tham chiếu đến dòng text thông báo
    public Transform playerTransform; // Tham chiếu đến nhân vật
    private Vector3 lastPlayerPosition;

    void Start()
    {
        if (playerTransform == null)
        {
            Debug.LogError("Player Transform is not assigned!");
            return;
        }
        lastPlayerPosition = playerTransform.position;
        ShowInstruction();

        Debug.Log($"Initial Text Enabled State: {levelInstructionText.enabled}");
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (playerTransform != null && levelInstructionText != null && levelInstructionText.enabled)
        {
            // Kiểm tra nếu vị trí của nhân vật thay đổi theo trục X
            if (Mathf.Abs(playerTransform.position.x - lastPlayerPosition.x) > 0.1f) // Thêm ngưỡng nhỏ
            {
                Debug.Log("Player moved on X-axis! Hiding instruction text.");
                HideInstruction(); // Ẩn thông báo
            }
        }
    }
    public void ShowInstruction()
    {
        if (InventoryController.Instance == null)
        {
            Debug.LogError("InventoryController is not initialized!");
            return;
        }

        FruitType requiredFruitType = InventoryController.Instance.GetCurrentFruitType();
        if (levelInstructionText != null)
        {
            levelInstructionText.text = $"Collect {requiredFruitType} to complete the level!";
            levelInstructionText.enabled = true; 
        }
    }
    private void HideInstruction()
    {
        if (levelInstructionText != null)
        {
            levelInstructionText.enabled = false;
        }
    }
}