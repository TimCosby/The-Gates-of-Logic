using UnityEngine;
using System.Collections.Generic;

public class CharacterMovement : MonoBehaviour {

	public Camera CharacterCamera;
	public Camera OverviewCamera;

    //public Rigidbody Player;
    private CharacterController Character;

	// Force of jumps
    public float JumpForce;
	// Force of movement
	public float MovementForce;

	// Current 3D velocities
    private float XVelocity;
	private float YVelocity;
	private float ZVelocity;

	// Force of gravity
    public float GForce = 9.8f;
	// Delay before you can jump again
    public float JumpDelay;
	private float LastJumpTime;

	private bool JumpBool;

	// Use this for initialization
	void Start () {
        Character = GetComponent<CharacterController>();
	}

	private void FixedUpdate()
    {
		bool SwitchCamera = Input.GetKey(KeyCode.Tab);

		if (SwitchCamera) {
			OverviewCamera.GetComponent<Camera>().enabled = true;
			CharacterCamera.GetComponent<Camera>().enabled = false;
		}
		else {
			OverviewCamera.GetComponent<Camera>().enabled = false;
			CharacterCamera.GetComponent<Camera>().enabled = true;

			// Player Movement
			MovePlayer();
			// Player Jumps
			//JumpPlayer();
		}
	}

	private void MovePlayer() {
		float Hori = Input.GetAxis("Horizontal");
		float Vert = Input.GetAxis("Vertical");

		Vector3 MoveDirSide = transform.right * Hori * MovementForce;
		Vector3 MoveDirForward = transform.forward * Vert * MovementForce;

		Character.SimpleMove(MoveDirSide);
		Character.SimpleMove(MoveDirForward);
	}

	private void JumpPlayer() {
		JumpBool = Input.GetKey("space");

		if (Character.isGrounded) {
			// When Player is on the ground
			GroundActions();
		}
		else {
			// When Player is in the air
			AirActions();
		}

		//Character.Move(new Vector3(0f, YVelocity, 0f) * Time.deltaTime);
	}

	private void GroundActions() {
		if (YVelocity != 0) { // Reset Z Velocity
			YVelocity = 0;
		}

		if (JumpBool && (Time.time - LastJumpTime) > JumpDelay) {
			// If jumped, increase velocity by the standard Y Force
			YVelocity = JumpForce;
		}
	}

	private void AirActions() {
		if (Character.velocity.y == 0 && YVelocity > 0) {
			// If top of player hits something, stop going up
			YVelocity = -GForce * Time.deltaTime;
		}
		else {
			// Delay between hitting floor and next jump
			LastJumpTime = Time.time;
		}

		// Decrease vertical accelleration
		YVelocity -= GForce * Time.deltaTime;
	}
}
