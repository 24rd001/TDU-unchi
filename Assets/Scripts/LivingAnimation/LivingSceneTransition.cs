using UnityEngine;
using UnityEngine.SceneManagement;

public class LivingSceneTransition : MonoBehaviour
{
    private const string NextSceneName = "DaityouScene";

    [SerializeField] private LieDownAnimation lieDownAnimation;
    [SerializeField] private float sleepDuration = 3f; // Zzzを見せておく時間（秒）

    void Start()
    {
        if (lieDownAnimation == null)
            lieDownAnimation = FindObjectOfType<LieDownAnimation>();

        lieDownAnimation.OnComplete += HandleAnimationComplete;
    }

    void OnDestroy()
    {
        if (lieDownAnimation != null)
            lieDownAnimation.OnComplete -= HandleAnimationComplete;
    }

    private void HandleAnimationComplete()
    {
        // 寝転ぶ動作が終わった直後ではなく、Zzzを少し見せてから遷移する
        Invoke(nameof(LoadNextScene), sleepDuration);
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(NextSceneName);
    }
}