using UnityEngine;

public static class ZukanProgress
{
    public static bool IsUnlocked(string id) => PlayerPrefs.GetInt("poop_" + id, 0) == 1;

    public static void Unlock(string id)     // ゲームクリア時に呼ぶ
    {
        PlayerPrefs.SetInt("poop_" + id, 1);
        PlayerPrefs.Save();
    }
}