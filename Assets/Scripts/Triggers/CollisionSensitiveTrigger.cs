using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSensitiveTrigger : Trigger {

	public string[] tags;
	public bool Toggleable = false;
	public float UnpressDelay = 0f;
	private float LastPress = -50f;

	private void OnCollisionEnter(Collision collision) {
		if (Toggleable) {
			if (LastPress <= Time.time - UnpressDelay) {
				Triggered = !Triggered;
			}
		}
		else {
			for (int i = 0; i < tags.Length; i++) {
				if (tags[i] == collision.gameObject.tag) {
					if (Inversed) {
						Triggered = false;
					}
					else {
						Triggered = true;
					}
				}
			}
		}
	}

	private void OnCollisionExit(Collision collision) {
		if (!Toggleable && LastPress <= Time.time - UnpressDelay) {
			if (!SingleUse) {
				if (Inversed) {
					Triggered = true;
				}
				else {
					Triggered = false;
				}
			}
		}
	}
}
