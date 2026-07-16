using UnityEngine;
using UnityEngine.UI;

public class TimeLimitManager : MonoBehaviour
{
    public Image clockImage;

    public Sprite clock12;
    public Sprite clock15;
    public Sprite clock30;
    public Sprite clock45;

    public float limitTime = 60f;

    private float timer;

    void Start()
    {
        timer = limitTime;
        clockImage.sprite = clock12;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        float ratio = timer / limitTime;

        if (ratio <= 0.75f && ratio > 0.50f)
        {
            clockImage.sprite = clock15;
        }
        else if (ratio <= 0.50f && ratio > 0.25f)
        {
            clockImage.sprite = clock30;
        }
        else if (ratio <= 0.25f && ratio > 0f)
        {
            clockImage.sprite = clock45;
        }
        else if (ratio <= 0f)
        {
            clockImage.sprite = clock12;

            // ƒ‰ƒCƒt‚ð0‚É‚µ‚ÄŽ€–S
            LifeManager.Instance.Damage(
                LifeManager.Instance.currentLife
            );

            enabled = false;
        }
    }
}