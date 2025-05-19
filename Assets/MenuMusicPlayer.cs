using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMusicPlayer : MonoBehaviour
{
    public static MenuMusicPlayer instance;

    public AudioSource audioSource;
    public AudioClip ossiMossiClip;

    private void Awake()
    {
        // Eğer başka bir instance varsa, bu objeyi yok et
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);  // Bu objeyi sahneler arasında koru

        // Müziği hemen çalma
        PlayMenuMusic();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // SampleScene açıldığında müziği durdur
        if (scene.buildIndex == 0)
        {
            StopMenuMusic();
        }
        else
        {
            // Menü veya oyun dışındaki sahnelerde müziği durdurma
            PlayMenuMusic();
        }
    }

    public void PlayMenuMusic()
    {
        if (audioSource != null && ossiMossiClip != null)
        {
            if (!audioSource.isPlaying && Time.timeScale == 1)  // Sadece oyun durmadıysa müzik çalsın
            {
                audioSource.clip = ossiMossiClip;
                audioSource.loop = true;
                audioSource.Play();
            }
        }
    }

    public void StopMenuMusic()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();  // Müzik durur
        }
    }

    // Ses seviyesini slider ile kontrol et
    public void SetVolume(float volume)
    {
        if (audioSource != null)
        {
            audioSource.volume = volume;  // Ses seviyesini slider değeri ile ayarla
        }
    }

    // Oyun başladığında müziği durdur (Pause veya EndGame paneli açıldığında)
    public void PauseMusic()
    {
        if (audioSource != null && !audioSource.isPlaying && Time.timeScale == 0)
        {
            audioSource.Play();
        }
    }

    // Oyun devam ettiğinde müzik duracak
    public void ResumeMusic()
    {
        if (audioSource != null && audioSource.isPlaying && Time.timeScale == 1)
        {
            audioSource.Stop();
        }
    }
}
