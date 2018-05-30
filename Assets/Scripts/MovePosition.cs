using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePosition : MonoBehaviour {

	private Trigger Trigger;
	public Vector3 ToPos;
	private Vector3 FromPos;
	private Transform obj;
	public float speed = 2f;

	private void Start() {
		Trigger = GetComponent<Trigger>();
		obj = GetComponent<Transform>();
		FromPos = obj.position;
	}

	// Update is called once per frame
	private void Update () {
		if (Trigger.Triggered) {
			obj.position = Vector3.MoveTowards(obj.position, FromPos + ToPos, speed * Time.deltaTime); //obj.Translate(CalculateNewPos() * Time.deltaTime);
		}
		else {
			obj.position = Vector3.MoveTowards(obj.position, FromPos, speed * Time.deltaTime); //obj.Translate(CalculatePos() * Time.deltaTime);
		} 
	}
}
