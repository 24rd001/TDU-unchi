using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool switchA = false;
    public float daityouRotation = -90f;
    public bool firstEnterDaityou = true;
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