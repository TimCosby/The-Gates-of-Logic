using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionSensitiveTrigger : Trigger {

	public Trigger[] Triggers;
	private bool StartingTrig;

	public void Start() {
		StartingTrig = Triggered;
	}

	private void Update() {
		if (!SingleUse || (SingleUse && StartingTrig == Triggered)) {
			for (int i = 0; i < Triggers.Length; i++) {
				if (Triggers[i].Triggered == false) {
					if (Inversed)
						Triggered = true;
					else
						Triggered = false;
					break;
				}
				else if (i == Triggers.Length - 1) {
					if (Inversed)
						Triggered = false;
					else
						Triggered = true;
				}
			}
		}
	}
}
