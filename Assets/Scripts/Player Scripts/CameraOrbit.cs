using UnityEngine;
using System.Collections;

/* Reads in mouse input, and therefore orbits the camera based on that input. */

public class CameraOrbit : MonoBehaviour
{
    [HideInInspector]
    public GameObject Player;

    public float CameraDistance = 6.0f;
    public float CameraDistanceMin = 1.0f;
    public float CameraDistanceMax = 10.0f;

    public float CameraHeight = 1.5f;
    public float CameraSensitivity = 150.0f;
    public float CameraRotationY = 15.0f;

    public float CameraPitch = 0.0f;
    public float CameraPitchMin = -5.0f;
    public float CameraPitchMax = 60.0f;

    public float CameraZoomSpeed = 10.0f;

	void LateUpdate ()
    {
        //Don't do anything if no player is registered.
        if (Player == null)
            return;

		if(!Properties.IsGamePaused)
		{
			//Orbit camera with inputs
	        OrbitWithMouseInput();
	        OrbitWithControllerInput();

	        //Zoom
	        if (Input.GetAxisRaw("Zoom") > 0)
	            CameraDistance -= CameraZoomSpeed * Time.deltaTime;
	        else if (Input.GetAxisRaw("Zoom") < 0)
	            CameraDistance += CameraZoomSpeed * Time.deltaTime;
		}
        CameraDistance = Mathf.Clamp(CameraDistance, CameraDistanceMin, CameraDistanceMax);

        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);
        transform.position += transform.rotation * Vector3.back * CameraDistance;
        transform.position += Vector3.up * CameraHeight;
	}

    void OrbitWithMouseInput()
    {
#if !UNITY_PSM
        //Move camera up/down
        CameraPitch -= Input.GetAxis("Mouse Y") * CameraSensitivity * Time.deltaTime;
        CameraPitch = Mathf.Clamp(CameraPitch, CameraPitchMin, CameraPitchMax);

        //Move camera left/right
        transform.localEulerAngles = new Vector3(CameraPitch, transform.localEulerAngles.y + Input.GetAxis("Mouse X") * CameraSensitivity * Time.deltaTime, 0);
        transform.localEulerAngles = new Vector3(CameraPitch, transform.localEulerAngles.y, 0);
#endif
    }

    void OrbitWithControllerInput()
    {
        //Move camera up/down based on Right Stick Vertical
        CameraPitch -= Input.GetAxis("R_Stick_Vertical") * CameraSensitivity * Time.deltaTime;

        CameraPitch = Mathf.Clamp(CameraPitch, CameraPitchMin, CameraPitchMax);

        //Move camera left/right based on Right Stick Horizontal
        transform.localEulerAngles = new Vector3(CameraPitch, transform.localEulerAngles.y + Input.GetAxis("R_Stick_Horizontal") * CameraSensitivity * Time.deltaTime, 0);
    }
}
