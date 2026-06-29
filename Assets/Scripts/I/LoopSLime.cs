using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class LoopSlime : MonoBehaviour
{
    public float jumpPower = 10f;
    public float randomX = 1f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Jump();   // 最初にジャンプ
    }

    void Jump()
    {
        float x = Random.Range(-randomX, randomX);
        rb.linearVelocity = new Vector2(x, jumpPower);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Acid"))
        {
            Jump();   // 胃酸に触れたら再びジャンプ
        }
    }
}