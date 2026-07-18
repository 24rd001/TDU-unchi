using UnityEngine;
using UnityEngine.SceneManagement;

public class Switch : MonoBehaviour
{
    private bool activated = false;

    public Transform stageRoot;

    void Start()
    {
        if (GameManager.Instance.switchA)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (activated) return;

        if (other.CompareTag("Player"))
        {
            activated = true;

            GameManager.Instance.switchA = true;
            GameManager.Instance.daityouRotation = 0f;
            GameManager.Instance.justRotatedDaityou = true;   // ← 追加

            stageRoot.rotation =
                Quaternion.Euler(0f, 0f, GameManager.Instance.daityouRotation);

            SceneManager.LoadScene("WakeUpScene");
        }
    }
}