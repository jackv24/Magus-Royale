using UnityEngine;
using System.Collections;

public class ResumeGameButton : MonoBehaviour
{
	private GameObject gameManager;

	void Start()
	{
        gameManager = GameObject.FindGameObjectWithTag("Game Manager");
	}

	void OnMouseUp()
	{
		TogglePauseGame();
	}

	public void TogglePauseGame()
	{
		gameManager.GetComponent<PauseGame>().TogglePauseGame();
	}
}
