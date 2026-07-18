using UnityEngine;
using TMPro;

public class BossHP : MonoBehaviour
{
    [Header("HP")]
    public int maxHP = 30;
    public int currentHP;

    [Header("HP Bar")]
    public HPBar hpBar;

    [Header("Boss Name")]
    public string bossName = "ƒLƒ“ƒO";
    public TMP_Text bossNameText;

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

        if (bossNameText != null)
        {
            bossNameText.text = bossName;
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

        if (boss != null)
        {
            boss.TakeDamage(damage);
        }

        if (currentHP <= 0)
        {
            if (bossNameText != null)
            {
                bossNameText.gameObject.SetActive(false);
            }
        }
    }
}