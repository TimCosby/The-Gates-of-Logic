using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableTrigger : Trigger {

	public Trigger Trigger;
	public Trigger[] TriggersToDisable;

	private void Start() {
		if (Trigger == null) {
			Trigger = GetComponent<Trigger>();
		}
	}

	// Update is called once per frame
	void Update () {
		if (Trigger.Triggered) {
			for (int i = 0; i < TriggersToDisable.Length; i++) {
				if (Inversed)
					TriggersToDisable[i].enabled = true;
				else
					TriggersToDisable[i].enabled = false;
			}
		}
		else {
			for (int i = 0; i < TriggersToDisable.Length; i++) {
				if (Inversed)
					TriggersToDisable[i].enabled = false;
				else
					TriggersToDisable[i].enabled = true;
			}
		}
	}
}
