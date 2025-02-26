using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnLocation : MonoBehaviour
{
    public Vector3 respawnPoint;

    private void Start()
    {
        // Set default respawn point to the player's starting position
        respawnPoint = transform.position;
    }

    public void SetRespawnPoint(Vector3 newRespawnPoint)
    {
        respawnPoint = newRespawnPoint;
    }

    public void RespawnPlayer(Transform player)
    {
        player.position = respawnPoint;
        Debug.Log("Player respawned at: " + respawnPoint);
    }
}
