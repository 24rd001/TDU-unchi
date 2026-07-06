using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Projectile")]
    public GameObject projectilePrefab;
    public float projectileSpeed = 15f;
    public float spawnOffset = 1f;

    private PlayerController2D playerController;
    private float lastAttackTime = -999f;
    public float attackCooldown = 3f;

    void Start()
    {
        playerController = GetComponent<PlayerController2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (Time.time - lastAttackTime < attackCooldown)
                return;

            Attack();
            lastAttackTime = Time.time;
        }
    }

    void Attack()
    {
        Vector2 direction;

        if (playerController.facingRight)
            direction = Vector2.right;
        else
            direction = Vector2.left;

        Vector2 spawnPos =
            (Vector2)transform.position + direction * spawnOffset;

        GameObject obj = Instantiate(
            projectilePrefab,
            spawnPos,
            Quaternion.identity
        );

        Projectile projectile = obj.GetComponent<Projectile>();

        if (projectile != null)
        {
            projectile.Initialize(direction, projectileSpeed);
        }
    }
}