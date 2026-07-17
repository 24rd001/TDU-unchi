using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool switchA = false;

    public float daityouRotation = -90f;
    public bool firstEnterDaityou = true;
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

    public void ResetGameData()
    {
        switchA = false;

        daityouRotation = -90f;
        firstEnterDaityou = true;
        justRotatedDaityou = false;
    }
}