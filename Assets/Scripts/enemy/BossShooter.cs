using UnityEngine;
using System.Collections;

public class BossShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    public float minInterval = 1f;
    public float maxInterval = 3f;

    public float bulletSpeed = 5f;

    void Start()
    {
        StartCoroutine(ShootRoutine());
    }

    IEnumerator ShootRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(
                Random.Range(minInterval, maxInterval));

            Shoot();
        }
    }

    void Shoot()
    {
        GameObject player =
            GameObject.FindGameObjectWithTag("Player");

        if (player == null) return;

        Vector2 dir =
            (player.transform.position - firePoint.position)
            .normalized;

        GameObject bullet =
            Instantiate(
                bulletPrefab,
                firePoint.position,
                Quaternion.identity);

        BossBullet bossBullet =
            bullet.GetComponent<BossBullet>();

        if (bossBullet != null)
        {
            bossBullet.Initialize(dir, bulletSpeed);
        }
    }
}