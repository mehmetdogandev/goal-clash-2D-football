using UnityEngine;
using UnityEngine.SceneManagement;

public class menuyegidis : MonoBehaviour
{
    public string sceneName; // Geçilecek sahnenin ismini buradan ver

    public void LoadTargetScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}