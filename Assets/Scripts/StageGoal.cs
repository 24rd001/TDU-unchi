using UnityEngine;
using UnityEngine.SceneManagement;

public class StageGoal : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        GameData.EarnedPoopId = NutritionJudge.Judge();
        SceneManager.LoadScene("ClearScene");
    }
}