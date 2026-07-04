using UnityEngine;
using TMPro;
using DG.Tweening;

public class ZzzEffect : MonoBehaviour
{
    public TMP_Text zzzText;
    public float fadeDuration = 0.5f;

    public void ShowZzz()
    {
        if (zzzText == null) return;

        zzzText.gameObject.SetActive(true);
        zzzText.alpha = 0;

        // ふわっと出て、ゆっくり上に浮く → ループ
        Sequence seq = DOTween.Sequence();
        seq.Append(zzzText.DOFade(1f, fadeDuration).SetEase(Ease.OutQuad));
        seq.Join(zzzText.rectTransform.DOAnchorPosY(
            zzzText.rectTransform.anchoredPosition.y + 30f, 2f
        ).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo));
    }
}