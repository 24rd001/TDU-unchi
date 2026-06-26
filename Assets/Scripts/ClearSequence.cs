using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ClearSequence : MonoBehaviour
{
    [Header("データ")]
    public PoopData[] poops;
    public string testPoopId = "normal";   // 直接Playテスト用（EarnedPoopIdが空ならコレを使う）

    [Header("演出オブジェクト")]
    public RectTransform fallPoop;
    public Image         fallPoopImg;
    public CanvasGroup   banner;
    public GameObject    splashText;
    public RectTransform card;
    public CanvasGroup   cardGroup;
    public GameObject    newStamp;
    public GameObject    buttons;
    public RectTransform shakeRoot;

    [Header("カードの中身")]
    public Image    cardIcon;
    public TMP_Text nameText, rareText, katasaText, nioiText, sukkiriText;

    string id; bool isNew;
    Vector2 poopRest, cardShown;

    void Start()
    {
        id    = string.IsNullOrEmpty(GameData.EarnedPoopId) ? testPoopId : GameData.EarnedPoopId;
        isNew = !ZukanProgress.IsUnlocked(id);

        poopRest  = fallPoop.anchoredPosition;
        cardShown = card.anchoredPosition;

        banner.alpha = 0;
        cardGroup.alpha = 0;
        card.anchoredPosition = cardShown + new Vector2(0, -800);
        if (fallPoopImg) SetA(fallPoopImg, 0);
        if (splashText) splashText.SetActive(false);
        if (newStamp)   newStamp.SetActive(false);
        if (buttons)    buttons.SetActive(false);

        StartCoroutine(Run());
    }

    IEnumerator Run()
    {
        yield return new WaitForSeconds(0.3f);
        yield return Fade(banner, 1f, 0.3f);

        if (fallPoopImg) SetA(fallPoopImg, 1);
        Vector2 top = poopRest + new Vector2(0, 900);
        yield return Move(fallPoop, top, poopRest, 0.7f, true);

        if (splashText) splashText.SetActive(true);
        Shake();
        yield return Squash(fallPoop, 0.14f);
        yield return new WaitForSeconds(0.5f);
        if (splashText) splashText.SetActive(false);

        ZukanProgress.Unlock(id);

        var data = System.Array.Find(poops, p => p != null && p.id == id);
        if (data)
        {
            if (cardIcon)    cardIcon.sprite = data.icon;
            if (nameText)    nameText.text   = data.poopName;
            if (rareText)    rareText.text   = "レアド　"   + Stars(data.rare, 5);
            if (katasaText)  katasaText.text = "かたさ　"   + data.katasa;
            if (nioiText)    nioiText.text   = "におい　"   + data.nioi;
            if (sukkiriText) sukkiriText.text= "すっきり　" + Stars(data.sukkiri, 3);
        }

        Shake();
        StartCoroutine(Fade(cardGroup, 1f, 0.2f));
        yield return Move(card, card.anchoredPosition, cardShown, 0.3f, false);

        if (isNew && newStamp) { yield return new WaitForSeconds(0.2f); newStamp.SetActive(true); Shake(); }

        yield return new WaitForSeconds(0.3f);
        if (buttons) buttons.SetActive(true);
    }

    public void OnZukan()
    {
        GameData.FocusPoopId   = id;
        GameData.CameFromClear = true;
        SceneManager.LoadScene("Zukan");
    }
    public void OnTitle() => SceneManager.LoadScene("TitleScene");

    string Stars(int n,int max)=>new string('★',Mathf.Clamp(n,0,max))+new string('☆',Mathf.Max(0,max-n));
    void SetA(Image i,float a){var c=i.color;c.a=a;i.color=c;}
    IEnumerator Fade(CanvasGroup g,float to,float t){float s=g.alpha,e=0;while(e<t){e+=Time.deltaTime;g.alpha=Mathf.Lerp(s,to,e/t);yield return null;}g.alpha=to;}
    IEnumerator Move(RectTransform r,Vector2 a,Vector2 b,float t,bool easeIn){float e=0;while(e<t){e+=Time.deltaTime;float k=e/t;k=easeIn?k*k:1-(1-k)*(1-k);r.anchoredPosition=Vector2.Lerp(a,b,k);yield return null;}r.anchoredPosition=b;}
    IEnumerator Squash(RectTransform r,float t){Vector3 b=r.localScale;float e=0;while(e<t){e+=Time.deltaTime;float k=e/t;r.localScale=new Vector3(b.x*(1+0.35f*(1-k)),b.y*(1-0.35f*(1-k)),b.z);yield return null;}r.localScale=b;}
    void Shake(){if(shakeRoot)StartCoroutine(ShakeCo());}
    IEnumerator ShakeCo(){Vector2 o=shakeRoot.anchoredPosition;for(int i=0;i<6;i++){shakeRoot.anchoredPosition=o+new Vector2(Random.Range(-6f,6f),Random.Range(-6f,6f));yield return new WaitForSeconds(0.03f);}shakeRoot.anchoredPosition=o;}
}