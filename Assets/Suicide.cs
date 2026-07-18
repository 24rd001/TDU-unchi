using UnityEngine;

public class Suicide : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (LifeManager.Instance != null)
            {
                LifeManager.Instance.Damage(3);
            }
        }
    }
}