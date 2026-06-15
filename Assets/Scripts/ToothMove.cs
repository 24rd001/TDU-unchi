using UnityEngine;

public class ToothMove : MonoBehaviour
{
    public Vector3 moveOffset = new Vector3(0, -1f, 0);
    public float speed = 2f;
    public float delay = 0f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        float t = (Mathf.Sin((Time.time + delay) * speed) + 1f) / 2f;
        transform.localPosition = startPos + moveOffset * t;
    }
}