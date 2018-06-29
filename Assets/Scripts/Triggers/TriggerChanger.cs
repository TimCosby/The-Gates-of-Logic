using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChanger : MonoBehaviour {

    public Trigger Trigger;
    public float delay;
    private float lastChange;

	// Use this for initialization
	void Start () {
		if (Trigger == null)
        {
            Trigger = GetComponent<Trigger>();
        }
        lastChange = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - lastChange > delay)
        {
            Trigger.Triggered = !Trigger.Triggered;
            lastChange = Time.time;
        }
	}
}
