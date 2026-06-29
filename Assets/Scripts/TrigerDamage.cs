using UnityEngine;

public class TrigerDamage : MonoBehaviour
{
    public int damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LifeManager.Instance.Damage(damage);
        }
    }
}