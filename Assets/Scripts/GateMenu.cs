using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GateMenu : MonoBehaviour {

	private Dictionary<string, GameObject> GateObject;
	private Dictionary<string, int> GateQuantity;
	private int NumOfGates = 0;

	public Material OutOfStock;
	public Material InStock;

	public int[] DefaultValues;

	// Use this for initialization
	void Start () {
		GateObject = new Dictionary<string, GameObject>();
		GateQuantity = new Dictionary<string, int>();

		NumOfGates = transform.childCount;

		string tempName;
		for (int i = 0; i < NumOfGates; i++) {
			Transform tempObject = transform.GetChild(i);
			tempName = tempObject.name;
			tempName = tempName.Substring(0, tempName.IndexOf(" "));
		
			GateObject.Add(tempName, tempObject.gameObject);
			GateObject[tempName].GetComponent<Renderer>().material = OutOfStock;

			if (DefaultValues.Length > i) {
				GateQuantity.Add(tempName, DefaultValues[i]);
				if (DefaultValues[i] > 0) {
					tempObject.GetChild(0).GetComponent<TextMeshPro>().text = DefaultValues[i].ToString();
					GateObject[tempName].GetComponent<Renderer>().material = InStock;
				}
			}
			else {
				GateQuantity.Add(tempName, 0);
			}
		}
	}

	public void ModifyGate(string Gate, int Num) { // Edit the number of gates available for type <Gate>
		if (GateQuantity.ContainsKey(Gate)) {
			GateQuantity[Gate] += Num;
			GateObject[Gate].transform.GetChild(0).GetComponent<TextMeshPro>().text = GateQuantity[Gate].ToString();

			if (GateQuantity[Gate] == 0) { // If no more usable gates of this type
				GateObject[Gate].GetComponent<Renderer>().material = OutOfStock;
			}
			else { // If not quantity 0
				GateObject[Gate].GetComponent<Renderer>().material = InStock;
			}
		}
	}

	public int GetGateQuantity(string Gate) {
		if (GateQuantity.ContainsKey(Gate)) {
			return GateQuantity[Gate];
		}
		else {
			return -1;
		}
	}

	public bool IsGateActive(string Gate, Material mat) {
		return mat == InStock;
	}

	public Material GetGateMaterial(string Gate) {
		if (GateQuantity[Gate] == 0) {
			return OutOfStock;
		}
		else {
			return InStock;
		}
	}
}
