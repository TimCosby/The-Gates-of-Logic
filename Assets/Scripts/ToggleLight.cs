using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLight : MonoBehaviour {

	public bool Toggled = true;
	public float StartingIntensity = 0;
	public float MinIntensity = 0;
	public float MaxIntensity = 300;
	public Trigger Trigger;
	private bool InitialTrigger;
	private bool InitialIntensity = true;
	public bool SmoothTransition = true;
	public float TransitionSpeed = 2f;
	private Light Light;

	private void Start() {
		if (Trigger == null) {
			Trigger = GetComponent<Trigger>();
		}

		InitialTrigger = Trigger.Triggered;
		Light = GetComponent<Light>();

		Light.intensity = StartingIntensity;
	}

	private void Update() {
		Toggled = Trigger.Triggered;

		if (Toggled != InitialTrigger && InitialIntensity) {
			InitialIntensity = false;
		}
		else if (!InitialIntensity) {
			if (Toggled) {
				Light.intensity = Mathf.Lerp(Light.intensity, MaxIntensity, Time.deltaTime * TransitionSpeed);
			}
			else {
				Light.intensity = Mathf.Lerp(Light.intensity, MinIntensity, Time.deltaTime * TransitionSpeed);
			}
		}
	}
}
