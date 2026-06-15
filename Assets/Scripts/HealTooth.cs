using UnityEngine;

public class HealTooth : MonoBehaviour
{
    public int healAmount = 1;
    private bool hasHealed = false;

    public void TryHeal(Collider2D other)
    {
        if (hasHealed) return;
        if (!other.CompareTag("Player")) return;
        if (LifeManager.Instance == null) return;

        LifeManager.Instance.AddLife(healAmount);
        hasHealed = true;

        
    }
}