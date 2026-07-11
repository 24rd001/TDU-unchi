using UnityEngine;

public class VilliAppear : MonoBehaviour
{
    public Transform player;

    public float detectDistance = 4f;
    public float moveSpeed = 8f;

    // ‰æ–Êã‚Ö‚Ç‚ê‚­‚ç‚¢‰B‚·‚©
    public float hiddenHeight = 10f;

    private Vector3 appearPosition;
    private Vector3 hiddenPosition;

    private bool activated = false;

    void Start()
    {
        // –{—ˆ‚ÌˆÊ’u‚ğ•Û‘¶
        appearPosition = transform.position;

        // ã‚Ì‰æ–ÊŠO‚ÖˆÚ“®
        hiddenPosition =
            appearPosition + Vector3.up * hiddenHeight;

        transform.position = hiddenPosition;
    }

    void Update()
    {
        if (!activated)
        {
            float distance =
                Vector2.Distance(
                    player.position,
                    appearPosition
                );

            if (distance <= detectDistance)
            {
                activated = true;
            }
        }

        if (activated)
        {
            transform.position =
                Vector3.MoveTowards(
                    transform.position,
                    appearPosition,
                    moveSpeed * Time.deltaTime
                );
        }
    }
}