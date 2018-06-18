using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCollision : MonoBehaviour {

	public bool Invert = false;
	private bool DefaultState;
	public Trigger Trigger;

	// Use this for initialization
	void Start () {
		if (Trigger == null) {
			Trigger = GetComponent<Trigger>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Invert) {
			GetComponent<Collider>().enabled = !Trigger.Triggered;
		}
		else {
			GetComponent<Collider>().enabled = Trigger.Triggered;
		}
	}
}
