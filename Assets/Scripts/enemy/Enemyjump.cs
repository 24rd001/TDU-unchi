using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemyjump : MonoBehaviour
{
    public float jumpPower = 10f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Jump();   // Å‰‚ÉƒWƒƒƒ“ƒv
    }

    void Jump()
    {
        // ^ã‚É‚¾‚¯”ò‚Ô
        rb.linearVelocity = new Vector2(0f, jumpPower);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Jump();
        }
    }
}
