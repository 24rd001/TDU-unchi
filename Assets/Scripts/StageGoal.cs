using UnityEngine;
using UnityEngine.SceneManagement;

public class StageGoal : MonoBehaviour
{
    public string earnedPoopId = "kongari";  // テスト用に適当なidを入れる

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        GameData.EarnedPoopId = earnedPoopId;
        SceneManager.LoadScene("ClearScene");
    }
}