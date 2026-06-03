using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{
    [SerializeField] RectTransform highlight;   // 動く金枠
    [SerializeField] RectTransform[] buttons;   // ゲームスタート/オプション/うんち図鑑

    void Start() { if (highlight) highlight.gameObject.SetActive(false); }

    public void Hover(int i)        // マウスを乗せたボタンへ金枠を移動
    {
        if (!highlight) return;
        highlight.gameObject.SetActive(true);
        highlight.position = buttons[i].position;
    }
    public void Unhover()           // どのボタンからも離れたら消す
    {
        if (highlight) highlight.gameObject.SetActive(false);
    }

    public void StartGame()   => SceneManager.LoadScene("CharacterSelect");
    public void OpenOptions() { Debug.Log("オプション"); /* SceneManager.LoadScene("Options"); */ }
    public void OpenZukan()   { Debug.Log("うんち図鑑"); /* SceneManager.LoadScene("Zukan"); */ }
    public void QuitGame()    => Application.Quit();
}