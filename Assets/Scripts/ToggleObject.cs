using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObject : MonoBehaviour {

	public bool Invert = false;
	public Trigger Trigger;
	public GameObject[] ObjectsToDisable;
	private bool LastState;

	// Use this for initialization
	void Start() {
		if (Trigger == null) {
			Trigger = GetComponent<Trigger>();
		}
		LastState = Trigger.Triggered;
	}

	// Update is called once per frame
	void Update() {
		if (Trigger.Triggered != LastState) {
			if (Invert) {
				for (int i = 0; i < ObjectsToDisable.Length; i++) {
					ObjectsToDisable[i].SetActive(!Trigger.Triggered);
				}
			}
			else {
				for (int i = 0; i < ObjectsToDisable.Length; i++) {
					ObjectsToDisable[i].SetActive(Trigger.Triggered);
				}
			}
		}
	}
}
