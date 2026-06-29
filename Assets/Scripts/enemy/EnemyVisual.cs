using UnityEngine;

public class EnemyVisual : MonoBehaviour
{
    public Sprite[] frames;     // 敵のアニメ絵（3枚）
    public float fps = 6f;

    SpriteRenderer sr;
    float timer;
    int index;

    void Start() { sr = GetComponent<SpriteRenderer>(); }

    void Update()
    {
        if (frames == null || frames.Length == 0) return;
        timer += Time.deltaTime;
        if (timer >= 1f / fps)
        {
            timer -= 1f / fps;
            index = (index + 1) % frames.Length;
            sr.sprite = frames[index];
        }
    }
}