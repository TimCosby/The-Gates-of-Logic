using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GateQuantityManager : MonoBehaviour {

	private GameObject QuantityObject;
	private int Children;
	private int[] GateQuantity;
	public int[] DefaultQuantities;

	// Use this for initialization
	void Start () {
		QuantityObject = transform.GetChild(0).gameObject;

		Children = transform.childCount - 2;

		GateQuantity = new int[Children];
		for (int i = 0; i < Children; i++) {
			GateQuantity[i] = 0;
			if (i < DefaultQuantities.Length) {
				GateQuantity[i] += DefaultQuantities[i];
			}
		}
	}

	public int GetGate(int index) {
		if (0 <= index && index <= Children)
			return GateQuantity[index];
		else {
			return -1;
		}
	}

	public void ModifyGate(int index, int change) {
		if (0 <= index && index <= Children) {
			GateQuantity[index] += change;
		}
	}
}
