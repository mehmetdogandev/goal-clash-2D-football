using UnityEngine;
using UnityEngine.SceneManagement;

public class FlagSelector : MonoBehaviour
{
    public GameObject[] player1Flags;
    public GameObject[] player2Flags;

    private GameObject selectedPlayer1Flag = null;
    private GameObject selectedPlayer2Flag = null;

    public void SelectPlayer1Flag(GameObject clickedFlag)
{
    if (selectedPlayer1Flag == clickedFlag)
    {
        selectedPlayer1Flag = null;
        PlayerSelection.selectedPlayer1FlagIndex = -1;  // Seçim iptal edildi
        SetFlagsVisible(player1Flags, true);
    }
    else
    {
        selectedPlayer1Flag = clickedFlag;
        PlayerSelection.selectedPlayer1FlagIndex = System.Array.IndexOf(player1Flags, clickedFlag);
        SetFlagsVisible(player1Flags, false);
        clickedFlag.SetActive(true);
    }
}

public void SelectPlayer2Flag(GameObject clickedFlag)
{
    if (selectedPlayer2Flag == clickedFlag)
    {
        selectedPlayer2Flag = null;
        PlayerSelection.selectedPlayer2FlagIndex = -1;  // Seçim iptal edildi
        SetFlagsVisible(player2Flags, true);
    }
    else
    {
        selectedPlayer2Flag = clickedFlag;
        PlayerSelection.selectedPlayer2FlagIndex = System.Array.IndexOf(player2Flags, clickedFlag);
        SetFlagsVisible(player2Flags, false);
        clickedFlag.SetActive(true);
    }
}

    private void SetFlagsVisible(GameObject[] flags, bool isVisible)
    {
        foreach (GameObject flag in flags)
        {
            flag.SetActive(isVisible);
        }
    }

    public int GetSelectedPlayer1FlagIndex()
    {
        return System.Array.IndexOf(player1Flags, selectedPlayer1Flag);
    }

    public int GetSelectedPlayer2FlagIndex()
    {
        return System.Array.IndexOf(player2Flags, selectedPlayer2Flag);
    }

    // Başla butonuna bağlanacak fonksiyon
    public void LoadGameScene(string sceneName)
    {
        if (selectedPlayer1Flag == null || selectedPlayer2Flag == null)
        {
            Debug.LogWarning("Lütfen her iki oyuncu için bayrak seçiniz!");
            return;
        }

        SceneManager.LoadScene(sceneName);
    }
}
