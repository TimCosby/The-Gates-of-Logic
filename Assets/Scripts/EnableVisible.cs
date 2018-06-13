using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableVisible : Trigger {

	public Trigger Trigger;
	public GameObject[] ToggleObjects;
	private bool LastState;
	private bool FirstState;

	// Use this for initialization
	void Start () {
		if (Trigger == null) {
			Trigger = GetComponent<Trigger>();
		}

		LastState = Trigger.Triggered;
		FirstState = LastState;
	}
	
	// Update is called once per frame
	void Update () {
		if ((Trigger.SingleUse && FirstState == LastState) || !Trigger.SingleUse) {
			if (LastState != Trigger.Triggered) {
				LastState = !LastState;
				for (int i = 0; i < ToggleObjects.Length; i++) {
					if (Trigger.Inversed) {
						ToggleObjects[i].GetComponent<MeshRenderer>().enabled = !LastState;
					}
					else {
						ToggleObjects[i].GetComponent<MeshRenderer>().enabled = LastState;
					}
				}
			}
		}


	}
}
