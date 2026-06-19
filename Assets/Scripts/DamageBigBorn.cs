using UnityEngine;

public class DamageBigBorn : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LifeManager.Instance.Damage(damage);
        }
    }
}