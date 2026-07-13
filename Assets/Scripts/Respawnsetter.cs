using UnityEngine;

public class Respawnsetter : MonoBehaviour
{
    public string respawnSceneName;

    void Start()
    {
        if (LifeManager.Instance != null)
        {
            LifeManager.Instance.SetRespawnScene(respawnSceneName);
        }
    }
}