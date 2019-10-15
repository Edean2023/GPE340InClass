using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : Pickup
{
    // variables 
    [Header("Health Values")]
    public float Health;
    [SerializeField] private float maxHealth;

    public float healthPercent
    {
        get { return Health / maxHealth; }
        set { Health = value * maxHealth; }
    }

    // functions
    public void Takedamage(float damageTaken)
    {
        Health -= damageTaken;
        Mathf.Clamp(Health, 0, maxHealth);
    }

    public void Takehealing(float healingTaken)
    {
        Health += healingTaken;
        Mathf.Clamp(Health, 0, maxHealth);
    }

    public void KillMe()
    {
        Health = 0;
    }

    public void HealtoFull()
    {
        // set health to full
        // this is probs really jank but meh
    }
}
