using UnityEngine;

public class WaterItem : MonoBehaviour
{
    public float value = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StatusManager.Instance.AddWater(value);
            Destroy(gameObject);
        }
    }
}