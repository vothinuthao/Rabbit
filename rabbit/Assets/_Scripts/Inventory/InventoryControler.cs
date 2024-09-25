using UnityEngine;
using TMPro;
using System.Collections;
using Unity.VisualScripting.ReorderableList;
using UnityEditor;

public class PlayerInventory : MonoBehaviour
{
    public InventoryManager inventoryManager; // Tham chiếu đến InventoryManager
    private int maxItems = 10;
    public TextMeshProUGUI backpackFullText;
    public TextMeshProUGUI carrotQuantityText;
    public TextMeshProUGUI grapeQuantityText;
    public TextMeshProUGUI strawberryQuantityText;
    public TextMeshProUGUI orangeQuantityText;
    private int totalItems;
    
    // Khi người chơi va chạm với vật phẩm
    private void Start()
    {
        totalItems = 0;
        backpackFullText.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Item")) // Kiểm tra nếu đối tượng là vật phẩm
        {
            ItemObject itemObject = collision.GetComponent<ItemObject>();
            if (itemObject != null)
            {
                if (totalItems >= maxItems)
                {
                    ShowBackpackFullMessage();
                }
                else
                {  
                    inventoryManager.AddItem(itemObject.item); // Thêm vật phẩm vào inventory
                    Destroy(collision.gameObject); // Xóa vật phẩm khỏi màn hình
                    totalItems ++ ;
                    ShowNumbersOfItemCollected(itemObject.item);
                }
                inventoryManager.DisplayInventory(); // Hiển thị balo sau khi thêm vật phẩm
            }
        }
    }
    public void ShowBackpackFullMessage()
    {
        backpackFullText.enabled = true;
        // backpackFullText.text = "Backpack is full!";
        
        // Ẩn thông báo sau vài giây (ví dụ: 2 giây)
        StartCoroutine(HideMessageAfterDelay(2f));
    }
    private IEnumerator HideMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        backpackFullText.enabled = false;  // Ẩn thông báo sau khi hết thời gian
    }

    public void ShowNumbersOfItemCollected(Item item)

    {
        switch (item.itemName)
        {
            case "Carrot":
                carrotQuantityText.text = item.quantity.ToString();
                break;
            case "Grape":
                grapeQuantityText.text = item.quantity.ToString();
                break;
            case "Strawberry":
                strawberryQuantityText.text = item.quantity.ToString();
                break;
            case "Orange":
                orangeQuantityText.text = item.quantity.ToString();
                break;
        }
    }
   
}
    
