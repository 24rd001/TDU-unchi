using UnityEngine;

public class Camerafollow2d : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 5f;

    [Header("Camera Limit")]
    public float minX = 0f;
    public float maxX = 50f;
    public float minY = 0f;
    public float maxY = 10f;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 targetPos = new Vector3(
            target.position.x,
            target.position.y,
            transform.position.z
        );

        targetPos.x = Mathf.Clamp(targetPos.x, minX, maxX);
        targetPos.y = Mathf.Clamp(targetPos.y, minY, maxY);

        transform.position = Vector3.Lerp(
            transform.position,
            targetPos,
            smoothSpeed * Time.deltaTime
        );
    }
}