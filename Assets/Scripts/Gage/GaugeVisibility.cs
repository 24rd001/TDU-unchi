using UnityEngine;
using UnityEngine.SceneManagement;

public class GaugeVisibility : MonoBehaviour
{
    public static GaugeVisibility Instance;

    [Header("ここでは表示しないシーン名（Titleなど）")]
    public string[] hiddenInScenes = { "TitleScene" };

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;

        // 起動直後（Title）にも一度反映しておく
        UpdateVisibility(SceneManager.GetActiveScene().name);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateVisibility(scene.name);
    }

    void UpdateVisibility(string sceneName)
    {
        bool shouldHide = false;
        foreach (var name in hiddenInScenes)
        {
            if (sceneName == name)
            {
                shouldHide = true;
                break;
            }
        }
        gameObject.SetActive(!shouldHide);
    }

    void OnDestroy()
    {
        if (Instance == this)
            SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}