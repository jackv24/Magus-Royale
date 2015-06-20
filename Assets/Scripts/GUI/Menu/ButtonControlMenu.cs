using UnityEngine;
using System.Collections;

/*Allows menu navigation using a keyboard or controller.*/

public class ButtonControlMenu : MonoBehaviour
{
	private GameObject[] MenuItems;

	private int targetSelected = 0;
	private int currentSelected = -1;
	private int lastSelected = 0;

	private bool isAxisInUse;
	private bool isDPadInUse;

	void Start ()
	{
		MenuItems = GetComponent<ToggleMenu>().MenuItems;
		targetSelected = MenuItems.Length - 1;
	}

	void Update ()
	{
		//Only work if this is the active menu
		if(GetComponent<ToggleMenu>().IsActiveMenu)
		{
			//Updates lastSelected to targetSelected. Must come before targetSelected is changed.
			lastSelected = targetSelected;

			GetAxisInputs();

			//Deselects previously selected menu item, and selects the target.
			if(currentSelected != targetSelected)
			{
				currentSelected = targetSelected;

				MenuItems[currentSelected].GetComponent<SelectMenuItem>().Select();
				MenuItems[lastSelected].GetComponent<SelectMenuItem>().Deselect();

			}

			//Loads scene for currently selected menu item
			if(Input.GetKeyUp(KeyCode.Return) || Input.GetButtonUp("Jump"))
			{
                if (MenuItems[currentSelected].GetComponent<MenuOpen>() != null)
                    MenuItems[currentSelected].GetComponent<MenuOpen>().OpenMenu();
                if (MenuItems[currentSelected].GetComponent<MenuLoadScene>() != null)
                    MenuItems[currentSelected].GetComponent<MenuLoadScene>().LoadScene();
                if (MenuItems[currentSelected].GetComponent<ResumeGameButton>() != null)
                    MenuItems[currentSelected].GetComponent<ResumeGameButton>().TogglePauseGame();
                if (MenuItems[currentSelected].GetComponent<SaveLoadPreset>() != null)
                    MenuItems[currentSelected].GetComponent<SaveLoadPreset>().SaveLoad();
                if (MenuItems[currentSelected].GetComponent<RandomiseCharacter>() != null)
                    MenuItems[currentSelected].GetComponent<RandomiseCharacter>().Randomise();
                if (MenuItems[currentSelected].GetComponent<DisplayControls>() != null)
                    MenuItems[currentSelected].GetComponent<DisplayControls>().Open();

                MenuItems[currentSelected].GetComponent<SelectMenuItem>().Deselect();
                currentSelected = -1;
			}
		}
	}

	void GetAxisInputs()
	{
		//Vertical axis acts as GetButtonDown
		if( Input.GetAxisRaw("Vertical") > 0)
		{
			if(!isAxisInUse)
			{
				SelectPrevious();
				
				isAxisInUse = true;
			}
		}
		else if( Input.GetAxisRaw("Vertical") < 0)
		{
			if(!isAxisInUse)
			{
				SelectNext();
				
				isAxisInUse = true;
			}
		}
		else if( Input.GetAxisRaw("Vertical") == 0)
		{
			isAxisInUse = false;
		}

		//D-Pad vertical axis acts as GetButtonDown
		if( Input.GetAxisRaw("D-Pad Vertical") > 0)
		{
			if(!isDPadInUse)
			{
				SelectPrevious();
				
				isDPadInUse = true;
			}
		}
		else if( Input.GetAxisRaw("D-Pad Vertical") < 0)
		{
			if(!isDPadInUse)
			{
				SelectNext();
				
				isDPadInUse = true;
			}
		}
		else if( Input.GetAxisRaw("D-Pad Vertical") == 0)
		{
			isDPadInUse = false;
		}
	}

	void SelectPrevious()
	{
		if(targetSelected > 0)
			targetSelected--;
		else
			targetSelected = MenuItems.Length - 1;
	}
	
	void SelectNext()
	{
		if(targetSelected < MenuItems.Length - 1)
			targetSelected++;
		else
			targetSelected = 0;
	}
}
