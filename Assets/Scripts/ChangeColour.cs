using UnityEngine;

public class ChangeColour : MonoBehaviour {

	private Trigger Trigger;
	public Material[] ObjectMaterial;
	Renderer rend;

	// Use this for initialization
	void Start () {
		Trigger = GetComponent<Trigger>();
		rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(rend != null)
			if (Trigger.Triggered) {
				rend.sharedMaterial = ObjectMaterial[0];
			}
			else {
				rend.sharedMaterial = ObjectMaterial[1];
			}
	}
}
