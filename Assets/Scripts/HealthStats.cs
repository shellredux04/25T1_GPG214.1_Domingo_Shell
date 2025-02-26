using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthStats : MonoBehaviour
{
    public float playerHealth = 100f; // Default health

    public void TakeDamage(float damage)
    {
        playerHealth -= damage;
        if (playerHealth < 0)
        {
            playerHealth = 0;
            Debug.Log("Player is dead.");
        }
    }

    public void Heal(float amount)
    {
        playerHealth += amount;
        if (playerHealth > 100f)
        {
            playerHealth = 100f;
        }
    }
}
