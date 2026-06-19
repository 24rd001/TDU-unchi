using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
    public static LifeManager Instance;

    public int maxLife = 3;
    public int currentLife = 1;

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
        currentLife -= amount;

        if (currentLife <= 0)
        {
            currentLife = 0;
            // この行を実行した瞬間に、Unityエディタが一時停止（Pause）します
            Debug.Break();

            SceneManager.LoadScene("GameOver");
            
        }
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
        currentLife = 1;
    }
}