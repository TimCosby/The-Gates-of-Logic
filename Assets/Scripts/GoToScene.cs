using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour {

	public Trigger Trigger;
	public string SceneName;

	// Use this for initialization
	void Start () {
		if (Trigger == null) {
			Trigger = GetComponent<Trigger>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Trigger.Triggered) {
			SceneManager.LoadScene(SceneName);
		}
	}
}
