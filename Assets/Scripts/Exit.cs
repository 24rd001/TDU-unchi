using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    [Header("移動設定")]
    public float moveSpeed = 2f;
    public float waitTime = 1.0f;

    [Header("移動先シーン名")]
    public string nextSceneName;

    private bool activated = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (activated) return;

        if (other.CompareTag("Player"))
        {
            activated = true;

            StartCoroutine(ExitSequence(other.gameObject));
        }
    }

    IEnumerator ExitSequence(GameObject player)
    {
        PlayerController2D controller = player.GetComponent<PlayerController2D>();
        PlayerAttack attack = player.GetComponent<PlayerAttack>();
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();

        if (controller != null)
            controller.enabled = false;

        if (attack != null)
            attack.enabled = false;

        if (rb != null)
            rb.linearVelocity = Vector2.zero;

        while (Vector2.Distance(player.transform.position, transform.position) > 0.05f)
        {
            player.transform.position = Vector2.MoveTowards(
                player.transform.position,
                transform.position,
                moveSpeed * Time.deltaTime
            );

            yield return null;
        }

        yield return new WaitForSeconds(waitTime);

        // ここを追加：うんちの種類を判定してからシーン切り替え
        GameData.EarnedPoopId = NutritionJudge.Judge();

        SceneManager.LoadScene(nextSceneName);
    }
}