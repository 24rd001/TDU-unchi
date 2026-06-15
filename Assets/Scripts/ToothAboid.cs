using UnityEngine;

public class ToothAvoid : MonoBehaviour
{
    public Transform player;

    [Header("Detect")]
    public float detectRange = 3f;

    [Header("Move")]
    public Vector3 avoidOffset = new Vector3(0, 1.5f, 0);
    public float moveSpeed = 5f;

    private Vector3 startLocalPos;

    void Start()
    {
        startLocalPos = transform.localPosition;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        Vector3 targetLocalPos = startLocalPos;

        if (distance <= detectRange)
        {
            targetLocalPos = startLocalPos + avoidOffset;
        }

        transform.localPosition = Vector3.Lerp(
            transform.localPosition,
            targetLocalPos,
            moveSpeed * Time.deltaTime
        );
    }
}