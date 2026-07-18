using System.Linq;

public static class NutritionJudge
{
    public static string Judge()
    {
        var s = StatusManager.Instance;
        float F = s.nutrition;   // 食物繊維相当
        float W = s.water;
        float P = s.protein;
        int speciesTaken = s.takenItemNames.Count;
        int totalItems = s.totalItemCount;
        int pepperCount = s.pepperCount;

        // ==== 特殊条件（優先） ====
        if (pepperCount >= 3) return "hirihiri";
        if (speciesTaken >= 10) return "kiniro";
        if (speciesTaken >= 5)  return "colorful";
        if (totalItems == 1)    return "ghost";

        // ==== 通常条件（0~100スケール） ====
        if (F >= 70 && W >= 70 && P >= 30 && P <= 60) return "risou";
        if (F >= 50 && F < 70 && W >= 50 && W < 70 && P >= 30 && P <= 60) return "kongari";
        if (P >= 70 && F <= 30 && W <= 30) return "kusai";
        if (F + W + P <= 30) return "chibi";
        if (F >= 90 && W >= 30 && W <= 60) return "nagai";
        if (F >= 70 && W <= 20) return "mokomoko";
        if (W >= 70 && P >= 60) return "nurunuru";
        if (P >= 90 && F <= 10 && W <= 10) return "makkuro";
        if (W >= 90 && F <= 10 && P <= 10) return "mizu";
        if (W <= 20) return "korokoro";
        if (W >= 90) return "bichabicha";

        return "kongari";  // フォールバック
    }
}