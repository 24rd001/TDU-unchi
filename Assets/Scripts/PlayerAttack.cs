using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Projectile")]
    public GameObject[] projectilePrefabs;

    public float spawnOffset = 1f;

    public float attackCooldown = 3f;

    private PlayerController2D playerController;

    private float lastAttackTime = -999f;

    private bool isAttacking = false;

    void Start()
    {
        playerController =
            GetComponent<PlayerController2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (isAttacking)
                return;

            if (Time.time - lastAttackTime < attackCooldown)
                return;

            StartCoroutine(AttackRoutine());

            lastAttackTime = Time.time;
        }
    }

    IEnumerator AttackRoutine()
    {
        isAttacking = true;

        PlayerVisual visual =
            GetComponent<PlayerVisual>();

        float attackTime = 0.3f;

        if (visual != null)
        {
            visual.PlayAttack();

            attackTime =
                visual.GetAttackDuration();
        }

        // UŒ‚ƒ‚[ƒVƒ‡ƒ“I—¹‘Ò‚¿
        yield return new WaitForSeconds(
            attackTime
        );

        int sel = GameData.SelectedCharacter;

        if (sel >= 0 &&
            sel < projectilePrefabs.Length)
        {
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

        isAttacking = false;
    }
}