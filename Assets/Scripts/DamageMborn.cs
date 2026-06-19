using UnityEngine;

public class DamageMborn : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Mborn"))
        {
            LifeManager.Instance.Damage(damage);
        }
    }
}