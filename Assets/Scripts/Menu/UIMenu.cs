using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour {

	private Dictionary<string, GameObject> GateObject;
	private Dictionary<string, int> GateQuantity;
	private Dictionary<string, int> GateSelect;

	public bool AND = true;
	public bool OR = true;
	public bool XOR = true;

	public int[] DefaultValues;

	public Material OutOfStock;
	public Material InStock;

	public GameObject PlayerObject;

	private string CurrentGate = "AND Gate";

	private GameObject Selector;
	private Transform Gates;

	// Use this for initialization
	void Start () {
		GateObject = new Dictionary<string, GameObject>();
		GateQuantity = new Dictionary<string, int>();
		GateSelect = new Dictionary<string, int>();
		Selector = transform.GetChild(2).gameObject;
		Gates = transform.GetChild(3);

		GateSelect.Add(Gates.GetChild(0).name, 0);
		GateSelect.Add(Gates.GetChild(1).name, 100);
		GateSelect.Add(Gates.GetChild(2).name, -100);

		for (int i = 0; i < Gates.childCount; i++) {
			Transform GateChild = Gates.GetChild(i);
			GateObject.Add(GateChild.name, GateChild.gameObject);
			if (DefaultValues.Length > i) {
				GateQuantity.Add(GateChild.name, DefaultValues[i]);
			}
			else {
				GateQuantity.Add(GateChild.name, 0);
			}

			if (GateQuantity[GateChild.name] == 0) {
				GateObject[GateChild.name].GetComponent<Image>().color = OutOfStock.color;
			}
			else {
				GateObject[GateChild.name].GetComponent<Image>().color = InStock.color;
			}
			UpdateText(GateChild.name);
		}
	}

	public void EnableUI(string Gate) {
		PlayerObject.GetComponent<CharacterMovement>().ModifyJump(false);
		for (int i = 0; i <= Gates.childCount; i++) {
			transform.GetChild(i).gameObject.SetActive(true);
		}
		SetFocusGate(Gate);
	}

	public void DisableUI() {
		PlayerObject.GetComponent<CharacterMovement>().ModifyJump(true);
		for (int i = 0; i <= Gates.childCount; i++) {
			transform.GetChild(i).gameObject.SetActive(false);
		}
	}

	public void ModifyGate(string Gate, int Adjustment) {
		GateQuantity[Gate] += Adjustment;

		if (GateQuantity[Gate] == 0) {
			GateObject[Gate].GetComponent<Image>().color = OutOfStock.color;
		}
		else {
			GateObject[Gate].GetComponent<Image>().color = InStock.color;
		}

		UpdateText(Gate);
	}

	public int GetGateQuantity(string Gate) {
		return GateQuantity[Gate];
	}

	public Material GetGateMaterial(string Gate) {
		if (GateQuantity[Gate] == 0) {
			return OutOfStock;
		}
		else {
			return InStock;
		}
	}

	public bool IsGateActive(Material material) {
		return material == InStock;
	}

	public string GetFocusGate() {
		return CurrentGate;
	}

	public void SetFocusGate(string Gate) {
		GateObject[CurrentGate].transform.GetChild(0).gameObject.SetActive(false);
		CurrentGate = Gate;
		GateObject[CurrentGate].transform.GetChild(0).gameObject.SetActive(true);
		Vector3 SelectorPos = Selector.GetComponent<RectTransform>().anchoredPosition;

		SelectorPos.x = GateSelect[Gate];

		Selector.GetComponent<RectTransform>().anchoredPosition = SelectorPos;
	}

	private void UpdateText(string Gate) {
		Transform GateText = GateObject[Gate].transform.GetChild(0);
		string TempText = GateText.GetComponent<Text>().text;
		GateText.GetComponent<Text>().text = TempText.Substring(0, TempText.Length - 1) + GateQuantity[Gate];

		if (GateQuantity[Gate] != 0) {
			GateText.GetComponent<Text>().color = new Color32(25, 142, 35, 255);
		}
		else {
			GateText.GetComponent<Text>().color = new Color32(183, 28, 28, 255);
		}
	}
}
