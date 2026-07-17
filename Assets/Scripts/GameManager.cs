using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool switchA = false;
    public float daityouRotation = -90f;
    public bool firstEnterDaityou = true; 
    // ‰ñ“]ƒCƒxƒ“ƒg’¼Œã‚©
    public bool justRotatedDaityou = false;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}