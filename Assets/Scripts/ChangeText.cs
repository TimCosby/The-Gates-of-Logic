using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeText : MonoBehaviour {

	private TextMesh Text;
	public string OffText;
	public string OnText;
	public Trigger Trigger;

	private void Start() {
		Text = GetComponent<TextMesh>();
		if (Trigger == null) {
			Trigger = GetComponent<Trigger>();
		}
	}

	// Update is called once per frame
	void Update () {
		if (Trigger.Triggered) {
			Text.text = OnText;
		}
		else {
			Text.text = OffText;
		}
	}
}
