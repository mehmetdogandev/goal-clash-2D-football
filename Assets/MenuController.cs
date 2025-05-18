using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
   public string sceneName; // Geçilecek sahnenin ismini buradan ver

    public void LoadTargetScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
