using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;

public class PowerUpSpeed : PowerUpBase
{
    [Header("Power Up Speed Up")]
    public float amountToSpeed;

    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        Player.Instance.PowerUpSpeedUp(amountToSpeed);
        Player.Instance.SetPowerUpText("Speed up");
    }
    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        Player.Instance.ResetSpeed();
        Player.Instance.SetPowerUpText("");
    }
   
}
