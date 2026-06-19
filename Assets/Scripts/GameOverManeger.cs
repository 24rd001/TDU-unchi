using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public Transform player;
    public Transform spawnPoint;

    public void GameOver()
    {
        player.position = spawnPoint.position;
    }
}