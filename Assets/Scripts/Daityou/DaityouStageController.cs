using System.Collections;
using UnityEngine;

public class DaityouStageController : MonoBehaviour
{
    [Header("Spawn Point")]
    public Transform firstSpawnPoint;

    [Header("Respawn Point")]
    public Transform respawnPointNormal;
    public Transform respawnPointRotated;

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

        // 初回のみ
        if (GameManager.Instance.firstEnterDaityou)
        {
            player.transform.position =
                firstSpawnPoint.position;

            GameManager.Instance.firstEnterDaityou = false;

            Debug.Log("初回スポーン");
        }
        else
        {
            if (GameManager.Instance.daityouRotation == -90f)
            {
                player.transform.position =
                    respawnPointNormal.position;

                Debug.Log("Normalへ移動");
            }
            else
            {
                player.transform.position =
                    respawnPointRotated.position;

                Debug.Log("Rotatedへ移動");
            }
        }

        Debug.Log(
            "Player座標 : " +
            player.transform.position
        );
    }
}