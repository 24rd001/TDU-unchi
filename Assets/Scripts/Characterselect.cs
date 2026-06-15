using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    [SerializeField] RectTransform highlight;          // 金枠
    [SerializeField] RectTransform[] cards;            // Card0〜2
    [SerializeField] TMP_Text tokuchoText;             // とくちょう欄
    [TextArea][SerializeField] string[] descriptions;  // 説明文(3個)

    int index = 0;

    void Start() => Show(0);

    public void Hover(int i)  => Show(i);        // ★ホバーで金枠も文章も動く
    public void Unhover()     => Show(index);    // 離れたら選択中に戻る
    public void Select(int i) { index = i; Show(i); } // クリックで選択を確定

    void Show(int i)
    {
        if (highlight) highlight.position = cards[i].position; // ★金枠を移動
        tokuchoText.text = descriptions[i];                    // 文章を更新
    }

    public void Confirm()
    {
        GameData.SelectedCharacter = index;
        Debug.Log("決定：" + index);
        SceneManager.LoadScene("MouseScene"); // GameSceneを作ったら有効化
    }

    public void Back() => SceneManager.LoadScene("TitleScene"); // ★もどる→タイトル
}