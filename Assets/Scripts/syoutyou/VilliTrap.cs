using UnityEngine;

public class VilliTrap : MonoBehaviour
{
    public float waterLoss = 10f;
    public float nutritionLoss = 10f;

    public Transform holdPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController2D player =
                other.GetComponent<PlayerController2D>();

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
