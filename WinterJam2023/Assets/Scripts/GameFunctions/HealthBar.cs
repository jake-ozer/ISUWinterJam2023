using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public Health health; //this gets assigned OUTSIDE of this script
    private void Start()
    {
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = health.maxHealth;
        healthBar.value = health.maxHealth;
    }

    public void SetHealth(float hp)
    {
        healthBar.value = hp;
    }
}
