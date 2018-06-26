using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Menu : MonoBehaviour {

	private GameObject PlayerMenu;
	private int Children;
	private int CurrentGate;
	private GameObject QuantityObject;
	private GameObject[] GateHUD;
	private GameObject[] GateObject;
	private Trigger Trigger;

	// Use this for initialization
	void Start () {
		PlayerMenu = GameObject.FindGameObjectWithTag("Player").transform.GetChild(2).gameObject;

		Children = PlayerMenu.transform.childCount;
		CurrentGate = Children - 2;

		GateHUD = new GameObject[Children - 1];
		GateObject = new GameObject[Children - 2];

		QuantityObject = PlayerMenu.transform.GetChild(0).gameObject;

		for (int i = 1; i < Children; i++) { // Get all the gates
			GateHUD[i - 1] = PlayerMenu.transform.GetChild(i).gameObject;
			if (i != Children - 1) {
				GateObject[i - 1] = transform.GetChild(i).gameObject;
			}
		}

		Trigger = transform.GetChild(0).GetComponent<Trigger>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Trigger.Triggered) {
			if (CurrentGate != Children - 2) {
				GateObject[CurrentGate].SetActive(true);
			}

			if (Input.GetMouseButtonDown(0)) {
				GateHUD[CurrentGate].SetActive(false);

				if (CurrentGate != Children - 2) { // If gate existed
					GateObject[CurrentGate].SetActive(false);
					if (GateObject[CurrentGate].GetComponent<Trigger>().Triggered) {
						PlayerMenu.GetComponent<GateQuantityManager>().ModifyGate(CurrentGate, 1);
					}
				}

				CurrentGate++;

				if (CurrentGate == Children - 1) { // If is None
					CurrentGate = 0;
				}

				if (CurrentGate != Children - 2) { // If regular gate
					int tempQuantity = PlayerMenu.GetComponent<GateQuantityManager>().GetGate(CurrentGate);
					if (tempQuantity > 0) {
						QuantityObject.GetComponent<TextMeshPro>().text = tempQuantity - 1 + QuantityObject.GetComponent<TextMeshPro>().text.Substring(1);
						PlayerMenu.GetComponent<GateQuantityManager>().ModifyGate(CurrentGate, -1);
						GateObject[CurrentGate].GetComponent<Trigger>().Triggered = true;
					}
					else {
						QuantityObject.GetComponent<TextMeshPro>().text = tempQuantity + QuantityObject.GetComponent<TextMeshPro>().text.Substring(1);
						GateObject[CurrentGate].GetComponent<Trigger>().Triggered = false;
					}
					GateObject[CurrentGate].SetActive(true);

					QuantityObject.SetActive(true);
				}
				else {
					QuantityObject.SetActive(false);
				}

				GateHUD[CurrentGate].SetActive(true);
			}
		}
		else if (CurrentGate != Children - 2 && !GateObject[CurrentGate].GetComponent<Trigger>().Triggered) {
			GateObject[CurrentGate].SetActive(false);
		}
	}
}
