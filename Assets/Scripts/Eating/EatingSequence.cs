using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class EatingSequence : MonoBehaviour
{
    [Header("たべもの（キャラ選択と同じ順：つくね、サーモン、バナナ）")]
    public Sprite[] foodSprites;

    [Header("UI参照")]
    public Image foodImage;
    public RectTransform mouthPoint;      // 口の位置
    public Image personImage;
    public Sprite personEatSprite;        // 食べるポーズ（person_eat）
    public TMP_Text chompText;
    public TMP_Text captionText;
    public RectTransform iris;            // 穴あき黒（iris_hole）
    public GameObject blackPanel;
    public TMP_Text itadakimasuText;

    [Header("設定")]
    public string nextSceneName = "MouseScene";
    public float irisStartScale = 140f;   // 穴が画面より大きい状態
    public float irisEndScale = 1.9f;     // 穴がほぼ閉じた状態

    static readonly string[] foodNames = { "バナナ", "サーモン", "つくね" };

    RectTransform foodRect;

    void Start()
    {
        foodRect = foodImage.rectTransform;

        int sel = Mathf.Clamp(GameData.SelectedCharacter, 0, foodSprites.Length - 1);
        if (foodSprites.Length > 0) foodImage.sprite = foodSprites[sel];

        chompText.gameObject.SetActive(false);
        iris.gameObject.SetActive(false);
        blackPanel.SetActive(false);
        itadakimasuText.gameObject.SetActive(false);
        if (captionText) captionText.text = "";

        StartCoroutine(Run(sel));
    }

    IEnumerator Run(int sel)
    {
        // ① テロップ「○○ を たべる」
        yield return new WaitForSeconds(0.4f);
        if (captionText) captionText.text = foodNames[sel] + " を たべる";

        // ② 食べ物が口へ（ふわっと移動しながら小さく）
        yield return new WaitForSeconds(1.0f);
        if (personEatSprite) personImage.sprite = personEatSprite;
        Tween move = foodRect.DOAnchorPos(mouthPoint.anchoredPosition, 0.7f).SetEase(Ease.OutBack, 1.05f);
        foodRect.DOScale(0.55f, 0.7f).SetEase(Ease.OutQuad);
        yield return move.WaitForCompletion();

        // ③ 口の中へ（消える）
        Tween shrink = foodRect.DOScale(0f, 0.35f).SetEase(Ease.InBack, 1.5f);
        yield return shrink.WaitForCompletion();

        // ④ もぐもぐ → ごくん！
        yield return Pop("もぐもぐ");
        yield return new WaitForSeconds(0.5f);
        yield return Pop("ごくん！");
        yield return new WaitForSeconds(0.4f);

        // ⑤ アイリスアウト（口を中心に閉じる）
        iris.gameObject.SetActive(true);
        iris.localScale = Vector3.one * irisStartScale;
        Tween close = iris.DOScale(irisEndScale, 1.0f).SetEase(Ease.InQuad);
        yield return close.WaitForCompletion();
        blackPanel.SetActive(true);

        // ⑥ いただきます
        itadakimasuText.gameObject.SetActive(true);
        itadakimasuText.alpha = 0f;
        yield return itadakimasuText.DOFade(1f, 0.5f).WaitForCompletion();
        yield return new WaitForSeconds(1.5f);

        // ⑦ 口ステージへ
        SceneManager.LoadScene(nextSceneName);
    }

    IEnumerator Pop(string word)
    {
        chompText.text = word;
        chompText.gameObject.SetActive(true);
        chompText.rectTransform.localScale = Vector3.zero;
        yield return chompText.rectTransform.DOScale(1f, 0.3f).SetEase(Ease.OutBack, 2f).WaitForCompletion();
    }
}