using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [Header("HP")]
    public int maxHP = 30;
    public int currentHP;

    [Header("HP Bar")]
    public HPBar hpBar;

    private Boss boss;

    void Start()
    {
        boss = GetComponent<Boss>();

        if (boss != null)
        {
            maxHP = boss.EHP;
        }

        currentHP = maxHP;

        if (hpBar != null)
        {
            hpBar.maxHP = maxHP;
            hpBar.SetHP(currentHP);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);

        if (hpBar != null)
        {
            hpBar.SetHP(currentHP);
        }

        // Boss.cs‚ÌEHP‚àŒ¸‚ç‚·
        if (boss != null)
        {
            boss.TakeDamage(damage);
        }
    }
}