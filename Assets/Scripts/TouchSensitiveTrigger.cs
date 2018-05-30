using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSensitiveTrigger : Trigger {

	public string TriggerTag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == TriggerTag) {
			if (Inversed)
				Triggered = false;
			else
				Triggered = true;
		}
    }

    private void OnTriggerExit(Collider other)
    {
		if (!SingleUse) {
			if (other.tag == TriggerTag) {
				if (Inversed)
					Triggered = true;
				else
					Triggered = false;
			}
		}
    }
}
