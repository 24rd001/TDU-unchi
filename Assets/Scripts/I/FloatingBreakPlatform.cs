using UnityEngine;

public class FloatingBreakPlatform : MonoBehaviour
{
    [Header("浮き")]
    public float floatSpeed = 1.5f;
    public float floatHeight = 0.5f;

    [Header("縮む速度")]
    public float shrinkSpeed = 0.5f;

    private Vector3 startPos;
    private float offset;

    private bool isSlimeOn = false;

    void Start()
    {
        startPos = transform.position;
        offset = Random.Range(0f, Mathf.PI * 2f);
    }

    void Update()
    {
        // 浮き
        float y = Mathf.Sin(Time.time * floatSpeed + offset) * floatHeight;
        transform.position = startPos + new Vector3(0, y, 0);

        // スライムが乗っていたら縮む
        if (isSlimeOn)
        {
            transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;

            if (transform.localScale.x <= 0.1f)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // スライムだけ反応
        if (col.gameObject.CompareTag("Slime"))
        {
            isSlimeOn = true;
        }

        // プレイヤーはそのまま乗れる
        if (col.gameObject.CompareTag("Player"))
        {
            col.transform.SetParent(transform);
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Slime"))
        {
            isSlimeOn = false;
        }

        if (col.gameObject.CompareTag("Player"))
        {
            col.transform.SetParent(null);
        }
    }
}