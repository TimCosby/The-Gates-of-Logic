using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableComponent : Trigger {

	public Trigger Trigger;
	public MonoBehaviour[] ComponentsToDisable;

	private void Start() {
		if (Trigger == null) {
			Trigger = GetComponent<Trigger>();
		}
	}

	// Update is called once per frame
	void Update () {
		if (Trigger.Triggered) {
			for (int i = 0; i < ComponentsToDisable.Length; i++) {
				if (Inversed)
					ComponentsToDisable[i].enabled = true;
				else
					ComponentsToDisable[i].enabled = false;
			}
		}
		else {
			for (int i = 0; i < ComponentsToDisable.Length; i++) {
				if (Inversed)
					ComponentsToDisable[i].enabled = false;
				else
					ComponentsToDisable[i].enabled = true;
			}
		}
	}
}
