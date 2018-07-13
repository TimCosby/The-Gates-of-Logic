﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Menu : MonoBehaviour {

	private GameObject PlayerObject;
	private GateMenu PlayerMenu;
	private int Children;
	private int CurrentGate;
	private GameObject[] GateObject;
	private Trigger Trigger;
	private bool DidTurnOff = true;
	public int DefaultGate = 0;

	// Use this for initialization
	void Start () {
		PlayerObject = GameObject.FindGameObjectWithTag("UIMenu").gameObject;
		PlayerObject.SetActive(false);
		PlayerMenu = PlayerObject.GetComponent<GateMenu>();

		Children = PlayerObject.transform.childCount + 1;
		CurrentGate = DefaultGate;

		GateObject = new GameObject[Children];

		Trigger = transform.GetChild(0).gameObject.GetComponent<Trigger>();

		for (int i = 1; i < Children; i++) { // Get all the gates
			GateObject[i] = transform.GetChild(i).gameObject;
		}

		if (CurrentGate != 0) {
			string tempName = GateObject[CurrentGate].name;
			tempName = tempName.Substring(0, tempName.IndexOf(" "));
			GateObject[CurrentGate].SetActive(true);
		}
	}
	
	// Update is called once per frame
	void Update () {
		string tempName;

		if (Trigger.Triggered) {
			DidTurnOff = false;
			PlayerObject.SetActive(true);
			PlayerObject.transform.parent.GetComponent<CharacterMovement>().ModifyJump(false);

			if (CurrentGate != 0) {
				GateObject[CurrentGate].SetActive(true);
			}

			if (Input.GetKeyDown("space")) {
				if (CurrentGate != 0) {
					GateObject[CurrentGate].SetActive(false);
					tempName = GateObject[CurrentGate].name;
					tempName = tempName.Substring(0, tempName.IndexOf(" "));
					if (PlayerMenu.IsGateActive(tempName, GateObject[CurrentGate].GetComponent<Renderer>().sharedMaterial)) {
						PlayerMenu.ModifyGate(tempName, 1);
					}
				}

				CurrentGate++;

				if (CurrentGate == Children) {
					CurrentGate = 0;
				}
				else {
					tempName = GateObject[CurrentGate].name;
					tempName = tempName.Substring(0, tempName.IndexOf(" "));
					GateObject[CurrentGate].GetComponent<Renderer>().material = PlayerMenu.GetGateMaterial(tempName);

					if (PlayerMenu.IsGateActive(tempName, GateObject[CurrentGate].GetComponent<Renderer>().sharedMaterial)) {
						PlayerMenu.ModifyGate(tempName, -1);
					}
				}
			}
		}
		else if (!DidTurnOff) {
			DidTurnOff = true;
			if (CurrentGate != 0) {
				tempName = GateObject[CurrentGate].name;
				tempName = tempName.Substring(0, tempName.IndexOf(" "));

				if (!PlayerMenu.IsGateActive(tempName, GateObject[CurrentGate].GetComponent<Renderer>().sharedMaterial)) {
					GateObject[CurrentGate].SetActive(false);
				}
			}

			PlayerObject.SetActive(false);
			PlayerObject.transform.parent.GetComponent<CharacterMovement>().ModifyJump(true);
		}
	}
}
