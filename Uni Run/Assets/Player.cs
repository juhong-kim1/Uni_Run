using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce = 10f;
    public int jumpCountMax = 2;

    public AudioClip dieAudioClip;

    private AudioSource audioSource;

    public int jumpCount = 0;
    private Animator animator;
    private Rigidbody2D rb;

    private bool isGrounded = true;
    private bool isDead = false;

    public GameManager manager;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            manager.AddScore(10);
        }


        if (isDead)
            return;

        if (Input.GetMouseButtonDown(0) && jumpCount < jumpCountMax)
        {
            rb.linearVelocity = Vector2.zero;
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            ++jumpCount;

            audioSource.Play();
        }

        if (Input.GetMouseButtonUp(0) && rb.linearVelocity.y > 0)
        {
            rb.linearVelocity *= 0.5f;
        }


        animator.SetBool("Grounded", isGrounded);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isDead && collision.CompareTag("Dead Zone"))
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Platform") && collision.contacts[0].normal.y > 0.7f)
        {
            jumpCount = 0;
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Platform"))
        {
            isGrounded = false;
        }
    }

    private void Die()
    {
        isDead = true;
        animator.SetTrigger("Die");
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.linearVelocity = Vector2.zero;

        manager.OnPlayerDead();

        //audioSource.clip = dieAudioClip;
        //audioSource.Play();

        audioSource.PlayOneShot(dieAudioClip);

    }
}
