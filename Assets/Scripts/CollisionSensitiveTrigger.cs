using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSensitiveTrigger : Trigger {

	public string[] tags;

	private void OnCollisionEnter(Collision collision) {
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

	private void OnCollisionExit(Collision collision) {
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
