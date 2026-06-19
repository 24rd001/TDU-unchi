using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 12f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");

        rb.linearVelocity = new Vector2(x * speed, rb.linearVelocity.y);
    }
}