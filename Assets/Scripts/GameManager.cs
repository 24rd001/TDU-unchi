using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool switchA = false;

    public float daityouRotation = -90f;

    // 大腸に初めて入った時だけtrueにしておく初期スポーン制御用
    public bool firstEnterDaityou = true;

    // スイッチで回転させた直後のリスポーン制御用
    public bool justRotatedDaityou = false;

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

    // タイトルに戻る時に大腸ギミックの状態をリセットする
    public void ResetGameData()
    {
        switchA = false;
        daityouRotation = -90f;
        firstEnterDaityou = true;
        justRotatedDaityou = false;
    }
}