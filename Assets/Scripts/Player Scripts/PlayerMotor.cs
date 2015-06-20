using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerControl))]

/* Takes in an input vector, and calculates a movement vector based on movement speed,
 * gravity and jumping. */

[RequireComponent(typeof(CharacterController))]
public class PlayerMotor : MonoBehaviour
{
	public GameObject PlayerGraphic;

	private CharacterController controller;
	private PlayerControl playerControl;
	
	public float MoveSpeed = 10.0f;
	public float RotationSmoothness = 0.25f;
	public float Gravity = 9.8f;
	public float JumpSpeed = 3.0f;
	
	private Vector2 inputVector = Vector2.zero;
	private Vector3 moveVector = Vector3.zero;

	void Start ()
	{
		controller = GetComponent<CharacterController>();
		playerControl = GetComponent<PlayerControl>();

        if (PlayerGraphic == null)
            Debug.Log("No player graphic has been assigned!");
	}
	
	void Update ()
	{
		Vector3 camForward = Camera.main.transform.forward;
		camForward.y = 0;
		camForward.Normalize();
		
		Vector3 camRight = Camera.main.transform.right;
		camRight.y = 0;
		camRight.Normalize();
		
		moveVector.x = 0;
		moveVector.z = 0;
		
		UpdateInputVector();

        //If moving backwards, slow moveVector to a walking pace
        if (inputVector.y < 0)
        {
            moveVector += (inputVector.y / 2) * camForward;
            moveVector += (inputVector.x / 1.5f) * camRight;
        }
        else
        {
            moveVector += inputVector.y * camForward;
            moveVector += inputVector.x * camRight;
        }
		
        //If player is grounded
		if(controller.isGrounded)
		{
            //Reset Y velocity
			moveVector.y = 0;
			
            //Apply an upward force when the player presses the jump button
			if(Input.GetButton("Jump") && !Properties.IsGamePaused && playerControl.LocallyControlled)
				moveVector.y = JumpSpeed;
		}
		moveVector.y -= Gravity * Time.deltaTime;

		controller.Move(moveVector * MoveSpeed * Time.deltaTime);

        if (PlayerGraphic != null && PlayerGraphic.GetComponent<Animator>() != null)
            AnimatePlayer();

		//Rotate player away from camera when moving
		if (new Vector3(moveVector.x, 0, moveVector.z) != Vector3.zero)
		{
			Quaternion rotateTo = Quaternion.Euler(transform.rotation.eulerAngles.x, Camera.main.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

			transform.rotation = Quaternion.Slerp(transform.rotation, rotateTo, RotationSmoothness);
		}
		
	}

    private float timer = 0f;
    private float speedX = 0f;
    private float speedY = 0f;

    void AnimatePlayer()
    {
        speedX = Mathf.Lerp(speedX, inputVector.x, 0.25f);
        speedY = Mathf.Lerp(speedY, inputVector.y, 0.25f);

        PlayerGraphic.GetComponent<Animator>().SetFloat("SpeedX", speedX);
        PlayerGraphic.GetComponent<Animator>().SetFloat("SpeedY", speedY);

        timer += Time.deltaTime;

        if (controller.velocity != Vector3.zero)
        {
            PlayerGraphic.GetComponent<Animator>().SetBool("Dancing", false);
            timer = 0;
        }

        if (timer > 30.0f && controller.velocity == Vector3.zero)
        {
            PlayerGraphic.GetComponent<Animator>().SetBool("Dancing", true);
            timer = 0;
        }

        if (Input.GetKeyDown(KeyCode.G))
            timer = 30.0f;
    }

	void UpdateInputVector()
	{
		inputVector = playerControl.InputVector;
	}
}
