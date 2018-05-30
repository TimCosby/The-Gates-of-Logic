using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithMouse : MonoBehaviour {

	public Transform Character;	

	public bool RotateH = true;
	public bool RotateV = true;

	public float SpeedH = 2.0f;
	public float SpeedV = 2.0f;

	private float XClamp = 0.0f;

	// Update is called once per frame
	void Update () {
		Cursor.lockState = CursorLockMode.Locked;

		float HorAxis = 0f;
		float VertAxis = 0f;

		if(RotateH)
			HorAxis = SpeedH * Input.GetAxis("Mouse X");
		if(RotateV)
			VertAxis = SpeedV * Input.GetAxis("Mouse Y");

		XClamp -= VertAxis;

		Vector3 CamRotation = transform.rotation.eulerAngles;
		Vector3 CharRotation = Character.transform.rotation.eulerAngles;

		CamRotation.x -= VertAxis;
		CharRotation.y += HorAxis;
		CamRotation.z = 0f;

		if (XClamp > 90) {
			XClamp = 90;
			CamRotation.x = 90;
		}
		else if (XClamp < -90) {
			XClamp = -90;
			CamRotation.x = 270;
		}

		transform.rotation = Quaternion.Euler(CamRotation);
		Character.rotation = Quaternion.Euler(CharRotation);
	}
}
