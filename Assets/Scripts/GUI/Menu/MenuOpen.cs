using UnityEngine;
using System.Collections;

public class MenuOpen : MonoBehaviour
{
	public GameObject Menu;
	public float Delay = 0.0f;

	public bool IsPauseToggle;

	void OnMouseUp ()
	{
		if(Menu != null)
			OpenMenu();
		else
			Debug.Log ("No menu to open!");
	}
	
	public void OpenMenu()
	{
		
		StartCoroutine("OpenCloseMenus");
	}
	
	IEnumerator OpenCloseMenus()
	{
		transform.parent.GetComponent<ToggleMenu>().CloseMenu();

		yield return new WaitForSeconds(Delay);
		
		Menu.GetComponent<ToggleMenu>().OpenMenu();
	}
}
