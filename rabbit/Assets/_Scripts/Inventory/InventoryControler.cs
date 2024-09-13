using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public InventoryManager inventoryManager; // Tham chiếu đến InventoryManager

    // Khi người chơi va chạm với vật phẩm
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Item")) // Kiểm tra nếu đối tượng là vật phẩm
        {
            ItemObject itemObject = collision.GetComponent<ItemObject>();
            if (itemObject != null)
            {
                inventoryManager.AddItem(itemObject.item); // Thêm vật phẩm vào inventory
                inventoryManager.DisplayInventory(); // Hiển thị balo sau khi thêm vật phẩm
                Destroy(collision.gameObject); // Xóa vật phẩm khỏi màn hình
            }
        }
    }
}