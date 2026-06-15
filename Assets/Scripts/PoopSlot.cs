using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;   // ★追加

public class PoopSlot : MonoBehaviour, IPointerEnterHandler   // ★IPointerEnterHandler
{
    public Image icon;
    public Sprite lockedSilhouette;
    public GameObject qmark;

    public PoopData Data { get; private set; }
    Zukan zukan;

    public void Setup(PoopData d, Zukan z)
    {
        Data = d; zukan = z;
        bool unlocked = ZukanProgress.IsUnlocked(d.id);
        icon.sprite = unlocked ? d.icon : lockedSilhouette;
        icon.color  = Color.white;
        if (qmark) qmark.SetActive(!unlocked);
    }

    // ★カーソルを乗せた瞬間に発火
    public void OnPointerEnter(PointerEventData eventData) => zukan.SelectSlot(this);

    public void OnClick() => zukan.SelectSlot(this);   // クリックでも一応動く（残しておいてOK）
}