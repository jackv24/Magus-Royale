using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour
{
	public GameObject PauseMenu;

	void Start ()
	{
        PauseMenu = GameObject.Find("PauseMenu");
        Screen.lockCursor = true;
	}
	

	void Update ()
	{
		if(Input.GetButtonDown("Pause"))
		{
			TogglePauseGame();
		}
	}

	public void TogglePauseGame()
	{
		if(!Properties.IsGamePaused)
		{
			Properties.IsGamePaused = true;
            Screen.lockCursor = false;
			PauseMenu.GetComponent<ToggleMenu>().OpenMenu();
		}
		else if(Properties.IsGamePaused)
		{
			Properties.IsGamePaused = false;
            Screen.lockCursor = true;
			PauseMenu.GetComponent<ToggleMenu>().CloseMenu();
		}
	}
}
