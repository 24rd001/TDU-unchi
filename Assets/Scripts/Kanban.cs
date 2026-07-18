using UnityEngine;

public class Kanban : MonoBehaviour
{
    void Start()
    {
        if (GameManager.Instance != null &&
            GameManager.Instance.switchA)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.showSwitch = true;
        }
    }
}