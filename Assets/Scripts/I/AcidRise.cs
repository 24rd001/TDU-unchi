
using UnityEngine;

public class AcidRise : MonoBehaviour
{
    public float riseSpeed = 0.5f;

    void Update()
    {
        transform.position += Vector3.up * riseSpeed * Time.deltaTime;
    }
}




