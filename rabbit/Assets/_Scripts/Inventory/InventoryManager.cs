using TMPro;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
 

public class InventoryManager : MonoBehaviour
{
    public List<Item> items = new List<Item>(); // Danh sách các vật phẩm
    
    
    public void AddItem(Item item)
    {
        //Tìm kiếm vật phẩm trong inventory dựa trên tên
        Item existingItem = items.Find(i => i.itemName == item.itemName);
        if (existingItem != null)
        {
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
        if (items.Count > 0)
        {
            // Xóa vật phẩm cuối cùng
            Item lastItem = items[items.Count - 1]; // Lấy vật phẩm cuối
            items.RemoveAt(items.Count - 1); // Xóa vật phẩm

            Debug.Log("Removed item: " + lastItem.itemName);
            //StateManager.SubtractTime(10); // Trừ 10 giây khi xóa item
        }
        else
        {
            Debug.Log("Inventory is empty. Cannot remove item.");
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

    public void ClearItems(Item item)
    {
        Item.Destroy(item);
    }

    // public void InitializeItems(Item newItem)
    // {
    //     foreach (Item currentItem  in items)
    //     {
    //         currentItem.quantity = 1;  // Đặt số lượng của từng item về 0 khi bắt đầu game
    //     }
    // }

}