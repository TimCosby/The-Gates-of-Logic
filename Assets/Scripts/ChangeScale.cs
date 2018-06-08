using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScale : MonoBehaviour {

	public Trigger Trigger;
	public Vector3 Scale;
	public float speed = 2;
	public bool ChangeX = true;
	public bool ChangeY = true;
	public bool ChangeZ = true;
	private Vector3 ChangeToScale = new Vector3();
	private Vector3 OriginalScale;

	// Use this for initialization
	void Start () {
		if (Trigger == null) {
			Trigger = GetComponent<Trigger>();
		}

		OriginalScale = GetComponent<Transform>().localScale;

		if (ChangeX) {
			ChangeToScale.x = Scale.x;
		}
		else {
			ChangeToScale.x = OriginalScale.x;
		}

		if (ChangeY) {
			ChangeToScale.y = Scale.y;
		}
		else {
			ChangeToScale.y = OriginalScale.y;
		}

		if (ChangeZ) {
			ChangeToScale.z = Scale.z;
		}
		else {
			ChangeToScale.z = OriginalScale.z;
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (Trigger.Triggered) {
			GetComponent<Transform>().localScale = Vector3.Lerp(GetComponent<Transform>().localScale, ChangeToScale, speed * Time.deltaTime);
		}
		else {
			GetComponent<Transform>().localScale = Vector3.Lerp(GetComponent<Transform>().localScale, OriginalScale, speed * Time.deltaTime);
		}
	}
}
