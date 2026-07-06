using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Projectile")]
    public GameObject projectilePrefab;
    public float projectileSpeed = 15f;
    public float spawnOffset = 1f;

    [Header("Attack Cooldown")]
    public float attackCooldown = 3f; // 3秒

    private float lastAttackTime = -999f;

    private PlayerController2D playerController;


    void Start()
    {
        playerController = GetComponent<PlayerController2D>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            // クールタイム中なら攻撃しない
            if (Time.time - lastAttackTime < attackCooldown)
            {
                return;
            }

            Attack();

            // 攻撃した時間を記録
            lastAttackTime = Time.time;
        }
    }


    void Attack()
    {
        Vector2 direction;


        if (playerController.facingRight)
        {
            direction = Vector2.right;
        }
        else
        {
            direction = Vector2.left;
        }


        Vector2 spawnPos =
            (Vector2)transform.position + direction * spawnOffset;


        GameObject obj = Instantiate(
            projectilePrefab,
            spawnPos,
            Quaternion.identity
        );


        Projectile projectile =
            obj.GetComponent<Projectile>();


        if (projectile != null)
        {
            projectile.Initialize(direction, projectileSpeed);
        }
    }
}