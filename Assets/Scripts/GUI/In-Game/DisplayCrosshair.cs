using UnityEngine;
using System.Collections;

public class DisplayCrosshair : MonoBehaviour
{
	public Texture2D Crosshair;

	void OnGUI()
	{
        if(!Properties.IsGamePaused)
		    GUI.DrawTexture(new Rect((Screen.width / 2) - (Crosshair.width / 2), (Screen.height / 2) - (Crosshair.height / 2), Crosshair.width, Crosshair.height), Crosshair, ScaleMode.StretchToFill);
	}
}
