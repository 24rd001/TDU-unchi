using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
    public static LifeManager Instance;

    [Header("Life")]
    public int maxLife = 5;

    // 現在のライフ
    public int currentLife = 1;

    [Header("ゲーム開始時のライフ")]
    [SerializeField]
    private int initialLife = 1;

    [Header("Respawn")]
    public string respawnSceneName;

    // 死亡後に戻ったときのライフ
    private int respawnLife = 3;

    public float respawnDelay = 2f;

    private bool isDead = false;

    [Header("Death Count")]
    public int deathCount = 0;


    void Awake()
    {
        // すでにLifeManagerが存在する場合
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        // 最初のLifeManagerを保存
        Instance = this;

        // シーンを移動しても残す
        DontDestroyOnLoad(gameObject);

        // ゲーム開始時だけ初期ライフにする
        currentLife = initialLife;
    }


    // リスポーン先の設定

    public void SetRespawnScene(string sceneName)
    {
        respawnSceneName = sceneName;
    }


    // =========================
    // リスポーン時のライフ設定
    // =========================

    public void SetRespawnLife(int life)
    {
        respawnLife = life;
    }


    // ダメージ

    public void Damage(int amount)
    {
        if (isDead) return;

        currentLife -= amount;

        if (currentLife <= 0)
        {
            currentLife = 0;

            StartCoroutine(DeathAndRespawn());
        }
    }


    // 回復

    public void AddLife(int amount)
    {
        currentLife += amount;

        // 最大ライフ5を超えない
        if (currentLife > maxLife)
        {
            currentLife = maxLife;
        }
    }


    // 死亡してリスポーン

    IEnumerator DeathAndRespawn()
    {
        isDead = true;

        // 死亡回数を加算
        deathCount++;

        // プレイヤーの操作を停止し、
        // 死亡アニメーションを再生
        PlayerDeath playerDeath =
            FindFirstObjectByType<PlayerDeath>();

        if (playerDeath != null)
        {
            playerDeath.Die();
        }


        // 死亡アニメーションを見せる時間
        yield return new WaitForSeconds(respawnDelay);


        // 必要なゲーム状態をリセット
        if (GameManager.Instance != null)
        {
            GameManager.Instance.returnedToDaityou = false;
        }


        // ★ここでだけリスポーンライフに変更
        currentLife = respawnLife;

        isDead = false;


        // チェックポイントの処理
        if (LevelManager.Instance != null)
        {
            LevelManager.Instance.LoadCheckpoint();
        }


        // リスポーン先のシーンへ戻る
        SceneManager.LoadScene(respawnSceneName);
    }


    // ライフを初期状態に戻す
    public void ResetLife()
    {
        currentLife = initialLife;

        isDead = false;

        deathCount = 0;
    }
}