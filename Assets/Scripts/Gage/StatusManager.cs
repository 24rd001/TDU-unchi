using UnityEngine;

public class StatusManager : MonoBehaviour
{
    public static StatusManager Instance;

    public float water = 0;
    public float nutrition = 0;   // ＝食物繊維として扱う
    public float protein = 0;     // ← 追加

    public float maxWater = 100;
    public float maxNutrition = 100;
    public float maxProtein = 100;   // ← 追加

    // 取得したアイテムの種類を記録（特殊条件判定用）
    public System.Collections.Generic.HashSet<string> takenItemNames = new System.Collections.Generic.HashSet<string>();
    public int totalItemCount = 0;
    public int pepperCount = 0;   // とうがらし専用カウント

    void Awake()
    {
        if (Instance != null && Instance != this)
    {
        Destroy(gameObject);
        return;
    }
    Instance = this;
    DontDestroyOnLoad(gameObject);
    }

    public void AddWater(float amount)
    {
        water = Mathf.Clamp(water + amount, 0, maxWater);
    }

    public void AddNutrition(float amount)
    {
        nutrition = Mathf.Clamp(nutrition + amount, 0, maxNutrition);
    }

    public void AddProtein(float amount)
    {
        protein = Mathf.Clamp(protein + amount, 0, maxProtein);
    }

    // アイテム取得を記録（判定用）
    public void RecordItem(string itemName, bool isPepper = false)
    {
        takenItemNames.Add(itemName);
        totalItemCount++;
        if (isPepper) pepperCount++;
    }

    // 食事シーンなどでリセット
    public void ResetStatus()
    {
        water = 0; nutrition = 0; protein = 0;
        takenItemNames.Clear();
        totalItemCount = 0;
        pepperCount = 0;
    }
}