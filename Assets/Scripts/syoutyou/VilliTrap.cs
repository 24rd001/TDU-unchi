using UnityEngine;

public class VilliTrap : MonoBehaviour
{
    public float waterLoss = 10f;
    public float nutritionLoss = 10f;

    public Transform holdPoint;

    private bool activated = false; // ← 追加

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (activated) return; // ← 追加：一度反応したら無視する

        if (other.CompareTag("Player"))
        {
            activated = true; // ← 追加

            PlayerController2D player = other.GetComponent<PlayerController2D>();

            if (player != null)
            {
                Vector2 trapPos;

                if (holdPoint != null)
                {
                    trapPos = holdPoint.position;
                }
                else
                {
                    trapPos = other.transform.position;
                }

                player.StartTrap(trapPos);

                StatusManager.Instance.AddWater(-waterLoss);
                StatusManager.Instance.AddNutrition(-nutritionLoss);
            }
        }
    }
}