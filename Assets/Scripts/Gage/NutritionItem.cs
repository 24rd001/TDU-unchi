using UnityEngine;

public class NutritionItem : MonoBehaviour
{
    [Header("アイテム名（判定用・重複可）")]
    public string itemName = "キャベツ";

    [Header("パラメータ変化量")]
    public float waterAmount;
    public float nutritionAmount;   // 食物繊維相当
    public float proteinAmount;

    [Header("特殊：とうがらしならチェック")]
    public bool isPepper = false;

    [Header("既存のレベルシステムと連携する場合")]
    public float expValue = 10;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        StatusManager.Instance.AddWater(waterAmount);
        StatusManager.Instance.AddNutrition(nutritionAmount);
        StatusManager.Instance.AddProtein(proteinAmount);
        StatusManager.Instance.RecordItem(itemName, isPepper);

        if (LevelManager.Instance != null)
            LevelManager.Instance.AddExp(expValue);

        Destroy(gameObject);
    }
}