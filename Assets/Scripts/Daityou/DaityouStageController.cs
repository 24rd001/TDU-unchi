using System.Collections;
using UnityEngine;

public class DaityouStageController : MonoBehaviour
{
    public Transform firstSpawnPoint;

    public Transform respawnBeforeRotate;

    public Transform respawnAfterRotate;

    public Transform respawnAfterRotateReturn;

    IEnumerator Start()
    {
        transform.rotation =
            Quaternion.Euler(
                0f,
                0f,
                GameManager.Instance.daityouRotation
            );

        yield return null;

        GameObject player =
            GameObject.FindGameObjectWithTag("Player");

        if (player == null)
            yield break;

        // 初回
        if (GameManager.Instance.firstEnterDaityou)
        {
            player.transform.position =
                firstSpawnPoint.position;

            GameManager.Instance.firstEnterDaityou = false;

            Debug.Log("初回スポーン");
        }
        // 回転イベント直後
        else if (GameManager.Instance.justRotatedDaityou)
        {
            player.transform.position =
                respawnAfterRotate.position;

            GameManager.Instance.justRotatedDaityou = false;

            Debug.Log("回転直後スポーン");
        }
        // 回転後で別シーンから戻る
        else if (
            GameManager.Instance.daityouRotation == 0f &&
            GameManager.Instance.returnedToDaityou
        )
        {
            player.transform.position =
                respawnAfterRotateReturn.position;

            GameManager.Instance.returnedToDaityou = false;

            Debug.Log("回転後戻りスポーン");
        }
        // 回転前で別シーンから戻る
        else if (
            GameManager.Instance.daityouRotation != 0f &&
            GameManager.Instance.returnedToDaityou
        )
        {
            player.transform.position =
                respawnBeforeRotate.position;

            GameManager.Instance.returnedToDaityou = false;

            Debug.Log("回転前戻りスポーン");
        }
        // 回転後死亡
        else if (GameManager.Instance.daityouRotation == 0f)
        {
            player.transform.position =
                respawnAfterRotate.position;

            Debug.Log("回転後死亡リスポーン");
        }
        // 回転前死亡
        else
        {
            player.transform.position =
                firstSpawnPoint.position;

            Debug.Log("回転前死亡リスポーン");
        }
    }
}