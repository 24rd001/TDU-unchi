using UnityEngine;

public class BossBullet : MonoBehaviour
{
    private Vector2 direction;
    private float speed;

    public void Initialize(Vector2 dir, float bulletSpeed)
    {
        direction = dir;
        speed = bulletSpeed;
    }

    void Update()
    {
        transform.Translate(
            direction * speed * Time.deltaTime,
            Space.World
        );
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LifeManager.Instance.Damage(1);
            Destroy(gameObject);
        }

        if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}