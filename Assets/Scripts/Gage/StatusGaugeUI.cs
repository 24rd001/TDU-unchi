using UnityEngine;
using UnityEngine.UI;

public class StatusGaugeUI : MonoBehaviour
{
    public enum StatType { Water, Protein, Fiber }

    [Header("表示するパラメータ")]
    public StatType statType;

    [Header("色が付いている部分のImage（Image Type: Filled）")]
    public Image fillImage;

    void Update()
    {
        float current = 0f;
        float max = 1f;

        switch (statType)
        {
            case StatType.Water:
                current = StatusManager.Instance.water;
                max = StatusManager.Instance.maxWater;
                break;
            case StatType.Protein:
                current = StatusManager.Instance.protein;
                max = StatusManager.Instance.maxProtein;
                break;
            case StatType.Fiber:
                current = StatusManager.Instance.nutrition;
                max = StatusManager.Instance.maxNutrition;
                break;
        }

        fillImage.fillAmount = max > 0 ? Mathf.Clamp01(current / max) : 0f;
    }
}