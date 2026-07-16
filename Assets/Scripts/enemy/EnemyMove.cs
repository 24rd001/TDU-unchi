using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float moveRange = 3f;

    private Vector3 startPos;
    private int moveDir = 1;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.position +=
            Vector3.right *
            moveDir *
            moveSpeed *
            Time.deltaTime;

        if (transform.position.x > startPos.x + moveRange)
        {
            moveDir = -1;
        }
        else if (transform.position.x < startPos.x - moveRange)
        {
            moveDir = 1;
        }

        Flip();
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;

        if (moveDir > 0)
        {
            scale.x = -Mathf.Abs(scale.x);
        }
        else
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;
    }
}