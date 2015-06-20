using UnityEngine;
using System.Collections;

/*Scales the menu item the user has selected, and changes the background colour accordingly.*/

public class SelectMenuItem : MonoBehaviour
{
	public bool ChangeBackgroundColour = false;
	public Color BackgroundColour;

	[HideInInspector]
	public bool IsSelected = false;

	void Start ()
	{

	}

	void Update()
	{
		if(IsSelected && ChangeBackgroundColour)
			Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor, BackgroundColour, 0.25f);
	}

	void OnMouseEnter ()
	{
		Select();
	}

	void OnMouseExit()
	{
		Deselect();
	}

	public void Select()
	{
		IsSelected = true;
		
		GetComponent<Animator>().SetBool("isSelected", true);
	}

	public void Deselect()
	{
		IsSelected = false;

		GetComponent<Animator>().SetBool("isSelected", false);
	}
}
