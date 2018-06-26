using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {

	// aka player
	public GameObject MovingObject;
	// aka walls etc
	public float XOffset = 0;
	public float YOffset = 0;
	public float ZOffset = 0;
	public bool X = true;
	public bool Y = true;
	public bool Z = true;

	public bool AppearAtOffset = false;

	private int NumEnabled = 0;
	private double LastTrans = 1;

	public GameObject[] ObjectsToDisappear;

	// Use this for initialization
	void Start () {
		if (X) {
			NumEnabled++;
		}

		if (Y) {
			NumEnabled++;
		}

		if (Z) {
			NumEnabled++;
		}
	}

	// Update is called once per frame
	void Update() {
		Vector3 ObjectPosition = MovingObject.GetComponent<Transform>().position;
		Vector3 ThisPosition = GetComponent<Transform>().position;

		float XPer = 0f;
		float YPer = 0f;
		float ZPer = 0f;

		if (X) { // If X is enabled
			if (XOffset > 0) { // If offset is positive relative to this object
				XPer = Mathf.Clamp((XOffset + (ThisPosition.x - ObjectPosition.x)) / XOffset, 0, 1); // fancy maths
				if (AppearAtOffset) // If you want it to appear as you get to the offset
					XPer = Mathf.Abs(1 - XPer);
			}
			else {
				XPer = Mathf.Clamp((XOffset - (ThisPosition.x + ObjectPosition.x)) / XOffset, 0, 1);
				if (AppearAtOffset)
					XPer = Mathf.Abs(1 - XPer);
			}
		}

		if (Y) { // If Y is enabled
			if (YOffset > 0) {
				YPer = Mathf.Clamp((YOffset + (ThisPosition.y - ObjectPosition.y)) / YOffset, 0, 1);
				if (AppearAtOffset)
					YPer = Mathf.Abs(1 - YPer);
			}
			else {
				YPer = Mathf.Clamp((YOffset - (ThisPosition.y + ObjectPosition.y)) / YOffset, 0, 1);
				if (AppearAtOffset)
					YPer = Mathf.Abs(1 - YPer);
			}
		}

		if (Z) { // If Z is enabled
			if (ZOffset > 0) {
				ZPer = Mathf.Clamp((ZOffset + (ThisPosition.z - ObjectPosition.z)) / ZOffset, 0, 1);
				if (AppearAtOffset)
					ZPer = Mathf.Abs(1 - ZPer);
			}
			else {
				ZPer = Mathf.Clamp((ZOffset - (ThisPosition.z + ObjectPosition.z)) / ZOffset, 0, 1);
				if (AppearAtOffset)
					ZPer = Mathf.Abs(1 - ZPer);
			}
		}
		
		double Transparency = System.Math.Round((XPer + YPer + ZPer) / NumEnabled, 2);

		if (Transparency != LastTrans) {
			LastTrans = Transparency;
			float Floated = (float)Transparency;

			for (int i = 0; i < ObjectsToDisappear.Length; i++) {
				Color color = ObjectsToDisappear[i].GetComponent<Renderer>().material.color;
				ObjectsToDisappear[i].GetComponent<Renderer>().material.SetColor("_BaseColor", new Color(color.r, color.g, color.b, Floated));
			}
		}

		/*
		Color color = a.GetComponent<Renderer>().material.color;
		//a.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0f);
		a.GetComponent<Renderer>().sharedMaterial.SetColor("_BaseColor", new Color(0, 0, 0, 0f));
		Debug.Log(a.GetComponent<Renderer>().material.color.a);
		*/
	}
}	
