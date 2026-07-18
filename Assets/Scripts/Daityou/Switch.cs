using UnityEngine;
using UnityEngine.SceneManagement;

public class Switch : MonoBehaviour
{
    private bool activated = false;

    public Transform stageRoot;

void Start()
{
    // スイッチを押していたら消す
    if (GameManager.Instance.switchA)
    {
        Destroy(gameObject);
        return;
    }

    // 看板に触れていなければスイッチは表示しない
    if (!GameManager.Instance.showSwitch)
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