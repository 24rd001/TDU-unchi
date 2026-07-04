using UnityEngine;

public class StatusManager : MonoBehaviour
{
    public static StatusManager Instance;

    public float water = 0;
    public float nutrition = 0;

    public float maxWater = 100;
    public float maxNutrition = 100;

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
}