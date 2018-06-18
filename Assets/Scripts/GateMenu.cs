using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GateMenu : MonoBehaviour {

	private short CurrentGate = 0;
	private short EnableSize = 0;
	private Hashtable Quantity;
	private Hashtable Gates;
	private Transform QuantityObject;
	public bool AND = true;
	public bool OR = true;

	// Use this for initialization
	void Start () {
		Quantity = new Hashtable();
		Gates = new Hashtable();
		QuantityObject = transform.GetChild(0);

		Gates.Add(EnableSize, transform.GetChild(1).gameObject);

		if (AND) {
			EnableSize++;
			Quantity.Add(EnableSize, 0);
			Gates.Add(EnableSize, transform.GetChild(2).gameObject);
		}
		if (OR) {
			EnableSize++;
			Quantity.Add(EnableSize, 1);
			Gates.Add(EnableSize, transform.GetChild(3).gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (enabled) {
			if (Input.GetMouseButtonDown(0)) {
				((GameObject)Gates[CurrentGate]).SetActive(false);

				if (CurrentGate == 0) {
					QuantityObject.gameObject.SetActive(true);
				}

				CurrentGate++;

				if (CurrentGate > EnableSize) {
					QuantityObject.gameObject.SetActive(false);
					CurrentGate = 0;
				}
				else {
					QuantityObject.gameObject.GetComponent<TextMeshPro>().text = ((int)(Quantity[CurrentGate])).ToString();
				}

				((GameObject)Gates[CurrentGate]).SetActive(true);
			}
		}
	}
}
