using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpStatus : MonoBehaviour
{
    public bool hasPowerUp = false;

    public void ActivatePowerUp()
    {
        hasPowerUp = true;
        Debug.Log("Power-up activated!");
    }

    public void DeactivatePowerUp()
    {
        hasPowerUp = false;
        Debug.Log("Power-up deactivated!");
    }
}
