using UnityEngine;

public class Tonguestretch : MonoBehaviour
{
    [Header("Stretch")]
    public float minScaleMultiplier = 1.0f;
    public float maxScaleMultiplier = 2.0f;
    public float speed = 2f;

    private Vector3 startScale;
    private Vector3 startPosition;

    void Start()
    {
        startScale = transform.localScale;
        startPosition = transform.position;
    }

    void Update()
    {
        float t = (Mathf.Sin(Time.time * speed) + 1f) / 2f;

        float scaleX = Mathf.Lerp(
            startScale.x * minScaleMultiplier,
            startScale.x * maxScaleMultiplier,
            t
        );

        transform.localScale = new Vector3(
            scaleX,
            startScale.y,
            startScale.z
        );

        // ˆÊ’u‚ÍŒÅ’è
        transform.position = startPosition;
    }
}