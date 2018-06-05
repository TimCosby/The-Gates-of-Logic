using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangingTextureIcon : MonoBehaviour {

	public bool Toggled = false;
	public Texture[] Textures;
	public RawImage Icon;

	// Use this for initialization
	void Start () {
		Icon = GetComponent<RawImage>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Toggled) {
			Icon.texture = Textures[1];
		} else {
			Icon.texture = Textures[0];
		}
	}
}