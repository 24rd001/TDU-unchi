using System.Collections;
using UnityEngine;

public class DaityouStageController : MonoBehaviour
{
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

        if (player != null)
        {
            if (GameManager.Instance.daityouRotation == -90f)
            {
                player.transform.position =
                    respawnPointNormal.position;

                Debug.Log("NormalÇ÷à⁄ìÆ");
            }
            else
            {
                player.transform.position =
                    respawnPointRotated.position;

                Debug.Log("RotatedÇ÷à⁄ìÆ");
            }

            Debug.Log("Playerç¿ïW:" +
                      player.transform.position);
        }
    }
}