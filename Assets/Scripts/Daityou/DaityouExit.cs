using UnityEngine;

public class DaityouExit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        GameManager.Instance.returnedToDaityou = true;

        Debug.Log("‘å’°‚©‚ço‚½");
    }
}