using UnityEngine;

public class ToothTrigger : MonoBehaviour
{
    public HealTooth group;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (group != null)
        {
            group.TryHeal(other);
        }
    }
}