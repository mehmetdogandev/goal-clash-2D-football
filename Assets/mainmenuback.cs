using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenuback : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public string sceneName; // Geçilecek sahnenin ismini buradan ver

    public void LoadTargetScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
