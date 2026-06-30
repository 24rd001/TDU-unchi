using UnityEngine;

[RequireComponent(typeof(EdgeCollider2D))]
public class WaveCollider : MonoBehaviour
{
    EdgeCollider2D edge;

    public IsanMove visual; 
    public float moveAmount = 0.3f;
    public float baseOffset = 1.5f;

    Vector2[] basePoints;

    void Start()
    {
        edge = GetComponent<EdgeCollider2D>();
        basePoints = edge.points;
    }

    void Update()
    {
        if (visual == null) return;


        int frame = visual.CurrentFrame;
        int frameCount = visual.frames.Length;

        
        float center = (frameCount - 1) / 2f;
        float offset = (frame - center) * moveAmount;


        Vector2[] newPoints = new Vector2[basePoints.Length];

        for (int i = 0; i < basePoints.Length; i++)
        {
            newPoints[i] = new Vector2(
                basePoints[i].x + offset+ baseOffset,
                basePoints[i].y
            );
        }

        edge.points = newPoints;
    }
}