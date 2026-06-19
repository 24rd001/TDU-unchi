using UnityEngine;

public class DamageCandy : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Candy"))
        {
            LifeManager.Instance.Damage(damage);
        }
    }
}