using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BodyMapUI : MonoBehaviour
{
    [Header("現在のステージ（シーンごとに設定）")]
    public int currentStage = 0;
    // 0=口, 1=食道, 2=胃, 3=十二指腸, 4=小腸, 5=大腸, 6=肛門

    [Header("体内マップ画像（0=口 ～ 6=肛門）")]
    public Sprite[] mapImages;   // 7枚（zinntai2～8を順番に）

    [Header("UI参照")]
    public GameObject overlay;       // オーバーレイ全体
    public Image mapImage;           // 体内図のImage
    public Image backgroundDim;      // 背景を暗くする半透明Image
    public TMP_Text currentText;     // 「現在地：○○」テキスト
    public Transform stageList;      // ステージ名の親

    [Header("ステージ名マーカー")]
    public Image[] stageDots;        // 各ステージの●（7個）
    public TMP_Text[] stageLabels;   // 各ステージのテキスト（7個）

    [Header("色")]
    public Color doneColor = new Color(0.35f, 0.54f, 0.29f);       // 緑
    public Color currentColor = new Color(0.94f, 0.75f, 0.16f);    // 黄
    public Color lockedColor = new Color(0.6f, 0.6f, 0.6f);        // 灰

    static readonly string[] stageNames =
        { "口", "食道", "胃", "十二指腸", "小腸", "大腸", "肛門" };

    bool isOpen = false;

    void Start()
    {
        if (overlay) overlay.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Toggle();
        }
    }

    void Toggle()
    {
        isOpen = !isOpen;

        if (isOpen)
            ShowMap();
        else
            HideMap();
    }

    void ShowMap()
    {
        // ゲームを一時停止
        Time.timeScale = 0f;
        overlay.SetActive(true);

        // 体内図を現在ステージの画像に差し替え
        if (mapImages != null && currentStage >= 0 && currentStage < mapImages.Length)
        {
            mapImage.sprite = mapImages[currentStage];
        }

        // 「現在地：○○」テキスト
        if (currentText)
        {
            currentText.text = "現在地：" + stageNames[currentStage];
        }

        // 各ステージのドットとラベルの色を更新
        for (int i = 0; i < stageNames.Length; i++)
        {
            Color col;
            string prefix = "";

            if (i < currentStage)
            {
                col = doneColor;       // クリア済み＝緑
            }
            else if (i == currentStage)
            {
                col = currentColor;    // 今ここ＝黄
                prefix = "→ ";
            }
            else
            {
                col = lockedColor;     // 未到達＝灰
            }

            if (i < stageDots.Length && stageDots[i])
                stageDots[i].color = col;

            if (i < stageLabels.Length && stageLabels[i])
            {
                stageLabels[i].text = prefix + stageNames[i] + (i == currentStage ? "（いまここ）" : "");
                stageLabels[i].color = col;
            }
        }
    }

    void HideMap()
    {
        Time.timeScale = 1f;   // ゲーム再開
        overlay.SetActive(false);
    }

    void OnDestroy()
    {
        // シーン遷移時にtimeScaleが0のまま残らないように
        Time.timeScale = 1f;
    }
}