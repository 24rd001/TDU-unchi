using UnityEngine;

public class Wall : MonoBehaviour
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