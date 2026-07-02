using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public float moveSpeed;
    public float jumpForce;

    private Vector2 moveDirection;

    public InputActionReference move;

    private Animator animator;
    private LayerMask layerMask;

    void Awake()
    {
        animator = GetComponent<Animator>();
        layerMask = LayerMask.GetMask("Ground");
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
        if (!IsGrounded())
        {
            animator.SetBool("IsJumping", true);
            animator.SetBool("IsWalking", false);
        }
        if (IsGrounded())
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", true);
        }

        Debug.Log(IsGrounded());
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.Raycast(gameObject.transform.position, transform.TransformDirection(Vector3.down), 1.1f, layerMask);
    }
}
