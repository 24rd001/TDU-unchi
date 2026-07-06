using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Image hpImage;

    public float maxHP = 30f;
    public float currentHP;

    void Start()
    {
        currentHP = maxHP;
        UpdateBar();
    }

    void Update()
    {
        UpdateBar();
    }

    public void SetHP(float hp)
    {
        currentHP = Mathf.Clamp(hp, 0, maxHP);
        UpdateBar();
    }

    void UpdateBar()
    {
        hpImage.fillAmount = currentHP / maxHP;
    }
}