using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    public AudioClip winSound;
    public AudioClip loseSound;
    public AudioSource soundEffectSource;
    public AudioSource backgroundMusicSource;
    public AudioClip[] backgroundMusicClips;

    private void Awake()
    {
        // Đảm bảo chỉ có một instance của SoundManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Giữ GameObject qua các scene
        }
        else
        {
            Destroy(gameObject); // Xóa instance trùng lặp
        }

        // Kiểm tra AudioSource
        backgroundMusicSource = gameObject.AddComponent<AudioSource>();
        backgroundMusicSource.loop = true;
        backgroundMusicSource.volume = 0.5f;

        // Khởi tạo AudioSource cho hiệu ứng âm thanh
        soundEffectSource = gameObject.AddComponent<AudioSource>();
        soundEffectSource.loop = false;
    }
    public void PlayBackgroundMusic(int index = 0)
    {
        if (backgroundMusicSource != null && index < backgroundMusicClips.Length)
        {
            backgroundMusicSource.clip = backgroundMusicClips[index];
            backgroundMusicSource.Play();
        }
        else
        {
            Debug.LogError("Failed to play background music!");
        }
    }
    public void StopBackgroundMusic()
    {
        if (backgroundMusicSource != null)
        {
            backgroundMusicSource.Stop();
        }
    }
    
    public void PlayWinSound()
    {
        if (winSound != null)
        {
            soundEffectSource.clip = winSound;
            soundEffectSource.Play();
        }
        else
        {
            Debug.LogError("Win sound is not assigned!");
        }
    }
    
    public void PlayLoseSound()
    {
        if (loseSound != null)
        {
            soundEffectSource.clip = loseSound;
            soundEffectSource.Play();
        }
        else
        {
            Debug.LogError("Lose sound is not assigned!");
        }
    }
    
}