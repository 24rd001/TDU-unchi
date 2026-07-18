using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Projectile")]
    public GameObject[] projectilePrefabs;

    public float spawnOffset = 1f;

    private PlayerController2D playerController;
    private float lastAttackTime = -999f;

    public float attackCooldown = 3f;

    void Start()
    {
        playerController =
            GetComponent<PlayerController2D>();
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
        int sel = GameData.SelectedCharacter;

        if (sel < 0 ||
            sel >= projectilePrefabs.Length)
            return;

        GameObject projectilePrefab =
            projectilePrefabs[sel];

        Vector2 direction =
            playerController.facingRight
            ? Vector2.right
            : Vector2.left;

        Vector2 spawnPos =
            (Vector2)transform.position +
            direction * spawnOffset;

        GameObject obj = Instantiate(
            projectilePrefab,
            spawnPos,
            Quaternion.identity
        );

        Projectile projectile =
            obj.GetComponent<Projectile>();

        if (projectile != null)
        {
            projectile.Initialize(direction);
        }
    }
}