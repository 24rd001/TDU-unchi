using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public int maxHP = 3;

    [Header("Exp")]
    public float expReward = 10f;

    private int currentHP;

    void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (LevelManager.Instance != null)
        {
            LevelManager.Instance.AddExp(expReward);
        }

        Destroy(gameObject);
    }
}