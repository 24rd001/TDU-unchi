using UnityEngine;

public class MbornTrap : MonoBehaviour
{
    public Transform player;
    public float detectDistance = 4f;
    public float moveDistance = 3f;
    public float speed = 40f;

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

            // 到着したら停止
            if (Vector3.Distance(transform.position, attackPos) < 0.01f)
            {
                activated = false;
            }
        }
    }
}