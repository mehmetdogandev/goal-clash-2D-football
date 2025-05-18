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

        DontDestroyOnLoad(gameObject);

        // Müziği hemen çal
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
        if (scene.buildIndex == 0)  // SampleScene ise müziği durdur
        {
            StopMenuMusic();
        }
        else
        {
            // Diğer sahnelerde müziği çalmaya devam et
            PlayMenuMusic();
        }
    }

    public void PlayMenuMusic()
    {
        if (audioSource != null && ossiMossiClip != null)
        {
            if (!audioSource.isPlaying)
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
            audioSource.Stop();
        }
    }
}
