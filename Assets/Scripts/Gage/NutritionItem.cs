using UnityEngine;

public class NutritionItem : MonoBehaviour
{
    public float value = 15;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StatusManager.Instance.AddNutrition(value);
            Destroy(gameObject);
        }
    }
}