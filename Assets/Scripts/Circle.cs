using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 12f;
    public float jumpPower = 8f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");

        rb.linearVelocity = new Vector2(x * speed, rb.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
        }
    }
}