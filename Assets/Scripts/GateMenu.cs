using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections.Specialized;

public class GateMenu : MonoBehaviour {

	public bool AND = true;
	public bool OR = true;
	public Trigger Trigger;
	private int CurrentGate = 1;

	private Dictionary<string, int> Quantity;
	private Dictionary<string, GameObject> Gates;
	private Transform QuantityObject;

	// Use this for initialization
	void Start () {
		Quantity = new Dictionary<string, int>();
		Gates = new Dictionary<string, GameObject>();
		Trigger = GetComponent<Trigger>();
		QuantityObject = transform.GetChild(0);

		Gates.Add("EMPTY", transform.GetChild(1).gameObject);

		Quantity.Add("AND", 0);
		Gates.Add("AND", transform.GetChild(2).gameObject);
		Quantity.Add("OR", 1);
		Gates.Add("OR", transform.GetChild(3).gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			if (CurrentGate == 0) { // Switching from OR to None
				QuantityObject.gameObject.SetActive(false);

				Gates["OR"].SetActive(false);
				Gates["EMPTY"].SetActive(true);
			}
			else if (CurrentGate == 1) { // Switching from None to AND 
				QuantityObject.gameObject.SetActive(true);

				Gates["EMPTY"].SetActive(false);
				Gates["AND"].SetActive(true);

				int tempQuantity = Quantity["AND"];
				if (tempQuantity == 0) {
					Trigger.Triggered = false;
				}
				else {
					Trigger.Triggered = true;
				}

				QuantityObject.GetComponent<TextMeshPro>().SetText(tempQuantity.ToString());
			}
			else if (CurrentGate == 2) {
				QuantityObject.gameObject.SetActive(true);

				Gates["AND"].SetActive(false);
				Gates["OR"].SetActive(true);

				int tempQuantity = Quantity["OR"];
				if (tempQuantity == 0) {
					Trigger.Triggered = false;
				}
				else {
					Trigger.Triggered = true;
				}

				QuantityObject.GetComponent<TextMeshPro>().SetText(tempQuantity.ToString());
				CurrentGate = -1;
			}

			CurrentGate++;
		}
	}

	public void AddItem(string gate, int quantity) {
		Quantity[gate] += quantity;
	}
}
