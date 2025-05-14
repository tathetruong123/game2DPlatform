using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public GameOverManager gameOverManager;

    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;

    public float MoveInput { get; private set; }
    public bool IsGrounded { get; private set; }

    private Rigidbody2D rb;
    private bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        MoveInput = Input.GetAxisRaw("Horizontal");
        IsGrounded = IsGroundedByTag();

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // fixed here
        }

        if (MoveInput > 0 && !facingRight) Flip();
        else if (MoveInput < 0 && facingRight) Flip();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(MoveInput * moveSpeed, rb.linearVelocity.y); // also fix here
    }


    private bool IsGroundedByTag()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckRadius);
        foreach (var col in colliders)
        {
            if (col.CompareTag("Ground"))
                return true;
        }
        return false;
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    public void Die()
    {
        Debug.Log("Player Died!");
        if (gameOverManager != null)
        {
            gameOverManager.ShowGameOver();
        }

        Debug.Log("Player died!");
        Time.timeScale = 0f;
        
    }




}
