using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Image hpBarForeground;
    [SerializeField] private GameObject deathPanel;

    public void UpdateHpBar(PlayerStats plStats)
    {
        hpBarForeground.fillAmount = plStats.RemainingHealthPercentage;
    }

}
