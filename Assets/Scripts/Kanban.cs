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
}