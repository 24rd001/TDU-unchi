using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    [System.Serializable]
    public class CharacterAnim
    {
        public string name;       // ラベル（banana等。分かりやすさ用）
        public Sprite[] frames;   // 走りのコマ
    }

    public CharacterAnim[] characters;  // ★キャラ選択の Card0,1,2 と同じ順番で入れる
    public float fps = 10f;

    SpriteRenderer sr;
    Rigidbody2D rb;
    Sprite[] frames;
    float timer;
    int index;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        // ★選んだキャラのコマを取り出す
        int sel = GameData.SelectedCharacter;
        if (characters != null && sel >= 0 && sel < characters.Length)
            frames = characters[sel].frames;

        if (frames != null && frames.Length > 0)
            sr.sprite = frames[0];
    }

    void Update()
    {
        if (frames == null || frames.Length == 0) return;

        // ★止まってる時：最初のコマで固定して、アニメしない
        if (rb == null || Mathf.Abs(rb.linearVelocity.x) < 0.1f)
        {
            sr.sprite = frames[0];
            timer = 0f;
            index = 0;
            return;
        }

        // ★動いてる時だけコマ送り
        timer += Time.deltaTime;
        if (timer >= 1f / fps)
        {
            timer -= 1f / fps;
            index = (index + 1) % frames.Length;
            sr.sprite = frames[index];
        }
    }
}