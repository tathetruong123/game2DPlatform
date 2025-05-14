using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    private PlayerController playerController;



    void Start()
    {
        animator = GetComponent<Animator>();
        playerController = GetComponentInParent<PlayerController>();
    }

    void Update()
    {
        // Set speed parameter (absolute to ensure both left/right movement counts)
        animator.SetFloat("Speed", Mathf.Abs(playerController.MoveInput));

        // Set grounded state
        animator.SetBool("IsGrounded", playerController.IsGrounded);
    }
}
