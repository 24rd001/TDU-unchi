using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private PlayerController2D playerController;
    private Rigidbody2D rb;
    private PlayerVisual playerVisual;

    [Header("効果音")]
    public AudioClip deathSound;   // ← 追加

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

        if (deathSound != null)
            AudioSource.PlayClipAtPoint(deathSound, transform.position);   // ← 追加
    }
}