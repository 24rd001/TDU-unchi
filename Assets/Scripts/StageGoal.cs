using UnityEngine;
using UnityEngine.SceneManagement;

public class StageGoal : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

         var s = StatusManager.Instance;
            Debug.Log($"[判定前] water:{s.water} nutrition:{s.nutrition} protein:{s.protein} totalItems:{s.totalItemCount} species:{s.takenItemNames.Count} pepper:{s.pepperCount}");


        GameData.EarnedPoopId = NutritionJudge.Judge();
        SceneManager.LoadScene("ClearScene");
    }
}