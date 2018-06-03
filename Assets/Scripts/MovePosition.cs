using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePosition : MonoBehaviour {

	public Trigger Trigger;
	public Vector3 OffSet;
	private Vector3 FromPos;
	private Transform obj;
	public float speed = 2f;
	public bool X = true;
	public bool Y = true;
	public bool Z = true;

	private void Start() {
		if (Trigger == null) {
			Trigger = GetComponent<Trigger>();
		}
		obj = GetComponent<Transform>();
		FromPos = obj.position;
	}

	// Update is called once per frame
	private void Update () {
		Vector3 ObjectPos = GetComponent<Transform>().position;
		Vector3 ToPos = ObjectPos;

		if (Trigger.Triggered) {
			if (X) {
				ToPos.x = FromPos.x + OffSet.x;
			}
			if (Y) {
				ToPos.y = FromPos.y + OffSet.y;
			}
			if (Z) {
				ToPos.z = FromPos.z + OffSet.z;
			}

			obj.position = Vector3.Lerp(ObjectPos, ToPos, speed * Time.deltaTime);// MoveTowards(obj.position, FromPos + ToPos, speed * Time.deltaTime); //obj.Translate(CalculateNewPos() * Time.deltaTime);
		}
		else {
			if (X) {
				ToPos.x = FromPos.x;
			}
			if (Y) {
				ToPos.y = FromPos.y;
			}
			if (Z) {
				ToPos.z = FromPos.z;
			}
			obj.position = Vector3.Lerp(ObjectPos, ToPos, speed * Time.deltaTime);//Vector3.MoveTowards(obj.position, FromPos, speed * Time.deltaTime); //obj.Translate(CalculatePos() * Time.deltaTime);
		} 
	}
}
