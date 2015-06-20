using UnityEngine;
using System.Collections;

/*Loads a scene on click, or when called by ButtonControlMenu.*/

public class MenuLoadScene : MonoBehaviour
{
	public string SceneName;
	public float Delay = 0.0f;

	void OnMouseUp ()
	{
		LoadScene();
	}

	public void LoadScene()
	{
		if(SceneName == "Quit")
			Application.Quit();

		transform.parent.GetComponent<ToggleMenu>().CloseMenu();

		StartCoroutine("LoadLevel");
	}

	IEnumerator LoadLevel()
	{
		yield return new WaitForSeconds(Delay);
		
		AutoFade.LoadLevel(SceneName, 1f, 1f, Color.white);
	}
}
