using UnityEngine;
using Runtime.GamePlay.GameState;
public class FruitController : MonoBehaviour
{
    [SerializeField] private FruitType fruitType;
    [SerializeField] private ParticleSystem collectEffect;
    [SerializeField] private AudioClip collectSound;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
                CollectFruit();
        }
    }
    
    private void CollectFruit()
    {
        // Hiệu ứng thu thập
        if (collectEffect != null)
        {
            var effect = Instantiate(collectEffect, transform.position, Quaternion.identity);
            effect.Play();
            Destroy(effect.gameObject, effect.main.duration);
        }
        
        // Âm thanh
        if (collectSound != null)
        {
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
        }
        
        // Thông báo cho InventoryController
        InventoryController.Instance.CollectFruit(fruitType);
        
        // Hủy game object
        Destroy(gameObject);
    }
    
#if UNITY_EDITOR
    private void OnValidate()
    {
        // Tự động cập nhật sprite dựa trên FruitType
        var spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            // Lấy sprite tương ứng từ Resources hoặc ScriptableObject
            // spriteRenderer.sprite = FruitDatabase.GetSprite(fruitType);
        }
    }
#endif
}