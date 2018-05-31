using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroGravity : MonoBehaviour {

	public float TimeLimit = 0;
	public float Delay = 0;
	public GameObject[] AffectedObjects;
	private float TimeStart = -10;
	private float TimeEnd = -10;
	private bool Toggled = false;
	private bool Unpressed = true;
	public AudioClip BackgroundMusic;
	public AudioClip ZeroGMusic;
	
	// Update is called once per frame
	void Update () {
		bool GravKey = Input.GetKey(KeyCode.E);

		if (Toggled && (Input.GetKeyUp(KeyCode.E) || Time.time - TimeStart - TimeLimit > 0)) {
			Debug.Log("Off");
			GetComponent<AudioSource>().clip = BackgroundMusic;
			GetComponent<AudioSource>().Play();
			TimeEnd = Time.time;
			Toggled = false;

			for (int i = 0; i < AffectedObjects.Length; i++) {
				AffectedObjects[i].GetComponent<Rigidbody>().useGravity = true;
			}
		}
		else if (Unpressed && !Toggled && GravKey && Time.time - TimeEnd - Delay > 0) {
			Debug.Log("On");
			GetComponent<AudioSource>().clip = ZeroGMusic;
			GetComponent<AudioSource>().Play();
			TimeStart = Time.time;
			Toggled = true;
		}

		if (Toggled) {
			for (int i = 0; i < AffectedObjects.Length; i++) {
				AffectedObjects[i].GetComponent<Rigidbody>().useGravity = false;
			}
		}
	}
}
