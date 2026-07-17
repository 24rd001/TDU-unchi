using System.Collections.Generic;
using UnityEngine;

public class CollectedItemsManager : MonoBehaviour
{
    public static CollectedItemsManager Instance;

    private HashSet<string> collectedIds = new HashSet<string>();

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public bool IsCollected(string id)
    {
        return collectedIds.Contains(id);
    }

    public void MarkCollected(string id)
    {
        collectedIds.Add(id);
    }
}