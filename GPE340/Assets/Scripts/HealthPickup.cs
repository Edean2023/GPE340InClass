using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup
{
    protected override void OnPickup(GameObject target)
    {
        HealthController health = target.GetComponent<HealthController>();
        if(health != null)
        {
            // figure out why this is broken
            health.health += 100;
        }
        base.OnPickup(target);
    }
}
