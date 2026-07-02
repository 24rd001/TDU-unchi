using UnityEngine;

public class IsanMove : MonoBehaviour
{
    public Sprite[] frames;
    public float fps = 6f;

    SpriteRenderer sr;
    float timer;
    int index;

    public int CurrentFrame => index; 

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

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
