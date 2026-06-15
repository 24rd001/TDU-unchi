using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    [SerializeField] RectTransform highlight;
    [SerializeField] RectTransform[] cards;
    [SerializeField] TMP_Text tokuchoText;
    [TextArea][SerializeField] string[] descriptions;

    int index = 0;

    void Start() => Select(0);

    public void Hover(int i)  => Select(i);   // ★ホバーで選択も確定
    public void Unhover()     { }             // ★離れても、最後に合わせたキャラを保持
    public void Select(int i) { index = i; Show(i); }  // クリックでもOK

    void Show(int i)
    {
        if (highlight) highlight.position = cards[i].position;
        tokuchoText.text = descriptions[i];
    }

    public void Confirm()
    {
        GameData.SelectedCharacter = index;
        Debug.Log("決定：" + index);
        SceneManager.LoadScene("MouseScene");
    }

    public void Back() => SceneManager.LoadScene("TitleScene");
}