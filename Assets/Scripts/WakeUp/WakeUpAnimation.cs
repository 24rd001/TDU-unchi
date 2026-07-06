using System;
using UnityEngine;
using DG.Tweening;

public class WakeUpAnimation : MonoBehaviour
{
    [Header("対象（UIのImage）")]
    public RectTransform body;

    [Header("起き上がる量（LieDownAnimationと同じ値にする）")]
    public float lieAngle = -90f;
    public float slideX = -40f;
    public float sinkDistance = 20f;

    [Header("タイミング")]
    public float stretchTime = 0.4f;
    public float riseTime = 0.8f;
    public float settleTime = 0.2f;

    [Header("伸びの量（起きる前のうーん）")]
    public float stretchScaleX = 1.12f;
    public float stretchScaleY = 0.92f;

    [Header("自動再生")]
    public bool playOnStart = false;
    public float startDelay = 0.5f;

    [Header("ZZZ（起きたら消す）")]
    public GameObject zzzObject;

    [Header("完了イベント（シーン遷移などを登録）")]
    public UnityEngine.Events.UnityEvent onWakeUpComplete;
    public event Action OnComplete;

    Vector2 standPos;
    Vector3 standScale;
    Sequence seq;

    void Awake()
    {
        if (body == null) body = GetComponent<RectTransform>();
        standPos   = body.anchoredPosition;
        standScale = body.localScale;
    }

    void Start()
    {
        if (playOnStart)
        {
            SetLyingPose();
            Invoke(nameof(Play), startDelay);
        }
    }

    public void SetLyingPose()
    {
        body.anchoredPosition = standPos + new Vector2(slideX, -sinkDistance);
        body.localEulerAngles = new Vector3(0, 0, lieAngle);
    }

    [ContextMenu("Play WakeUp")]
    public void Play()
    {
        seq?.Kill();

        Vector2 lyingPos = standPos + new Vector2(slideX, -sinkDistance);

        body.anchoredPosition = lyingPos;
        body.localEulerAngles = new Vector3(0, 0, lieAngle);
        body.localScale = standScale;

        seq = DOTween.Sequence();

        // ★ ZZZをふわっと消す
        if (zzzObject != null)
        {
            CanvasGroup zzzCG = zzzObject.GetComponent<CanvasGroup>();
            if (zzzCG == null) zzzCG = zzzObject.AddComponent<CanvasGroup>();
            seq.Append(DOTween.To(() => zzzCG.alpha, x => zzzCG.alpha = x, 0f, 0.4f)
                .SetEase(Ease.OutQuad));
            seq.AppendCallback(() => zzzObject.SetActive(false));
        }

        // ① 伸び（うーんと体を伸ばす）
        seq.Append(body.DOScale(
            new Vector3(standScale.x * stretchScaleX, standScale.y * stretchScaleY, standScale.z),
            stretchTime
        ).SetEase(Ease.OutQuad));
        seq.Append(body.DOScale(standScale, stretchTime * 0.5f).SetEase(Ease.OutQuad));

        // ② ふわっと起き上がる
        seq.Append(body.DOLocalRotate(Vector3.zero, riseTime).SetEase(Ease.OutQuad));
        seq.Join(body.DOAnchorPos(standPos, riseTime).SetEase(Ease.OutQuad));

        // ③ 立ち上がった後に軽くピョンと伸びる
        seq.Append(body.DOScaleY(standScale.y * 1.06f, settleTime).SetEase(Ease.OutQuad));
        seq.Append(body.DOScaleY(standScale.y, settleTime).SetEase(Ease.OutBack, 1.2f));

        // ④ 完了
        seq.OnComplete(() =>
        {
            onWakeUpComplete?.Invoke();
            OnComplete?.Invoke();
            Debug.Log("[WakeUp] アニメ完了");
        });
    }

    [ContextMenu("Reset to Lying")]
    public void ResetToLying()
    {
        seq?.Kill();
        SetLyingPose();
    }

    [ContextMenu("Reset to Standing")]
    public void ResetToStanding()
    {
        seq?.Kill();
        body.anchoredPosition = standPos;
        body.localEulerAngles = Vector3.zero;
        body.localScale = standScale;
    }

    void OnDestroy() { seq?.Kill(); }
}