using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLight : MonoBehaviour {

	public bool Toggled = true;
	public Trigger Trigger;

	private void Start() {
		if (Trigger == null) {
			Trigger = GetComponent<Trigger>();
		}
	}

	private void Update() {
		Toggled = Trigger.Triggered;
		GetComponent<Light>().enabled = Toggled;
	}
}
