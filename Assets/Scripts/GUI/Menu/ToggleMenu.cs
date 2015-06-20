using UnityEngine;
using System.Collections;

public class ToggleMenu : MonoBehaviour
{
	public bool OpenOnStart = false;

	public GameObject[] MenuItems;

	[HideInInspector]
	public bool IsActiveMenu = false;

	void Start ()
	{
		if(OpenOnStart)
		{
			StartCoroutine("AnimateOpenMenu");
		}
	}
	
	public void OpenMenu()
	{
		StartCoroutine("AnimateOpenMenu");
	}

	public void CloseMenu()
	{
		StartCoroutine("AnimateCloseMenu");

		foreach(GameObject item in MenuItems)
		{
			item.GetComponent<SelectMenuItem>().IsSelected = false;
		}
	}

	IEnumerator AnimateOpenMenu()
	{
		foreach(GameObject item in MenuItems)
		{
			item.GetComponent<Animator>().SetBool("isActiveMenu", true);
			IsActiveMenu = true;

			yield return new WaitForSeconds(0.1f);
		}
	}

	IEnumerator AnimateCloseMenu()
	{
		foreach(GameObject item in MenuItems)
		{
			item.GetComponent<Animator>().SetBool("isActiveMenu", false);
			IsActiveMenu = false;
			
			yield return new WaitForSeconds(0.1f);
		}
	}
}
