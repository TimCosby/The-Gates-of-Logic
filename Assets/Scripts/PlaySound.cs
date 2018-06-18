using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour {

	public Trigger Trigger;
	private AudioSource Audio;
	private bool Played;
	public bool PlayOnToggle = false;
	private bool StartMakingSound = false;
	private bool DefaultState;
	public bool debug = false;

	private void Start() {
		if (Trigger == null) {
			Trigger = GetComponent<Trigger>();
		}
		DefaultState = Trigger.Triggered;
		Played = DefaultState;

		Audio = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update() {
		if (!StartMakingSound && DefaultState != Trigger.Triggered) {
			StartMakingSound = true;
		}

		if (debug) {
			Debug.Log(StartMakingSound + " " + DefaultState + " " + Trigger.Triggered);
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
				Debug.Log("did1 " + PlayOnToggle);
				if (PlayOnToggle) {
					Audio.Play();
					Debug.Log("did");
				}
			}
		}
	}
}
