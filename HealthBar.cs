using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    private Image Healthbar;
    public float CurrentHealth;
    private float Maxhp;
    PlayerStats stats;

    private void Start()
    {
        Healthbar = GetComponent<Image>();
        stats = FindObjectOfType<PlayerStats>();

    }

    private void Update()
    {
        Maxhp = stats.MaxHealth;
        CurrentHealth = stats.currentHealth;
        Healthbar.fillAmount = CurrentHealth / Maxhp;
    }


}
