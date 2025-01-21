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

}
  