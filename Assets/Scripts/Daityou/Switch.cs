using UnityEngine;

public class Switch : MonoBehaviour
{
    private bool activated = false;

    public Transform stageRoot;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (activated) return;

        if (other.CompareTag("Player"))
        {
            activated = true;

            // スイッチON
            GameManager.Instance.switchA = true;
            // 0度にする
            GameManager.Instance.daityouRotation = 0f;

            stageRoot.rotation =
                Quaternion.Euler(
                    0f,
                    0f,
                    GameManager.Instance.daityouRotation
                );

            Destroy(gameObject);
        }
    }
}