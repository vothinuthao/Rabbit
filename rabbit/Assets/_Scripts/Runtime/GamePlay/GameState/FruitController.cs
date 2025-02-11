using UnityEngine;
using Runtime.GamePlay.GameState;
public class FruitController : MonoBehaviour
{
    [SerializeField] private FruitType fruitType;
    [SerializeField] private ParticleSystem correctEffect;
    [SerializeField] private ParticleSystem wrongEffect;
    [SerializeField] private AudioClip correctSound;
    [SerializeField] private AudioClip wrongSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
                CollectFruit();
        }
    }
    
    private void CollectFruit()
    {
        bool isSuccess = InventoryController.Instance.CollectFruit(fruitType);
        SpawnObjectEffect(isSuccess);
        SpawnObjectSound(isSuccess);
        // Hủy game object
        Destroy(gameObject);
    }

    private void SpawnObjectEffect(bool isCorrect)
    {
        var spawnVfx = isCorrect ? correctEffect : wrongEffect; // cái này sẽ tương đương với  cái dưới đây
        var effect = Instantiate(spawnVfx, transform.position, Quaternion.identity);
        effect.gameObject.SetActive(true);
        effect.Play();
        Destroy(effect.gameObject, effect.main.duration);
    }

    private void SpawnObjectSound(bool isCorrect)
    {
        var soundCollect = isCorrect ? correctSound : wrongSound;
        AudioSource.PlayClipAtPoint(soundCollect, transform.position);
    }
    
    
    
#if UNITY_EDITOR // cái này là gì ? 
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