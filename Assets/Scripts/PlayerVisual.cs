using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    [System.Serializable]
    public class CharacterAnim
    {
        public string name;          // ラベル

        public Sprite[] runFrames;   // 走り

        public Sprite[] attackFrames; // 攻撃

        public Sprite[] deadFrames;  // 死亡
    }

    public CharacterAnim[] characters;

    public float fps = 10f;
    public float deadFps = 8f;

    SpriteRenderer sr;
    Rigidbody2D rb;

    Sprite[] runFrames;
    Sprite[] attackFrames;
    Sprite[] deadFrames;

    float timer;
    int index;

    bool isDead = false;
    bool isAttacking = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        int sel = GameData.SelectedCharacter;

        if (characters != null &&
            sel >= 0 &&
            sel < characters.Length)
        {
            runFrames = characters[sel].runFrames;
            attackFrames = characters[sel].attackFrames;
            deadFrames = characters[sel].deadFrames;
        }

        if (runFrames != null &&
            runFrames.Length > 0)
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

        if (isAttacking)
        {
            PlayAttackAnimation();
            return;
        }

        PlayRunAnimation();
    }

    void PlayRunAnimation()
    {
        if (runFrames == null ||
            runFrames.Length == 0)
            return;

        if (rb == null ||
            Mathf.Abs(rb.linearVelocity.x) < 0.1f)
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

            index =
                (index + 1) %
                runFrames.Length;

            sr.sprite = runFrames[index];
        }
    }

    void PlayAttackAnimation()
    {
        if (attackFrames == null ||
            attackFrames.Length == 0)
        {
            isAttacking = false;
            return;
        }

        timer += Time.deltaTime;

        if (timer >= 1f / fps)
        {
            timer -= 1f / fps;

            index++;

            if (index >= attackFrames.Length)
            {
                isAttacking = false;
                index = 0;
                return;
            }

            sr.sprite = attackFrames[index];
        }
    }

    void PlayDeadAnimation()
    {
        if (deadFrames == null ||
            deadFrames.Length == 0)
            return;

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
                sr.sprite =
                    deadFrames[deadFrames.Length - 1];
            }
        }
    }

    public void PlayAttack()
    {
        if (isDead) return;

        isAttacking = true;

        timer = 0f;
        index = 0;

        if (attackFrames != null &&
            attackFrames.Length > 0)
        {
            sr.sprite = attackFrames[0];
        }
    }

    public float GetAttackDuration()
    {
        if (attackFrames == null ||
            attackFrames.Length == 0)
        {
            return 0f;
        }

        return attackFrames.Length / fps;
    }

    public void PlayDeath()
    {
        isDead = true;

        timer = 0f;
        index = 0;

        if (deadFrames != null &&
            deadFrames.Length > 0)
        {
            sr.sprite = deadFrames[0];
        }
    }
}