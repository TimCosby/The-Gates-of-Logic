using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityTrigger : Trigger {

    public float range;
    public Transform other;

	// Update is called once per frame
	void Update () {
		if (Vector3.Distance(transform.position, other.position) <= range) 
        {
            Triggered = true;
        }
        else
        {
            Triggered = false;
        }
	}
}
