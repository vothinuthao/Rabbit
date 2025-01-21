using UnityEngine;
using TMPro;
using System.Collections;
using Unity.VisualScripting.ReorderableList;
using UnityEditor;
using Assets._Scripts.Runtime.GamePlay.GameState;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    public InventoryManager inventoryManager; // Tham chiếu đến InventoryManager
    private int maxItems = 10;
    public TextMeshProUGUI backpackFullText;
    public TextMeshProUGUI carrotQuantityText;
    public TextMeshProUGUI grapeQuantityText;
    public TextMeshProUGUI strawberryQuantityText;
    public TextMeshProUGUI orangeQuantityText;
    public int totalItems;

    private ItemObject itemObject;

    public Dictionary<string, int> requiredItems = new Dictionary<string, int>
{
    { "Carrot", 2 },
    { "Grape", 3 },
    { "Strawberry", 3 },
    { "Orange", 2 }
};

    public Dictionary<string, int> collectedItems = new Dictionary<string, int>();

    // Khởi tạo số lượng đã thu thập về 0


    // Khi người chơi va chạm với vật phẩm
    private void Start()
    {
        totalItems = 0;
        backpackFullText.enabled = false;
        collectedItems.Add("Carrot", 0);
        collectedItems.Add("Grape", 0);
        collectedItems.Add("Strawberry", 0);
        collectedItems.Add("Orange", 0);
    }
    private void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item")) // Kiểm tra nếu đối tượng là vật phẩm
        {
            itemObject = collision.GetComponent<ItemObject>();
            if (itemObject != null)
            {
                if (totalItems >= maxItems)
                {
                    ShowBackpackFullMessage();
                }
                else
                {
                    inventoryManager.AddItem(itemObject.item); // Thêm vật phẩm vào inventory
                    AddItemToCollected(itemObject.item.itemName, collision);
                    Destroy(collision.gameObject); // Xóa vật phẩm khỏi màn hình
                    totalItems++;
                    ShowNumbersOfItemCollected(itemObject.item);

                }
                //inventoryManager.DisplayInventory(); // Hiển thị balo sau khi thêm vật phẩm
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
    public void CheckIfCollectionIsComplete(Collider2D collision)
    {
        bool allItemsCollected = true;

        foreach (var requiredItem in requiredItems)
        {
            // Nếu bất kỳ vật phẩm nào chưa đủ số lượng thì không đủ điều kiện
            if (collectedItems[requiredItem.Key] < requiredItem.Value)
            {
                allItemsCollected = false;
                break;
            }
        }

        if (allItemsCollected && ToTheMagicGate(collision))
        {
            Debug.Log("All items collected! You can now proceed to the next level.");
            // Gọi lệnh qua màn hoặc mở cửa chẳng hạn
            StateManager.Instance.NextLevel();
        }

    }
    public void AddItemToCollected(string itemName, Collider2D collision)
    {
        if (collectedItems.ContainsKey(itemName))
        {
            collectedItems[itemName]++;
            CheckIfCollectionIsComplete(collision); // Kiểm tra sau mỗi lần thu thập
        }
    }

    public bool ToTheMagicGate(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MagicGate")) // Kiểm tra nếu đối tượng là cửa cuối
        {
            return true;
        }
        return false;
    }



    }

