using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    [System.Serializable]
    public class CharacterAnim
    {
        public string name;          // ラベル
        public Sprite[] runFrames;   // 走り・通常アニメ
        public Sprite[] deadFrames;  // 死亡アニメ
    }

    public CharacterAnim[] characters;
    public float fps = 10f;
    public float deadFps = 8f;

    SpriteRenderer sr;
    Rigidbody2D rb;

    Sprite[] runFrames;
    Sprite[] deadFrames;

    float timer;
    int index;

    bool isDead = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        int sel = GameData.SelectedCharacter;

        if (characters != null && sel >= 0 && sel < characters.Length)
        {
            runFrames = characters[sel].runFrames;
            deadFrames = characters[sel].deadFrames;
        }

        if (runFrames != null && runFrames.Length > 0)
        {
            sr.sprite = runFrames[0];
        }
    }

    void Update()
    {
        if (isDead)
        {
            PlayDeadAnimation();
            return;
        }

        PlayRunAnimation();
    }

    void PlayRunAnimation()
    {
        if (runFrames == null || runFrames.Length == 0) return;

        if (rb == null || Mathf.Abs(rb.linearVelocity.x) < 0.1f)
        {
            sr.sprite = runFrames[0];
            timer = 0f;
            index = 0;
            return;
        }

        timer += Time.deltaTime;

        if (timer >= 1f / fps)
        {
            timer -= 1f / fps;
            index = (index + 1) % runFrames.Length;
            sr.sprite = runFrames[index];
        }
    }

    void PlayDeadAnimation()
    {
        if (deadFrames == null || deadFrames.Length == 0) return;

        timer += Time.deltaTime;

        if (timer >= 1f / deadFps)
        {
            timer -= 1f / deadFps;

            if (index < deadFrames.Length)
            {
                sr.sprite = deadFrames[index];
                index++;
            }
            else
            {
                // 最後の死亡コマで止める
                sr.sprite = deadFrames[deadFrames.Length - 1];
            }
        }
    }

    public void PlayDeath()
    {
        isDead = true;
        timer = 0f;
        index = 0;

        if (deadFrames != null && deadFrames.Length > 0)
        {
            sr.sprite = deadFrames[0];
        }
    }
}