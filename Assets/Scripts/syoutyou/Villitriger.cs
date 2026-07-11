using UnityEngine;

public class VilliTrigger : MonoBehaviour
{
    public GameObject villi;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            villi.SetActive(true);
        }
    }
}