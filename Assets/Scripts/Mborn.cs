using UnityEngine;

public class MbornTrap : MonoBehaviour
{
    public Transform player;

    public float detectDistance = 3f; // 発動距離
    public float moveDistance = 2f;   // 飛び出す距離
    public float speed = 15f;         // 飛び出す速さ

    private Vector3 startPos;
    private Vector3 attackPos;

    private bool activated = false;

    void Start()
    {
        startPos = transform.position;
        attackPos = startPos + Vector3.right * moveDistance;
    }

    void Update()
    {
        if (!activated &&
            Vector2.Distance(transform.position, player.position) < detectDistance)
        {
            activated = true;
        }

        if (activated)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                attackPos,
                speed * Time.deltaTime
            );
        }
    }
}