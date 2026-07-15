using UnityEngine;
using UnityEngine.SceneManagement;

public class Switch : MonoBehaviour
{
    private bool activated = false;

    public Transform stageRoot;

    void Start()
    {
        // すでにスイッチ済みなら、このスイッチは無効化する（WakeUpSceneから戻ってきた場合など）
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

            stageRoot.rotation =
                Quaternion.Euler(0f, 0f, GameManager.Instance.daityouRotation);

            SceneManager.LoadScene("WakeUpScene");
        }
    }
}