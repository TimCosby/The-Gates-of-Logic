using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSensitiveTrigger : Trigger {

	public string TriggerTag;
	public bool Toggleable = false;
	public float Delay = 0f;
	private float LastPress = -100f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == TriggerTag && LastPress <= Time.time - Delay) {
			if (Toggleable) {
				Triggered = !Triggered;
			}
			else if (Inversed) {
				Triggered = false;
			}
			else {
				Triggered = true;
			}
			LastPress = Time.time;
		}
	}

    private void OnTriggerExit(Collider other)
    {
		if (!Toggleable && !SingleUse && LastPress <= Time.time - Delay) {
			if (other.tag == TriggerTag) {
				if (Inversed)
					Triggered = true;
				else
					Triggered = false;
				LastPress = Time.time;
			}
		}
    }
}
