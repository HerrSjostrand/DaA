using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public float moveSpeed;

    private Vector2 moveDirection;

    public InputActionReference move;

    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        moveDirection = move.action.ReadValue<Vector2>();
        if (rb.velocity.x > 0)
        {
            animator.SetBool("IsWalking", true);
            sr.flipX = false;
        }
        if (rb.velocity.x < 0)
        {
            animator.SetBool("IsWalking", true);
            sr.flipX = true;
        }
        if (rb.velocity.x == 0)
        {
           animator.SetBool("IsWalking", false); 
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
