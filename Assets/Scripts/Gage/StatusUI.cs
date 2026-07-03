using UnityEngine;
using UnityEngine.UI;

public class StatusUI : MonoBehaviour
{
    public Slider waterSlider;
    public Slider nutritionSlider;

    void Update()
    {
        waterSlider.maxValue = StatusManager.Instance.maxWater;
        waterSlider.value = StatusManager.Instance.water;

        nutritionSlider.maxValue = StatusManager.Instance.maxNutrition;
        nutritionSlider.value = StatusManager.Instance.nutrition;
    }
}