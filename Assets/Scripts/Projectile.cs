using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector2 direction;

    [Header("Move")]
    public float speed = 15f;

    [Header("Range")]
    public float maxDistance = 3f;

    [Header("Damage")]
    public int damage = 5;

    private Vector2 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    public void Initialize(Vector2 dir)
    {
        direction = dir;

        Vector3 scale = transform.localScale;

        if (dir.x < 0)
        {
            scale.x = -Mathf.Abs(scale.x);
        }
        else
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        float distance =
            Vector2.Distance(
                startPosition,
                transform.position
            );

        if (distance >= maxDistance)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        BossHP bossHP =
            other.GetComponent<BossHP>();

        if (bossHP != null)
        {
            bossHP.TakeDamage(damage);
            Destroy(gameObject);
            return;
        }

        EnemyHP enemyHP =
            other.GetComponent<EnemyHP>();

        if (enemyHP != null)
        {
            enemyHP.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}