using UnityEngine;

public class link_url : MonoBehaviour
{
    [Header("Açılacak URL")]
    public string url;

    // Bu fonksiyon butonla çağrılacak
    public void OpenLink()
    {
        if (!string.IsNullOrEmpty(url))
        {
            Application.OpenURL(url);
        }
        else
        {
            Debug.LogWarning("URL boş bırakılmış.");
        }
    }
}
