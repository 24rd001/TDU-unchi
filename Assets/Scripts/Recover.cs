using UnityEngine;

public class Recover : MonoBehaviour
{
    public int healAmount = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LifeManager.Instance.AddLife(healAmount);
            Destroy(gameObject);
        }
    }
}