using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyGravityMass : MonoBehaviour {

	private Rigidbody RigidBody;

	private void Start() {
		RigidBody = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void FixedUpdate () {
		RigidBody.AddForce(Physics.gravity * RigidBody.mass);
	}
}
