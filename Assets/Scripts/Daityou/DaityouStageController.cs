using System.Collections;
using UnityEngine;

public class DaityouStageController : MonoBehaviour
{
    [Header("Spawn Points")]

    // ‡@‰‰ñ
    public Transform firstSpawnPoint;

    // ‡A‰ñ“]‘O‚Å–ß‚Á‚Ä‚«‚½
    public Transform respawnBeforeRotate;

    // ‡B‰ñ“]ƒCƒxƒ“ƒg’¼Œã
    public Transform respawnAfterRotate;

    // ‡C‰ñ“]Œã‚Å–ß‚Á‚Ä‚«‚½
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

        // ‡@ ‰‰ñ“üê
        if (GameManager.Instance.firstEnterDaityou)
        {
            player.transform.position =
                firstSpawnPoint.position;

            GameManager.Instance.firstEnterDaityou = false;

            Debug.Log("‰‰ñƒXƒ|[ƒ“");
        }
        // ‡B ‰ñ“]ƒCƒxƒ“ƒg’¼Œã
        else if (GameManager.Instance.justRotatedDaityou)
        {
            player.transform.position =
                respawnAfterRotate.position;

            GameManager.Instance.justRotatedDaityou = false;

            Debug.Log("‰ñ“]’¼ŒãƒXƒ|[ƒ“");
        }
        // ‡C ‰ñ“]Œã‚É–ß‚Á‚Ä‚«‚½
        else if (GameManager.Instance.daityouRotation == 0f)
        {
            player.transform.position =
                respawnAfterRotateReturn.position;

            Debug.Log("‰ñ“]ŒãƒŠƒXƒ|[ƒ“");
        }
        // ‡A ‰ñ“]‘O‚É–ß‚Á‚Ä‚«‚½
        else
        {
            player.transform.position =
                respawnBeforeRotate.position;

            Debug.Log("‰ñ“]‘OƒŠƒXƒ|[ƒ“");
        }
    }
}