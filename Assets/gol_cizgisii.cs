using TMPro;
using UnityEngine;

public class gol_cizgisii : MonoBehaviour
{
    public Transform player1Spawner;
    public Transform player2Spawner;
    public Transform topSpawner;

    public GameObject player1;  // runtime’da atanacak
    public GameObject player2;  // runtime’da atanacak
    public GameObject top;

    public TextMeshProUGUI score1Text;
    public TextMeshProUGUI score2Text;

    public bool solKaleMi;
    public AudioSource audioSource;
    public AudioClip goalSound;

    private int score1 = 0;
    private int score2 = 0;
    public int GetScore()
    {
        if (solKaleMi)
            return score2;
        else
            return score1;
    }
    public void GolOlunca()
    {
        if (audioSource != null && goalSound != null)
        {
            audioSource.PlayOneShot(goalSound);
        }

        player1.transform.position = player1Spawner.position;
        player2.transform.position = player2Spawner.position;

        player1.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        player2.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;

        top.transform.position = topSpawner.position;
        top.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        top.GetComponent<Rigidbody2D>().angularVelocity = 0f;

        if (solKaleMi)
        {
            score2++;
            score2Text.text = score2.ToString();
        }
        else
        {
            score1++;
            score1Text.text = score1.ToString();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Top"))
        {
            GolOlunca();
        }
    }
}
