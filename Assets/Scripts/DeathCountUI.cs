using TMPro;
using UnityEngine;

public class DeathCountUI : MonoBehaviour
{
    public TMP_Text deathText;

    void Update()
    {
        if (LifeManager.Instance != null)
        {
            deathText.text =
                "€–S‰ñ” : " +
                LifeManager.Instance.deathCount;
        }
    }
}