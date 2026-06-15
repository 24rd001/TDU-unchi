using UnityEngine;

public class TongueStretchFromBase : MonoBehaviour
{
    public float minLength = 1f;
    public float maxLength = 4f;
    public float speed = 2f;

    private Vector3 startScale;
    private Vector3 startLocalPosition;

    void Start()
    {
        startScale = transform.localScale;
        startLocalPosition = transform.localPosition;
    }

    void Update()
    {
        float t = (Mathf.Sin(Time.time * speed) + 1f) / 2f;
        float length = Mathf.Lerp(minLength, maxLength, t);

        transform.localScale = new Vector3(
            length,
            startScale.y,
            startScale.z
        );

        transform.localPosition = new Vector3(
            startLocalPosition.x + (length - minLength) / 2f,
            startLocalPosition.y,
            startLocalPosition.z
        );
    }
}