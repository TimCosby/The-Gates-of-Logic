using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour {

	public Trigger Trigger;
	public GameObject Object;
	public Vector3 Position;
	public Quaternion Rotation;
	private bool SinglePress = true;

	private void Start() {
		if (Trigger == null) {
			Trigger = GetComponent<Trigger>();
		}
	}

	// Update is called once per frame
	void Update () {
		if (Trigger.Triggered) {
			if (SinglePress) {
				SinglePress = false;
				Instantiate(Object, Position, Rotation);
			}
		}
		else {
			SinglePress = true;
		}
	}
}
