using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    public static BGMManager Instance;

    [System.Serializable]
    public class SceneBGM
    {
        public string sceneName;
        public AudioClip clip;
        [Range(0f, 1f)] public float volume = 1f; // 曲ごとに音量差を調整できるように
    }

    public SceneBGM[] sceneBGMs;
    public float fadeDuration = 0.5f;

    private AudioSource audioSource;
    private Coroutine fadeCoroutine;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;

        SceneManager.sceneLoaded += OnSceneLoaded;
        PlayForScene(SceneManager.GetActiveScene().name);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayForScene(scene.name);
    }

    void PlayForScene(string sceneName)
    {
        SceneBGM target = null;
        foreach (var entry in sceneBGMs)
        {
            if (entry.sceneName == sceneName)
            {
                target = entry;
                break;
            }
        }

        if (target == null)
        {
            Debug.LogWarning($"[BGMManager] シーン「{sceneName}」のBGM設定がありません。");
            if (fadeCoroutine != null) StopCoroutine(fadeCoroutine);
            fadeCoroutine = StartCoroutine(FadeOutAndStop());
            return;
        }

        if (audioSource.clip == target.clip && audioSource.isPlaying) return;

        if (fadeCoroutine != null) StopCoroutine(fadeCoroutine);
        fadeCoroutine = StartCoroutine(FadeToNewClip(target));
    }

    IEnumerator FadeToNewClip(SceneBGM target)
    {
        yield return FadeVolume(audioSource.volume, 0f);
        audioSource.clip = target.clip;
        audioSource.Play();
        yield return FadeVolume(0f, target.volume);
    }

    IEnumerator FadeOutAndStop()
    {
        yield return FadeVolume(audioSource.volume, 0f);
        audioSource.Stop();
    }

    IEnumerator FadeVolume(float from, float to)
    {
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(from, to, t / fadeDuration);
            yield return null;
        }
        audioSource.volume = to;
    }

    void OnDestroy()
    {
        if (Instance == this)
            SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}