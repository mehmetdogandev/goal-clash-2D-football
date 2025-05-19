using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    public GameObject endGamePanel;
    public AudioSource audioSource;  // AudioSource componentini buraya ekleyin

    private bool isPaused = false;

    void Start()
    {
        pauseMenuPanel.SetActive(false); // Başlangıçta gizle
        endGamePanel.SetActive(false);   // EndGamePanel de gizli
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;  // Oyun duracak
            pauseMenuPanel.SetActive(true);

            // Müzik çalmaya başlasın
            MenuMusicPlayer.instance.PauseMusic();
        }
        else
        {
            Time.timeScale = 1f;  // Oyun devam edecek
            pauseMenuPanel.SetActive(false);

            // Müzik duracak
            MenuMusicPlayer.instance.ResumeMusic();
        }
    }

    public void ContinueGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenuPanel.SetActive(false);

        // Müzik duracak
        MenuMusicPlayer.instance.ResumeMusic();
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);  // Ana menü sahnesi
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
}
