using UnityEngine;

public class NutritionItem : MonoBehaviour
{
    public float value = 15;
    public float expValue = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StatusManager.Instance.AddNutrition(value);

            LevelManager.Instance.AddExp(expValue);

            Destroy(gameObject);
        }
    }
}