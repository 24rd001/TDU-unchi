using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{
    [SerializeField] RectTransform highlight;
    [SerializeField] RectTransform[] buttons;

    void Start() { if (highlight) highlight.gameObject.SetActive(false); }

    public void Hover(int i)
    {
        if (!highlight) return;
        highlight.gameObject.SetActive(true);
        highlight.position = buttons[i].position;
    }
    public void Unhover()
    {
        if (highlight) highlight.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        if (CollectedItemsManager.Instance != null)
            CollectedItemsManager.Instance.ResetAll();

        SceneManager.LoadScene("CharacterSelect");
    }

    public void OpenOptions() => SceneManager.LoadScene("OperationScene");
    public void OpenZukan() => SceneManager.LoadScene("Zukan");
    public void QuitGame() => Application.Quit();
}