using UnityEngine;
using System.Collections.Generic;

public class CharacterMovement : MonoBehaviour {

	//public Camera CharacterCamera;
	//public Camera OverviewCamera;
	//private bool SwappedCam = false;

    //public Rigidbody Player;
    private CharacterController Character;

	// Force of jumps
    private float JumpForce = 8;
	// Force of movement
	private float MovementForce = 5;

	// Force of gravity
	private float UpwardGravity = 16f;
	private float DownwardGravity = 12f;
	//public float LowerUpwardGravity = 2f;
	//public float LowerDownwardGravity = .5f;
   	// Delay before you can jump again
    private float JumpDelay = 0f;
	private float LastJumpTime = -100f;

	//public bool ZeroG;
	private float YVelocity;
	private bool JumpBool;
	private bool AllowJump = true;

	// Use this for initialization
	void Start () {
        Character = GetComponent<CharacterController>();
	}

	private void FixedUpdate()
    {
		Cursor.visible = false;
		/*bool SwitchCamera = Input.GetKey(KeyCode.Tab);

		if (SwitchCamera) {
			if (!SwappedCam) {
				SwappedCam = true;
				OverviewCamera.GetComponent<Camera>().enabled = CharacterCamera.GetComponent<Camera>().enabled;
				CharacterCamera.GetComponent<Camera>().enabled = !CharacterCamera.GetComponent<Camera>().enabled;
			}
		}
		else {
			SwappedCam = false;
		}*/

		// Player Movement
		MovePlayer();
		// Player Jumps
		JumpPlayer();
	}

	private void MovePlayer() {
		float Hori = Input.GetAxis("Horizontal");
		float Vert = Input.GetAxis("Vertical");

		Character.transform.position += Hori * transform.right * MovementForce * Time.deltaTime;
		Character.transform.position += Vert * transform.forward * MovementForce * Time.deltaTime;
	}

	private void JumpPlayer() {
		JumpBool = Input.GetKey("space");

		if (Character.isGrounded) {
			// When Player is on the ground
			GroundActions();
		}
		else {
			// When Player is in the air
			/*if (ZeroG) {
				LowerGravityActions();
			}
			else {*/
				AirActions();
			//}
		}

		Character.Move(new Vector3(0f, YVelocity, 0f) * Time.deltaTime);
	}

	private void GroundActions() {
		if (AllowJump && JumpBool && (Time.time - LastJumpTime) > JumpDelay) {
			// If jumped, increase velocity by the standard Y Force
			YVelocity = JumpForce;
			// Delay between hitting floor and next jump
			LastJumpTime = Time.time;
		}
	}

	private void AirActions() {
		if (YVelocity >= 0) {
			if (Character.velocity.y == 0) {
				YVelocity = -UpwardGravity * Time.deltaTime;
			}
			YVelocity -= UpwardGravity * Time.deltaTime;
		}
		else {
			YVelocity -= DownwardGravity * Time.deltaTime;
		}
	}

	public void DisableJump() {
		AllowJump = false;
	}

	public void ModifyJump(bool modifier) {
		AllowJump = modifier;
	}

	/*private void LowerGravityActions() {
		if (YVelocity >= 0) {
			YVelocity -= LowerUpwardGravity * Time.deltaTime;
		}
		else {
			YVelocity -= LowerDownwardGravity * Time.deltaTime;
		}
	}*/
}
