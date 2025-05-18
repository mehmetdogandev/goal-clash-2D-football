using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuPanel;

    private bool isPaused = false;

    void Start()
    {
        pauseMenuPanel.SetActive(false); // başta gizli
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // oyunu durdur
            pauseMenuPanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f; // oyunu devam ettir
            pauseMenuPanel.SetActive(false);
        }
    }

    public void ContinueGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenuPanel.SetActive(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1); // Ana menü sahnesi index
    }
    void Update()
{
    if (Input.GetKeyDown(KeyCode.Escape))
    {
        TogglePause();
    }
}

}
