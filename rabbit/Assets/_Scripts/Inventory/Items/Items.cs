using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item: ScriptableObject
{
    public string itemName;   // Tên vật phẩm
    public Sprite itemIcon;   // Icon hiển thị của vật phẩm
    public int quantity;      // Số lượng vật phẩm
    
    public Item(string name, Sprite icon, int qty)
    {
        itemName = name;
        itemIcon = icon;
        quantity = qty;
    }
    
}