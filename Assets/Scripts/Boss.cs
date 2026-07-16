using UnityEngine;

public class Boss : MonoBehaviour
{
    [Header("Move")]
    public float moveSpeed = 3f;
    public float moveRange = 5f;

    private Vector3 startPos;
    private int moveDir = 1;

    [Header("Triangle Move")]
    public float triangleDistance = 5f;
    public float triangleHeight = 4f;
    public float specialMoveInterval = 5f;

    private float timer = 0f;

    public GameObject blockWall;

    private enum State
    {
        Normal,
        Triangle
    }

    private State state = State.Normal;

    private Vector3[] points;
    private int index = 0;

    [Header("HP (EHP)")]
    public int EHP = 30;

    private bool enraged = false;

    void Start()
    {
        // 🔥 ここを完全固定基準にする
        startPos = transform.position;
    }

    void Update()
    {
        HandleMove();
        HandleTriangleMove();
        CheckRage();
    }

    // -------------------------
    // 通常移動
    // -------------------------
    void HandleMove()
    {
        if (state != State.Normal) return;

        float speed = moveSpeed * (enraged ? 2f : 1f);

        transform.position += Vector3.right * moveDir * speed * Time.deltaTime;

        if (transform.position.x > startPos.x + moveRange)
            moveDir = -1;
        else if (transform.position.x < startPos.x - moveRange)
            moveDir = 1;
    }

    // -------------------------
    // 三角移動
    // -------------------------
    void HandleTriangleMove()
    {
        timer += Time.deltaTime;

        if (state == State.Normal && timer >= specialMoveInterval)
        {
            timer = 0f;
            StartTriangleMove();
        }

        if (state == State.Triangle)
        {
            float speed = moveSpeed * (enraged ? 2f : 1f);

            transform.position = Vector3.MoveTowards(
                transform.position,
                points[index],
                speed * Time.deltaTime
            );

            if (Vector3.Distance(transform.position, points[index]) < 0.05f)
            {
                index++;

                if (index >= points.Length)
                {
                    state = State.Normal;
                }
            }
        }
    }

    void StartTriangleMove()
    {
        state = State.Triangle;
        index = 0;

        // 🔥 basePosじゃなく startPos基準にする
        Vector3 basePos = transform.position;

        points = new Vector3[]
        {
            basePos, // 左
            basePos + new Vector3(triangleDistance, triangleHeight, 0),   // 右上
            basePos + new Vector3(triangleDistance, -triangleHeight, 0)   // 右下
        };
    }

    // -------------------------
    // HP
    // -------------------------
    public void TakeDamage(int damage)
    {
        EHP -= damage;

        if (EHP <= 0)
        {
            Die();
        }
    }

    void CheckRage()
    {
        if (!enraged && EHP <= 15)
        {
            enraged = true;
        }
    }

    void Die()
    {
        if (blockWall != null)
        {
            Destroy(blockWall);
        }

        Destroy(gameObject);
    }
}