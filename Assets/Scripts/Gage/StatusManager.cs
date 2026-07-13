using UnityEngine;

public class StatusManager : MonoBehaviour
{
    public static StatusManager Instance;

    public float water = 0;
    public float nutrition = 0; // 食物繊維
    public float protein = 0;

    public float maxWater = 100;
    public float maxNutrition = 100;
    public float maxProtein = 100;

    void Awake()
    {
        Instance = this;
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

    public void RecordItem(string itemName, bool isPepper)
    {
        // 図鑑（Zukan）登録などがあればここに実装
        // まだ何も無ければ空のままでOK（コンパイルは通ります）
    }
}