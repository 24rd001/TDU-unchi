using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class PlayerController2D : MonoBehaviour
{
    [Header("Move")]
    public float moveSpeed = 6f;

    [Header("Jump")]
    public float jumpPower = 12f;

    [Header("Ground Check")]
    public LayerMask groundLayer;
    public float groundCheckDistance = 0.08f;

    private Rigidbody2D rb;
    private CircleCollider2D circleCol;

    private float moveInput;
    private bool jumpPressed;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        circleCol = GetComponent<CircleCollider2D>();

        rb.freezeRotation = true;
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpPressed = true;
        }

        Flip();
    }

    void FixedUpdate()
    {
        Move();

        if (jumpPressed && IsGrounded())
        {
            Jump();
        }

        jumpPressed = false;
    }

    void Move()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
    }

    bool IsGrounded()
    {
        Bounds bounds = circleCol.bounds;

        RaycastHit2D hit = Physics2D.BoxCast(
            bounds.center,
            bounds.size,
            0f,
            Vector2.down,
            groundCheckDistance,
            groundLayer
        );

        return hit.collider != null;
    }

    void Flip()
    {
        if (moveInput > 0)
        {
            transform.localScale = new Vector3(3, 3, 3);
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-3, 3, 3);
        }
    }
}