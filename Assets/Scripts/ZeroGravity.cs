using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroGravity : MonoBehaviour {

	public float TimeLimit = 0;
	public float Delay = 0;
	public GameObject[] AffectedObjects;
	private float TimeStart = 0;
	private float TimeEnd = 0;
	private bool Toggled = false;
	private bool Unpressed = true;
	
	// Update is called once per frame
	void Update () {
		bool GravKey = Input.GetKey(KeyCode.E);

		if (Toggled && (Input.GetKeyUp(KeyCode.E) || Time.time - TimeStart - TimeLimit > 0)) {
			Debug.Log("Off");
			TimeEnd = Time.time;
			Toggled = false;

			for (int i = 0; i < AffectedObjects.Length; i++) {
				AffectedObjects[i].GetComponent<Rigidbody>().useGravity = true;
			}
		}
		else if (Unpressed && !Toggled && GravKey && Time.time - TimeEnd - Delay > 0) {
			Debug.Log("On");
			TimeStart = Time.time;
			Toggled = true;

			for (int i = 0; i < AffectedObjects.Length; i++) {
				AffectedObjects[i].GetComponent<Rigidbody>().useGravity = false;
			}
		}
	}
}
