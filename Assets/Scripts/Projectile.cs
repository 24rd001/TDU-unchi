using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector2 direction;
    private float speed;

    private Vector2 startPosition;

    public float maxDistance = 3f;

    void Start()
    {
        // 初期位置保存（Instantiate直後の位置）
        startPosition = transform.position;
    }

    public void Initialize(Vector2 dir, float spd)
    {
        direction = dir;
        speed = spd;

        // 🔥 見た目の向きを確実に反転（flipXは使わない）
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
        // 移動
        transform.Translate(direction * speed * Time.deltaTime);

        // 距離チェック（3マスで消える）
        float distance = Vector2.Distance(startPosition, transform.position);

        if (distance >= maxDistance)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}