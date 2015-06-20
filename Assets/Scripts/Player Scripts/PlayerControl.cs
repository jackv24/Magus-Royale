using UnityEngine;
using System.Collections;

/* Reads directional input from the player, from the keyboard or controller, and calculates
 * a normalised input vector to be passed to PlayerMotor. Also handles other character-related
 * inputs such as jumping, attacking and using items. */

public class PlayerControl : MonoBehaviour
{
    public bool LocallyControlled = false;
    public float TargetDistance = 25f;

	[HideInInspector]
    public Vector2 InputVector = Vector2.zero;

    private PlayerBehaviour playerBehaviour;

	void Start ()
    {
        if (LocallyControlled)
            Camera.main.GetComponent<CameraOrbit>().Player = gameObject;

        playerBehaviour = GetComponent<PlayerBehaviour>();
	}

	void Update ()
    {
        //If this is the locally controlled player
        if (LocallyControlled)
        {
            //If game isn't paused, take and normalise input
            if (!Properties.IsGamePaused)
            {
                InputVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

                if (InputVector.magnitude > 1 || InputVector.magnitude < -1)
                    InputVector.Normalize();

                //Get attack input
                if (Input.GetButtonDown("Attack 1"))
                    playerBehaviour.Attack();
            }
            else
                InputVector = Vector2.Lerp(InputVector, Vector2.zero, 0.25f);
        }
	}
}
