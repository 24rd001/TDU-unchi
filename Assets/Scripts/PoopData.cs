using UnityEngine;

[CreateAssetMenu(fileName = "Poop", menuName = "TDU/Poop Data")]
public class PoopData : ScriptableObject
{
    public string id;                  // 固有ID（例 "normal"）セーブに使う
    public string poopName;            // 名前
    public Sprite icon;                // うんちの絵
    [Range(1,5)] public int rare = 1;
    public string katasa = "ふつう";
    public string nioi   = "ふつう";
    [Range(0,3)] public int sukkiri = 2;
    [TextArea] public string description;
}