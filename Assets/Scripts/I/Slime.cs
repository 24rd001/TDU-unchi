using UnityEngine;

public class Slime : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D coliision)
    {
        if (coliision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}