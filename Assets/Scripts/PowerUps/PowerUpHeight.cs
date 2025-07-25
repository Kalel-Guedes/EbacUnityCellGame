using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using DG.Tweening;

public class PowerUpHeight : PowerUpBase
{
    [Header("Power Up Height")]
    public float amountHeight = 2;
    public float animationDuration = .1f;
    public DG.Tweening.Ease ease = DG.Tweening.Ease.OutBack;
    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        Player.Instance.ChangeHeight(amountHeight, duration, animationDuration, ease);
    }
    
}
