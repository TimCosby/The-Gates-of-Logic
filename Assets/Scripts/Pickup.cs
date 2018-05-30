using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup: MonoBehaviour {

	public Transform ObjectInHand;
	private Rigidbody obj;

	private void Start() {
		obj = GetComponent<Rigidbody>();
	}

	private void OnMouseDown() {
		obj.useGravity = false;
		obj.isKinematic = true;

		transform.position = ObjectInHand.position;
		transform.parent = GameObject.Find("Character").transform;
		transform.parent = GameObject.Find("Main Camera").transform;
		transform.parent = GameObject.Find("PickedUp").transform;
	}

	private void OnMouseUp() {
		obj.isKinematic = false;
		obj.useGravity = true;
		transform.parent = null;
	}
}
