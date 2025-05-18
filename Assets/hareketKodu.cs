using UnityEngine;
using System.Collections;

public class hareketKodu : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public string playerNumber = "1";

    private Rigidbody2D rb;
    private bool isGrounded = false;
    private Animator animator;

    public Transform groundCheck;
    public float checkRadius = 0.2f;
    public LayerMask whatIsGround;

    public bool canMove = false;  // Başlangıçta hareket engelli

    public AudioSource audioSource;  // Ses çalacak component
    public AudioClip startSound;     // Başlangıçta çalacak ses dosyası

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        // Başlangıç sesini çal
        if (audioSource != null && startSound != null)
        {
            audioSource.clip = startSound;
            audioSource.Play();
        }

        // 3 saniye sonra hareket açılacak
        StartCoroutine(EnableMovementAfterDelay(6f));
    }

    IEnumerator EnableMovementAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canMove = true;
    }

    void Update()
    {
        if (!canMove)
        {
            // Hareket engellendiği için dur
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            animator.SetBool("isIdle", true);
            return;
        }

        // Hareket kodları burada devam eder
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        float moveDirection = 0f;
        bool isJumpPressed = false;

        if (playerNumber == "1")
        {
            if (Input.GetKey(KeyCode.D))
                moveDirection = 1;
            else if (Input.GetKey(KeyCode.A))
                moveDirection = -1;

            isJumpPressed = Input.GetKeyDown(KeyCode.W);

            if (Input.GetKeyDown(KeyCode.Space))
                animator.SetTrigger("isKicking");
        }

        if (playerNumber == "2")
        {
            if (Input.GetKey(KeyCode.RightArrow))
                moveDirection = 1;
            else if (Input.GetKey(KeyCode.LeftArrow))
                moveDirection = -1;

            isJumpPressed = Input.GetKeyDown(KeyCode.UpArrow);

            if (Input.GetKeyDown(KeyCode.M))
                animator.SetTrigger("isKicking");
        }

        rb.linearVelocity = new Vector2(moveDirection * moveSpeed, rb.linearVelocity.y);

        if (isJumpPressed && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        animator.SetBool("isJumping", !isGrounded);
        animator.SetBool("isMovingForward", moveDirection < 0);
        animator.SetBool("isMovingBackward", moveDirection > 0);
        animator.SetBool("isIdle", moveDirection == 0 && isGrounded);
    }
}
