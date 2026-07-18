using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // スイッチを押したか
    public bool switchA = false;

    // 大腸ステージの回転角度
    public float daityouRotation = -90f;

    // 大腸に初めて入った時だけtrue
    public bool firstEnterDaityou = true;

    // スイッチで回転させた直後のリスポーン制御
    public bool justRotatedDaityou = false;

    // 大腸へ戻ったか
    public bool returnedToDaityou = false;

    // 肛門ステージの看板に触れたらtrueになる
    public bool showSwitch = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // タイトルに戻る時にゲームデータをリセット
    public void ResetGameData()
    {
        switchA = false;
        daityouRotation = -90f;
        firstEnterDaityou = true;
        justRotatedDaityou = false;
        returnedToDaityou = false;
        showSwitch = false;
    }
}