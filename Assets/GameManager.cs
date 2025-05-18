using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] player1CharacterPrefabs;
    public GameObject[] player2CharacterPrefabs;

    public Transform player1SpawnPoint;
    public Transform player2SpawnPoint;

    public gol_cizgisii kalecizgisiSol;  // Sol kale gol çizgisi scripti
    public gol_cizgisii kalecizgisiSag;  // Sağ kale gol çizgisi scripti

    public GameObject top;

    public GameTimer gameTimer;

    private GameObject currentPlayer1;
    private GameObject currentPlayer2;

    void Start()
    {
        int p1Index = PlayerSelection.selectedPlayer1FlagIndex;
        int p2Index = PlayerSelection.selectedPlayer2FlagIndex;

        if (p1Index < 0 || p1Index >= player1CharacterPrefabs.Length ||
            p2Index < 0 || p2Index >= player2CharacterPrefabs.Length)
        {
            Debug.LogError("Geçersiz oyuncu seçim indeksleri!");
            return;
        }

        // Oyuncuları spawn et
        currentPlayer1 = Instantiate(player1CharacterPrefabs[p1Index], player1SpawnPoint.position, Quaternion.identity);
        currentPlayer2 = Instantiate(player2CharacterPrefabs[p2Index], player2SpawnPoint.position, Quaternion.identity);

        // Gol çizgisi scriptlerine spawn edilen objeleri bildir
        kalecizgisiSol.player1 = currentPlayer1;
        kalecizgisiSol.player2 = currentPlayer2;
        kalecizgisiSol.top = top;

        kalecizgisiSag.player1 = currentPlayer1;
        kalecizgisiSag.player2 = currentPlayer2;
        kalecizgisiSag.top = top;

        // GameTimer scriptine runtime objeleri bildir
        gameTimer.currentPlayer1 = currentPlayer1;
        gameTimer.currentPlayer2 = currentPlayer2;
    }
}
