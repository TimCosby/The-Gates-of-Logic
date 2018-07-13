using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (EventSystem.current.IsPointerOverGameObject()) {
			Debug.Log("nu");
			if (Input.GetMouseButtonDown(0)) {
				Debug.Log("ecchi");
			}
		}
	}
}
