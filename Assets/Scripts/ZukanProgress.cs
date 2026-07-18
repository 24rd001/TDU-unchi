using UnityEngine;
using System.Collections.Generic;

public static class ZukanProgress
{
    public static bool IsUnlocked(string id) => PlayerPrefs.GetInt("poop_" + id, 0) == 1;

    public static void Unlock(string id)     // ゲームクリア時に呼ぶ
    {
        PlayerPrefs.SetInt("poop_" + id, 1);
        PlayerPrefs.Save();
    }

    // このうんちを作った時に食べた材料を保存する
    public static void SaveIngredients(string id, IEnumerable<string> itemNames)
    {
        string joined = string.Join(",", itemNames);
        PlayerPrefs.SetString("poop_ingredients_" + id, joined);
        PlayerPrefs.Save();
    }

    // このうんちを作った時に食べた材料を取得する
    public static string[] GetIngredients(string id)
    {
        string joined = PlayerPrefs.GetString("poop_ingredients_" + id, "");
        if (string.IsNullOrEmpty(joined)) return new string[0];
        return joined.Split(',');
    }
}