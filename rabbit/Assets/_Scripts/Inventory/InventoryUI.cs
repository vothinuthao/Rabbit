using System.Collections.Generic;
using UnityEngine;
using TMPro;

using UnityEngine.UI;


public class InventoryUI : MonoBehaviour
{
    public GameObject itemPrefab;  // Prefab của hình ảnh vật phẩm (UI Image)
    public float spacing = 30f;    // Khoảng cách giữa các vật phẩm
    private List<GameObject> displayedItems = new List<GameObject>();
    public TextMeshProUGUI TimerCountDown;
    
    // Phương thức để xóa hoặc làm mới danh sách hiển thị (tuỳ chọn)
  
    

    private void TimerCountDownUI()
    {
        // timerText.text = StateManager.TimerCountdown(150).ToString();
    }    
}