using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour {

	public Trigger Trigger;
	private AudioSource Audio;
	private bool Played = false;
	public bool PlayOnToggle = false;
	private bool StartMakingSound = false;
	private bool DefaultState;

	private void Start() {
		if (Trigger == null) {
			Trigger = GetComponent<Trigger>();
		}
		DefaultState = Trigger.Triggered;

		Audio = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update() {
		if (!StartMakingSound && DefaultState != Trigger.Triggered) {
			StartMakingSound = true;
		}

		if (StartMakingSound) {
			if (Trigger.Triggered && !Played) {
				if (Audio.isPlaying) {
					Audio.Stop();
				}
				Audio.Play();
				Played = true;
			}
			else if (!Trigger.Triggered && Played) {
				if (Audio.isPlaying) {
					Audio.Stop();
				}
				Played = false;
				if (PlayOnToggle) {
					Audio.Play();
				}
			}
		}
	}
}
