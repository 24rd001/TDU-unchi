using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
    public static LifeManager Instance;

    public int maxLife = 3;
    public int currentLife = 1;

    
    public string respawnSceneName = "MouseScene";
    public float respawnDelay = 2f;

    private int initiallife = 1;
    private bool isDead = false;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Damage(int amount)
    {
        if(isDead) return;
        currentLife -= amount;

        if (currentLife <= 0)
        {
            currentLife = 0;
            StartCoroutine(DeathAndRespawn());
            
        }
    }
    IEnumerator DeathAndRespawn()
    {
        isDead = true;

        PlayerDeath playerDeath = FindFirstObjectByType<PlayerDeath>();

        if (playerDeath != null)
        {
            playerDeath.Die();
        }

        yield return new WaitForSeconds(respawnDelay);

        currentLife = initiallife;
        isDead = false;

        SceneManager.LoadScene(respawnSceneName);
    }

    public void AddLife(int amount)
    {
        currentLife += amount;

        if (currentLife > maxLife)
        {
            currentLife = maxLife;
        }
    }

    public void ResetLife()
    {
        currentLife = initiallife;
        isDead=false;
    }

    public void SetRespawnScene(string sceneName)
    {
        respawnSceneName = sceneName;
    }

    
}