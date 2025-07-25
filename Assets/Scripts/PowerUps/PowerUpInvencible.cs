using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;

public class PowerUpInvencible : PowerUpBase
{
    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        Player.Instance.SetPowerUpText("Invencible");
        Player.Instance.SetInvencible();
    }
    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        Player.Instance.SetInvencible(false);
        Player.Instance.SetPowerUpText("");
    }
}
