using UnityEngine;

public class Switch : MonoBehaviour
{
    private bool activated = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        // すでに作動済みなら何もしない
        if (activated) return;

        // プレイヤーが触れた場合
        if (other.CompareTag("Player"))
        {
            activated = true;

            // スイッチON
            GameManager.Instance.switchA = true;

            // スイッチを消す
            Destroy(gameObject);
        }
    }
}