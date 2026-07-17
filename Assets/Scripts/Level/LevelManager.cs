using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public int level = 1;

    public float currentExp = 0;
    public float requiredExp = 100;

   
    // チェックポイント保存用
    private int savedLevel = 1;
    private float savedExp = 0;
    private float savedRequiredExp = 100;

    [Header("UI")]
    public TMP_Text levelText;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (levelText != null)
        {
            levelText.text = "Lv." + level;
        }
    }

    public void AddExp(float amount)
    {
        currentExp += amount;

        while (currentExp >= requiredExp)
        {
            currentExp -= requiredExp;

            level++;

            requiredExp *= 1.2f;

            Debug.Log("レベルアップ！");
        }
    }

    // チェックポイント保存
    public void SaveCheckpoint()
    {
        savedLevel = level;
        savedExp = currentExp;
        savedRequiredExp = requiredExp;
    }

    // チェックポイント復元
    public void LoadCheckpoint()
    {
        level = savedLevel;
        currentExp = savedExp;
        requiredExp = savedRequiredExp;
    }
}