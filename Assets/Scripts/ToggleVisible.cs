using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleVisible : MonoBehaviour {

	public Trigger Trigger;
	private MeshRenderer Mesh;
	public bool IsVisible = true;
	private bool InitialBool;

	private void Start() {
		if (Trigger == null) {
			Trigger = GetComponent<Trigger>();
		}
		Mesh = GetComponent<MeshRenderer>();
		InitialBool = IsVisible;
	}

	private void Update() {
		if (Trigger.Triggered) {
			IsVisible = !InitialBool;
		}
		else {
			IsVisible = InitialBool;
		}

		Mesh.enabled = IsVisible;
	}
}
