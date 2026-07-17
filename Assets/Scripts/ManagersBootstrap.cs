using UnityEngine;

public static class ManagersBootstrap
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Init()
    {
        // すでに存在していれば何もしない（TitleSceneから普通に始めた場合など）
        if (GameManager.Instance != null) return;

        SpawnIfMissing("StatusManager");
        SpawnIfMissing("GameManager");
        SpawnIfMissing("LifeManager");
        SpawnIfMissing("CollectedItemsManager");
        SpawnIfMissing("BGMManager");
        SpawnIfMissing("CanvasGroup"); // ゲージのPrefab名に合わせて変更してください
        SpawnIfMissing("LevelManager"); 
    }

    static void SpawnIfMissing(string prefabName)
    {
        GameObject prefab = Resources.Load<GameObject>(prefabName);

        if (prefab == null)
        {
            Debug.LogWarning($"[ManagersBootstrap] Resourcesフォルダに '{prefabName}' が見つかりません。");
            return;
        }

        Object.Instantiate(prefab);
    }
}