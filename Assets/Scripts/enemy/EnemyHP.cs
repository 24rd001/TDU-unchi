using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public int maxHP = 3;

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
        // ŒoŒ±’l•t—^
        if (LevelManager.Instance != null)
        {
            LevelManager.Instance.AddExp(10);
        }

        Destroy(gameObject);
    }
}