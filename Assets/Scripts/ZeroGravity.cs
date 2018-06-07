using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZeroGravity : MonoBehaviour {

	public RawImage ZeroGravityIcon;
	public float ZeroGravityCharge = 0;
	public float ZeroGravityMax = 100;
	//public float TimeLimit = 0;
	//public float Delay = 0;
	public string[] AffectedObjects;
	//private float TimeStart = -10;
	//private float TimeEnd = -10;
	private bool Toggled = false;
	private bool Unpressed = true;
	public AudioClip BackgroundMusic;
	public AudioClip ZeroGMusic;
	
	// Update is called once per frame
	void Update () {
		float ratio = ZeroGravityCharge / ZeroGravityMax;
		bool GravKey = Input.GetKey(KeyCode.E);

        if (Input.GetKeyDown(KeyCode.E))
        {
            Toggled = !Toggled;

            if (Toggled)
            {
                Debug.Log("On");
                GetComponent<CharacterMovement>().ZeroG = true;

                GetComponent<AudioSource>().clip = ZeroGMusic;
                GetComponent<AudioSource>().Play();
                //TimeStart = Time.time;
                Toggled = true;
                ZeroGravityIcon.GetComponent<ChangingTextureIcon>().Toggled = true;

                for (int i = 0; i < AffectedObjects.Length; i++)
                {
                    GameObject[] Objects = GameObject.FindGameObjectsWithTag(AffectedObjects[i]);
                    for (int j = 0; j < Objects.Length; j++)
                    {
                        Objects[j].GetComponent<Rigidbody>().useGravity = false;
                    }
                }
            }
            else
            {
                Debug.Log("Off");
                GetComponent<CharacterMovement>().ZeroG = false;

                GetComponent<AudioSource>().clip = BackgroundMusic;
                GetComponent<AudioSource>().Play();
                //TimeEnd = Time.time;
                Toggled = false;
                ZeroGravityIcon.GetComponent<ChangingTextureIcon>().Toggled = false;

                for (int i = 0; i < AffectedObjects.Length; i++)
                {
                    GameObject[] Objects = GameObject.FindGameObjectsWithTag(AffectedObjects[i]);
                    for (int j = 0; j < Objects.Length; j++)
                    {
                        Objects[j].GetComponent<Rigidbody>().useGravity = true;
                    }
                }
            }
        }
        /*
        if (Toggled && (Input.GetKeyUp(KeyCode.E) || ZeroGravityCharge == 0)) {
			Debug.Log("Off");
			GetComponent<CharacterMovement>().ZeroG = false;
			
			GetComponent<AudioSource>().clip = BackgroundMusic;
			GetComponent<AudioSource>().Play();
			//TimeEnd = Time.time;
			Toggled = false;
			ZeroGravityIcon.GetComponent<ChangingTextureIcon>().Toggled = false;

			for (int i = 0; i < AffectedObjects.Length; i++) {
				GameObject[] Objects = GameObject.FindGameObjectsWithTag(AffectedObjects[i]);
				for (int j = 0; j < Objects.Length; j++) {
					Objects[j].GetComponent<Rigidbody>().useGravity = true;
				}
			}
		}
		else if (Unpressed && !Toggled && GravKey && ZeroGravityCharge == 100) {
			Debug.Log("On");
			GetComponent<CharacterMovement>().ZeroG = true;

			GetComponent<AudioSource>().clip = ZeroGMusic;
			GetComponent<AudioSource>().Play();
			//TimeStart = Time.time;
			Toggled = true;
			ZeroGravityIcon.GetComponent<ChangingTextureIcon>().Toggled = true;
		}

		if (Toggled) {
			ZeroGravityBar.enabled = true;
			if (ZeroGravityCharge != 0) {
				ZeroGravityCharge -= 1;
			}
			for (int i = 0; i < AffectedObjects.Length; i++) {
				GameObject[] Objects = GameObject.FindGameObjectsWithTag(AffectedObjects[i]);
				for (int j = 0; j < Objects.Length; j++) {
					Objects[j].GetComponent<Rigidbody>().useGravity = false;
				}
			}
		} else {
			if (ZeroGravityCharge != ZeroGravityMax) {
				ZeroGravityCharge += 1;
				ZeroGravityBar.enabled = true;
			} else {
				ZeroGravityBar.enabled = false;
			}
		}
        */
	}
}
