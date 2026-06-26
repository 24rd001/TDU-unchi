using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Zukan : MonoBehaviour
{
    [SerializeField] PoopData[] poops;          // 全うんちのデータ
    [SerializeField] Transform gridParent;      // Grid Layout Group の親
    [SerializeField] PoopSlot slotPrefab;       // スロットPrefab
    [SerializeField] TMP_Text countText;        // 「0 / 15」
    [SerializeField] Sprite lockedSilhouette;   // ロック中のシルエット
    [SerializeField] RectTransform highlight;   // 選択中の金枠

    [Header("詳細パネル")]
    [SerializeField] Image detailIcon;
    [SerializeField] TMP_Text nameText, rareText, katasaText, nioiText, sukkiriText, descText;

    void Start()
{
    if (highlight) highlight.gameObject.SetActive(false);

    int unlocked = 0;
    PoopSlot focusSlot = null;
    foreach (var p in poops)
    {
        PoopSlot slot = Instantiate(slotPrefab, gridParent);
        slot.Setup(p, this);
        if (ZukanProgress.IsUnlocked(p.id)) unlocked++;
        if (!string.IsNullOrEmpty(GameData.FocusPoopId) && p.id == GameData.FocusPoopId) focusSlot = slot;
    }
    if (countText) countText.text = unlocked + " / " + poops.Length;

    if (GameData.CameFromClear && focusSlot != null)
    {
        SelectSlot(focusSlot);            // 新種を自動選択＋詳細表示
        GameData.CameFromClear = false;
        GameData.FocusPoopId   = "";
    }
    else
    {
        ShowLocked();
    }
}

    // マスをクリックしたとき：金枠を移動 ＋ 詳細表示
    public void SelectSlot(PoopSlot slot)
    {
        if (highlight)
        {
            highlight.gameObject.SetActive(true);
            highlight.position = slot.transform.position;
        }
        ShowDetail(slot.Data);
    }

    public void ShowDetail(PoopData d)
    {
        if (!ZukanProgress.IsUnlocked(d.id)) { ShowLocked(); return; }
        detailIcon.sprite = d.icon;
        detailIcon.color  = Color.white;
        nameText.text    = d.poopName;
        rareText.text    = Stars(d.rare, 5);
        katasaText.text  = d.katasa;
        nioiText.text    = d.nioi;
        sukkiriText.text = Stars(d.sukkiri, 3);
        descText.text    = d.description;
    }

    void ShowLocked()
    {
        detailIcon.sprite = lockedSilhouette;
        detailIcon.color  = Color.white;
        nameText.text = rareText.text = katasaText.text =
        nioiText.text = sukkiriText.text = descText.text = "???";
    }

    string Stars(int n, int max) => new string('★', n) + new string('☆', max - n);

    public void Back() => SceneManager.LoadScene("TitleScene");
}