using UnityEngine;
using System.Collections;

/*Save the camera background colour on start, then Lerps back to it OnMouseExit.*/

public class ReturnMenuColour : MonoBehaviour 
{
	private Color startColour;

	private bool isMouseOver = true;

	void Start () 
	{
		startColour = Camera.main.backgroundColor;
	}

	void Update () 
	{
		if(!isMouseOver)
			Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor, startColour, 0.25f);
	}

	void OnMouseEnter()
	{
		isMouseOver = true;
	}

	void OnMouseExit()
	{
		isMouseOver = false;
	}
}
