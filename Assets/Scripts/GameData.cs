public static class GameData
{
    public static int SelectedCharacter = 0;

    public static string EarnedPoopId  = "";   // ステージで獲得したうんち
    public static string FocusPoopId   = "";   // 図鑑で注目表示するうんち
    public static bool   CameFromClear = false;

    // ↓ ここから追加
    public static int Fiber   = 0;   // 食物繊維 0~5
    public static int Water   = 0;   // 水分 0~5
    public static int Protein = 0;   // たんぱく質 0~5

    // アイテムごとの取得数（0=キャベツ ... 9=たまご）
    public static int[] ItemCounts = new int[10];

    // 全部リセット（食べるシーン開始時などに呼ぶ）
    public static void ResetNutrition()
    {
        Fiber = 0; Water = 0; Protein = 0;
        ItemCounts = new int[10];
    }
}