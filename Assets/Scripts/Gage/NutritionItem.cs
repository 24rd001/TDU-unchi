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

    [Header("効果音")]
    public AudioClip pickupSound;   // ← 追加

    private string uniqueId;

    void Awake()
    {
        Vector3 pos = transform.position;
        uniqueId = $"{SceneManager.GetActiveScene().name}_{pos.x:F2}_{pos.y:F2}_{itemName}";

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

        if (pickupSound != null)
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);   // ← 追加

        Destroy(gameObject);
    }
}