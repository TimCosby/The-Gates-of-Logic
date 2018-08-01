using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateChooser : Trigger {

	private Dictionary<int, string> GateName;
	private Dictionary<int, GameObject> GateObject;

	public Trigger TouchTrigger;

	public int StartingGate = 0;
	private int CurrentGate;

	public GameObject canvas;
	private UIMenu menu;

	private bool WasTriggered = false;

	// Use this for initialization
	void Start () {
		//canvas = GameObject.FindGameObjectWithTag("UIMenu");
		GateName = new Dictionary<int, string>();
		GateObject = new Dictionary<int, GameObject>();
		menu = canvas.GetComponent<UIMenu>();

		CurrentGate = StartingGate + 1;

		for (int i = 1; i < transform.childCount; i++) {
			Debug.Log(i + " " + transform.GetChild(i).name);
			GateName.Add(i, transform.GetChild(i).name);
			GateObject.Add(i, transform.GetChild(i).gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (TouchTrigger.Triggered) {
			WasTriggered = true;
			GateObject[CurrentGate].SetActive(true);
			menu.EnableUI(GateName[CurrentGate]);

			if (Input.GetKeyDown("space")) {
				GateObject[CurrentGate].SetActive(false);
				if (menu.IsGateActive(GateObject[CurrentGate].GetComponent<Renderer>().sharedMaterial)) {
					menu.ModifyGate(GateName[CurrentGate], 1);
				}

				CurrentGate++;
				if (CurrentGate == transform.childCount) {
					CurrentGate = 1;
				}

				GateObject[CurrentGate].SetActive(true);
				menu.SetFocusGate(GateName[CurrentGate]);

				GateObject[CurrentGate].GetComponent<Renderer>().material = menu.GetGateMaterial(GateName[CurrentGate]);
				if (menu.IsGateActive(GateObject[CurrentGate].GetComponent<Renderer>().sharedMaterial)) {
					menu.ModifyGate(GateName[CurrentGate], -1);
					Triggered = true;
				}
				else {
					Triggered = false;
				}
			}

		}
		else if (WasTriggered) {
			if (!menu.IsGateActive(GateObject[CurrentGate].GetComponent<Renderer>().sharedMaterial)) {
				GateObject[CurrentGate].SetActive(false);
			}
			menu.DisableUI();
		}
	}
}
