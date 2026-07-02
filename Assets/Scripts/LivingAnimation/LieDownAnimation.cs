using System;
using UnityEngine;
using DG.Tweening;

public class LieDownAnimation : MonoBehaviour
{
    [Header("対象（UIのImage）")]
    public RectTransform body;

    [Header("寝る方向・量")]
    public float fallAngle = -90f;
    public float slideX = -40f;
    public float sinkDistance = 20f;

    [Header("タイミング（ソファ＝ゆっくり）")]
    public float anticipationTime = 0.2f;
    public float fallTime = 0.8f;
    public float settleTime = 0.25f;

    [Header("予備動作・つぶし")]
    public float anticipationDip = 0.96f;
    public float squashX = 1.07f;
    public float squashY = 0.95f;

    [Header("自動再生")]
    public bool playOnStart = true;
    public float startDelay = 0.5f;

    [Header("完了イベント（ギミックは後から登録）")]
    public UnityEngine.Events.UnityEvent onLieDownComplete;
    public event Action OnComplete;

    Vector2 initialPos;
    Vector3 initialScale;
    Quaternion initialRot;
    Sequence seq;

    void Awake()
    {
        if (body == null) body = GetComponent<RectTransform>();
        initialPos   = body.anchoredPosition;
        initialScale = body.localScale;
        initialRot   = body.localRotation;
    }

    void Start()
    {
        if (playOnStart)
        {
            Invoke(nameof(Play), startDelay);
        }
    }

    [ContextMenu("Play LieDown")]
    public void Play()
    {
        seq?.Kill();
        float startZ = body.localEulerAngles.z;
        float endZ   = startZ + fallAngle;
        Vector2 sunkPos = initialPos + new Vector2(slideX, -sinkDistance);

        seq = DOTween.Sequence();

        // ① 一息（軽くためる：少し縮んで戻る）
        seq.Append(body.DOScaleY(initialScale.y * anticipationDip, anticipationTime).SetEase(Ease.OutQuad));
        seq.Append(body.DOScaleY(initialScale.y, anticipationTime * 0.6f).SetEase(Ease.OutQuad));

        // ② ふわっと身を預ける（OutBack＝やわらかく倒れる）
        seq.Append(body.DOLocalRotate(new Vector3(0, 0, endZ), fallTime).SetEase(Ease.OutBack, 1.1f));
        seq.Join(body.DOAnchorPos(sunkPos, fallTime).SetEase(Ease.OutQuad));

        // ③ クッションが沈む（控えめなつぶし→戻る）
        seq.Append(body.DOScale(
            new Vector3(initialScale.x * squashX, initialScale.y * squashY, initialScale.z), settleTime
        ).SetEase(Ease.OutQuad));
        seq.Append(body.DOScale(initialScale, settleTime).SetEase(Ease.OutQuad));

        // ④ 完了（中身は後から）
        seq.OnComplete(() =>
        {
            onLieDownComplete?.Invoke();
            OnComplete?.Invoke();
            Debug.Log("[LieDown] アニメ完了（ギミックは後で追加）");
        });
    }

    [ContextMenu("Reset Pose")]
    public void ResetPose()
    {
        seq?.Kill();
        body.anchoredPosition = initialPos;
        body.localScale = initialScale;
        body.localRotation = initialRot;
    }

    void OnDestroy() { seq?.Kill(); }
}