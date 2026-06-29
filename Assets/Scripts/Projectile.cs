using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector2 direction;
    private float speed;

    private Vector2 startPosition;

    public float maxDistance = 3f;


    public void Initialize(Vector2 dir, float spd)
    {
        direction = dir;
        speed = spd;

        // 弾を出した瞬間の位置を保存
        startPosition = transform.position;
    }


    void Update()
    {
        transform.Translate(
            direction * speed * Time.deltaTime
        );


        // 発射地点から3マス以上離れたら削除
        float distance =
            Vector2.Distance(startPosition, transform.position);


        if(distance >= maxDistance)
        {
            Destroy(gameObject);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}