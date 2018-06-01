using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionSensitiveTrigger : Trigger {

	public GameObject[] TriggerObjects;
	private bool StartingTrig;
	private bool IsAND;
	private bool IsOR;
	private bool IsXOR;

	public void Start() {
		StartingTrig = Triggered;
		IsAND = AND;
		IsOR = OR;
		IsXOR = XOR;
	}

	private void Update() {
		if (!SingleUse || (SingleUse && StartingTrig == Triggered)) {  
			int NumTrues = 0;
			for (int i = 0; i < TriggerObjects.Length; i++) {
				if (TriggerObjects[i].GetComponent<Trigger>().Triggered == true) {
					NumTrues++;
				} 
			}

			if (NumTrues < 1) {
				Triggered = false;
			} else {
				if (IsOR) {
					Triggered = true;
				} else if (IsXOR && NumTrues == 1) {
					Triggered = true;
				} else if (IsXOR) {
					Triggered = false;
				} else if (IsAND && NumTrues == TriggerObjects.Length) {
					Triggered = true;
				} else if (IsAND) {
					Triggered = false;
				} else {
					Triggered = true;
				}
			}

			if (Inversed) {
				Triggered = !Triggered;
			}
		}
	}
}