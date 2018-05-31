using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePhysicsMaterial: MonoBehaviour {

	public PhysicMaterial newMaterial;
	public PhysicMaterial oldMaterial;
	public string[] TriggerTags;

	private void OnTriggerEnter(Collider other) {
		for (int i = 0; i < TriggerTags.Length; i++) {
			if (other.tag == TriggerTags[i]) {
				other.material = newMaterial;
				break;
			}
		}
	}

	private void OnTriggerExit(Collider other) {
		for (int i = 0; i < TriggerTags.Length; i++) {
			if (other.tag == TriggerTags[i]) {
				other.material = oldMaterial;
				break;
			}
		}
	}
}
