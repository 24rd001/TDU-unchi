using UnityEngine;
using UnityEngine.SceneManagement;

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

    private string uniqueId;

    void Awake()
    {
        // シーン名＋座標からこのアイテム固有のIDを自動生成
        Vector3 pos = transform.position;
        uniqueId = $"{SceneManager.GetActiveScene().name}_{pos.x:F2}_{pos.y:F2}_{itemName}";

        // すでに取得済みなら、出現させずに消す
        if (CollectedItemsManager.Instance != null && CollectedItemsManager.Instance.IsCollected(uniqueId))
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        StatusManager.Instance.AddWater(waterAmount);
        StatusManager.Instance.AddNutrition(nutritionAmount);
        StatusManager.Instance.AddProtein(proteinAmount);
        StatusManager.Instance.RecordItem(itemName, isPepper);

        if (LevelManager.Instance != null)
            LevelManager.Instance.AddExp(expValue);

        if (CollectedItemsManager.Instance != null)
            CollectedItemsManager.Instance.MarkCollected(uniqueId);

        Destroy(gameObject);
    }
}