using UnityEngine;

public class Respawnsetter : MonoBehaviour
{
    [Header("死亡時に戻るシーン")]
    public string respawnSceneName;

    [Header("リスポーン時のライフ")]
    public int respawnLife = 3;

    void Start()
    {
        if (LifeManager.Instance != null)
        {
            // 死亡したときに戻るシーンを設定
            LifeManager.Instance.SetRespawnScene(respawnSceneName);

            // 死亡して戻ったときのライフを設定
            LifeManager.Instance.SetRespawnLife(respawnLife);
        }
    }
}