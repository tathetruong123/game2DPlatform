using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float moveRange = 3f;
    private float startX;
    private int direction = 1;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        startX = transform.position.x;

        // Lấy component Animator và SpriteRenderer
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Di chuyển qua lại theo trục X
        transform.Translate(Vector3.right * direction * -moveSpeed * Time.deltaTime);

        // Đổi hướng khi chạm biên
        if (Mathf.Abs(transform.position.x - startX) >= moveRange)
        {
            direction *= -1;
            // Quay mặt
            spriteRenderer.flipX = direction < 0;
        }

        // Bật animation nếu đang di chuyển
        if (animator != null)
        {
            animator.SetBool("isMoving", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(30);
            }
        }
    }
}
