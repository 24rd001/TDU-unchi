using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerController2D : MonoBehaviour
{
    [Header("Move")]
    public float moveSpeed = 6f;

    [Header("Jump")]
    public float jumpPower = 12f;

    [Header("Ground Check")]
    public LayerMask groundLayer;
    public float groundCheckDistance = 0.08f;

    [Header("Wall Check")]
    public float wallCheckDistance = 0.1f;

    // 現在向いている方向
    [HideInInspector]
    public bool facingRight = true;

    [Header("Villi Trap")]
    public int escapeCount = 15;

    private Rigidbody2D rb;
    private CircleCollider2D circleCol;
    private SpriteRenderer sr;

    private float moveInput;
    private bool jumpPressed;

    private int jumpCount = 0;
    private int maxJumpCount = 1;


    private float baseMoveSpeed;

    private bool isTrapped = false;
    private int mashCount = 0;
    private Vector2 trapPosition;
    private float originalGravityScale;


    void Awake()

    {
        rb = GetComponent<Rigidbody2D>();
        circleCol = GetComponent<CircleCollider2D>();
        sr = GetComponent<SpriteRenderer>();

        rb.freezeRotation = true;

        originalGravityScale = rb.gravityScale;

        baseMoveSpeed = moveSpeed;
    }


    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        if (isTrapped)
        {
            TrapInput();
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpPressed = true;
        }

        Flip();

        ApplyLevelBonus();
    }

    void FixedUpdate()
    {
        if (isTrapped)
        {
            rb.linearVelocity = Vector2.zero;
            rb.position = trapPosition;
            return;
        }

        Move();

        if (IsGrounded() && rb.linearVelocity.y <= 0f)
        {
            jumpCount = 0;
        }


        

        if (jumpPressed &&
            jumpCount < maxJumpCount &&
            !IsTouchingWall())
        {
            Jump();
            jumpCount++;
        }

        jumpPressed = false;
    }

    void Move()
    {
        if (IsTouchingWall() && !IsGrounded())
        {
            rb.linearVelocity =
                new Vector2(0f, rb.linearVelocity.y);

            return;
        }

        rb.linearVelocity = new Vector2(
            moveInput * moveSpeed,
            rb.linearVelocity.y
        );
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(
            rb.linearVelocity.x,
            jumpPower
        );
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

    bool IsTouchingWall()
    {
        Vector2 direction =
            facingRight ? Vector2.right : Vector2.left;

        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            direction,
            wallCheckDistance
        );

        return hit.collider != null &&
               hit.collider.CompareTag("Wall");
    }

    void Flip()
{
    if (moveInput > 0)
    {
        facingRight = true;
        sr.flipX = false;
    }
    else if (moveInput < 0)
    {
        facingRight = false;
        sr.flipX = true;
    }
}
    public void StartTrap(Vector2 position)
    {
        if (isTrapped) return;

        isTrapped = true;
        mashCount = 0;
        trapPosition = position;

        rb.linearVelocity = Vector2.zero;
        rb.gravityScale = 0f;
    }

    void TrapInput()
    {
        if (Input.GetKeyDown(KeyCode.A) ||
            Input.GetKeyDown(KeyCode.D) ||
            Input.GetKeyDown(KeyCode.LeftArrow) ||
            Input.GetKeyDown(KeyCode.RightArrow))
        {
            mashCount++;
        }

        if (mashCount >= escapeCount)
        {
            EscapeTrap();
        }
    }

    void EscapeTrap()
    {
        isTrapped = false;
        mashCount = 0;

        rb.gravityScale = originalGravityScale;

        rb.linearVelocity = new Vector2(0f, 3f);
    }

    void ApplyLevelBonus()
    {
        if (LevelManager.Instance == null)
            return;

        // Lv2で二段ジャンプ解放
        if (LevelManager.Instance.level >= 2)
        {
            maxJumpCount = 2;
        }
        else
        {
            maxJumpCount = 1;
        }

        // Lv3で移動速度アップ
        if (LevelManager.Instance.level >= 3)
        {
            moveSpeed = baseMoveSpeed + 0.5f;
        }
        else
        {
            moveSpeed = baseMoveSpeed;
        }
    }
}