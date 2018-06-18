using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLight : MonoBehaviour {

	public bool Toggled = true;
	public float MinStartingIntensity = 0f;
	public float MaxStartingIntensity = 0f;
	public float SmoothingOffset = 0f;
	public float MinIntensity = 0f;
	public float MaxIntensity = 300f;
	public Trigger Trigger;
	private bool InitialTrigger;
	private bool InitialIntensity = true;
	public bool SmoothTransition = true;
	public float InitialTransitionSpeed = 2f;
	public float TransitionSpeed = 2f;
	private Light Light;
	private bool GoingUp;

	private void Start() {
		if (Trigger == null) {
			Trigger = GetComponent<Trigger>();
		}

		InitialTrigger = Trigger.Triggered;
		Light = GetComponent<Light>();

		Light.intensity = MinStartingIntensity;
	}

	private void Update() {
		Toggled = Trigger.Triggered;

		if (Toggled != InitialTrigger && InitialIntensity) {
			InitialIntensity = false;
		} 
		else if (InitialIntensity) {
			if (Light.intensity <= MinStartingIntensity + SmoothingOffset) {
				GoingUp = true;
			} else if (Light.intensity >= MaxStartingIntensity - SmoothingOffset) {
				GoingUp = false;
			}

			if (GoingUp) {
				Light.intensity = Mathf.Lerp(Light.intensity, MaxStartingIntensity, Time.deltaTime * InitialTransitionSpeed);
			}
			else {
				Light.intensity = Mathf.Lerp(Light.intensity, MinStartingIntensity, Time.deltaTime * InitialTransitionSpeed);
			}
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
