using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<Item> items = new List<Item>(); // Danh sách các vật phẩm

    // Thêm vật phẩm vào inventory
    public void AddItem(Item item)
    {
        // Tìm kiếm vật phẩm trong inventory dựa trên tên
        Item existingItem = items.Find(i => i.itemName == item.itemName);

        if (existingItem != null)
        {
            // Nếu vật phẩm đã tồn tại, tăng số lượng
            existingItem.quantity += item.quantity;
        }
        else
        {
            // Nếu vật phẩm chưa tồn tại, thêm mới vào danh sách
            items.Add(item);
        }
    }

    // Xóa vật phẩm khỏi inventory
    public void RemoveItem(Item item)
    {
        // Tìm kiếm vật phẩm theo tên
        Item existingItem = items.Find(i => i.itemName == item.itemName);
        if (existingItem != null)
        {
            items.Remove(existingItem);
        }
    }

    // Hiển thị inventory (dùng cho UI hoặc debug)
    public void DisplayInventory()
    {
        foreach (Item item in items)
        {
            Debug.Log(item.itemName + ": " + item.quantity);
        }
    }
}