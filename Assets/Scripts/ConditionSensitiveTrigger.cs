using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionSensitiveTrigger : Trigger {

	public GameObject[] TriggerObjects;
	private bool StartingTrig;

	public void Start() {
		StartingTrig = Triggered;
	}

	private void Update() {
		if (!SingleUse || (SingleUse && StartingTrig == Triggered)) {
			for (int i = 0; i < TriggerObjects.Length; i++) {
				if (TriggerObjects[i].GetComponent<Trigger>().Triggered == false) {
					if (Inversed)
						Triggered = true;
					else
						Triggered = false;
					break;
				}
				else if (i == TriggerObjects.Length - 1) {
					if (Inversed)
						Triggered = false;
					else
						Triggered = true;
				}
			}
		}
	}
}
