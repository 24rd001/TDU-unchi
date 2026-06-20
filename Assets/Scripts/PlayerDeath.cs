using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private PlayerController2D playerController;
    private Rigidbody2D rb;
    private PlayerVisual playerVisual;

    private bool isDead = false;

    void Awake()
    {
        playerController = GetComponent<PlayerController2D>();
        rb = GetComponent<Rigidbody2D>();
        playerVisual = GetComponent<PlayerVisual>();
    }

    public void Die()
    {
        if (isDead) return;
        isDead = true;

        if (playerController != null)
        {
            playerController.enabled = false;
        }

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
        }

        if (playerVisual != null)
        {
            playerVisual.PlayDeath();
        }
    }
}