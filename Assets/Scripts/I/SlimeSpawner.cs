using UnityEngine;

public class SlimeSpawner : MonoBehaviour
{
    public GameObject slimePrefab;
    public Transform player;

    public float spawnInterval = 2f;
    public float slimeSpeed = 5f;
    public float lifeTime = 2f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnSlime), 1f, spawnInterval);
    }

    void SpawnSlime()
    {
        GameObject slime = Instantiate(slimePrefab, transform.position, Quaternion.identity);

        Rigidbody2D rb = slime.GetComponent<Rigidbody2D>();

        // プレイヤー方向へ飛ばす
        Vector2 dir = (player.position - transform.position).normalized;
        rb.linearVelocity = dir * slimeSpeed;

        Destroy(slime, lifeTime);
    }
}