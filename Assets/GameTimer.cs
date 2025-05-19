using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameTimer : MonoBehaviour
{
    public float totalTime = 90f;
    private float currentTime;

    public TextMeshProUGUI timerText;

    public gol_cizgisii kalecizgisiSol;
    public gol_cizgisii kalecizgisiSag;

    [Header("Kazanan Prefabları (Opsiyonel, atanmazsa currentPlayer kullanılır)")]
    public GameObject player1Prefab;
    public GameObject player2Prefab;

    public Transform winnerSpawnPoint;

    private bool gameEnded = false;
    private bool timerActive = false;  // Sayaç aktiflik durumu

    [HideInInspector] public GameObject currentPlayer1;
    [HideInInspector] public GameObject currentPlayer2;

    void Start()
    {
        currentTime = totalTime;

        if (player1Prefab == null && currentPlayer1 != null)
            player1Prefab = currentPlayer1;
        if (player2Prefab == null && currentPlayer2 != null)
            player2Prefab = currentPlayer2;

        UpdateTimerUI();

        // Sayaç başlatma gecikmesi
        StartCoroutine(StartTimerAfterDelay(6f));
    }

    IEnumerator StartTimerAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        timerActive = true;
    }

    void Update()
    {
        if (gameEnded) return;

        if (!timerActive)
        {
            UpdateTimerUI(); // Gecikme süresince UI güncellensin
            return;
        }

        currentTime -= Time.deltaTime;

        int score1 = kalecizgisiSag.GetScore();
        int score2 = kalecizgisiSol.GetScore();

        if (score1 >= 10 || score2 >= 10)
        {
            EndGame();
            return;
        }

        if (currentTime <= 0f)
        {
            currentTime = 0f;
            EndGame();
        }

        UpdateTimerUI();
    }

    void UpdateTimerUI()
    {
        int seconds = Mathf.CeilToInt(currentTime);
        timerText.text = seconds.ToString();
    }

    void EndGame()
    {
        if (gameEnded) return;

        gameEnded = true;

        Time.timeScale = 0f;  // Oyun duracak, ancak müzik devam etmeli.

        int score1 = kalecizgisiSag.GetScore();
        int score2 = kalecizgisiSol.GetScore();

        if (endGamePanel != null)
            endGamePanel.SetActive(true);  // EndGamePanel'i aktif et

        // Müziğin devam etmesini sağla
        MenuMusicPlayer.instance.PauseMusic();

        if (score1 > score2)
        {
            winnerText.text = "Kazanan: Oyuncu 1";
            if (player1Prefab != null)
                Instantiate(player1Prefab, winnerSpawnPoint.position, Quaternion.identity);
        }
        else if (score2 > score1)
        {
            winnerText.text = "Kazanan: Oyuncu 2";
            if (player2Prefab != null)
                Instantiate(player2Prefab, winnerSpawnPoint.position, Quaternion.identity);
        }
        else
        {
            winnerText.text = "Berabere!";
            Vector3 offset = new Vector3(1.5f, 0, 0);
            if (player1Prefab != null)
                Instantiate(player1Prefab, winnerSpawnPoint.position - offset, Quaternion.identity);
            if (player2Prefab != null)
                Instantiate(player2Prefab, winnerSpawnPoint.position + offset, Quaternion.identity);
        }
    }

    [Header("Oyun Sonu UI")]
    public GameObject endGamePanel;
    public TextMeshProUGUI winnerText;

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1); // Ana menü sahnesi
    }

    public void GoToCharacterSelect()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2); // Karakter seçimi sahnesi
    }
}
