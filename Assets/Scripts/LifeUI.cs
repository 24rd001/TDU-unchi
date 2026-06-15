using UnityEngine;
using UnityEngine.UI;

public class LifeUI : MonoBehaviour
{
    public Image[] hearts;

    void Update()
    {
        if (LifeManager.Instance == null) return;

        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < LifeManager.Instance.currentLife;
        }
    }
}