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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            Jump();   // —‚¿‚Ä‚«‚ÄG‚ê‚½‚ç‚Ü‚½ã‚Ö
        }
    }
}
