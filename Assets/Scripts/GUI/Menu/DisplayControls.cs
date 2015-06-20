using UnityEngine;
using System.Collections;

public class DisplayControls : MonoBehaviour
{
    public GUISkin Skin;
    public Texture2D Image;
    public Color BoxColour;

    private bool isOpen = false;

    private float MenuX = 0f;
    private float MenuXTarget = 0f;

    void Start()
    {
        MenuX = Screen.width;
        MenuXTarget = Screen.width;
    }

    void OnMouseUp()
    {
        Open();
    }

    public void Open()
    {
        if (!isOpen)
        {
            MenuXTarget = Screen.width / 2 - 480;
            transform.parent.GetComponent<ToggleMenu>().CloseMenu();
        }
    }

	void OnGUI ()
    {
            GUI.skin = Skin;

            MenuX = Mathf.Lerp(MenuX, MenuXTarget, 0.05f);
            Rect box = new Rect(MenuX, Screen.height / 2 - (Image.height / 2 + 50), 960, Image.height + 50);

            GUI.backgroundColor = BoxColour;

            GUI.BeginGroup(box);

            GUI.Box(new Rect(0, 0, box.width, 42), "Controls", Skin.GetStyle("CycleLabel"));
            GUI.Box(new Rect(box.width / 2 - Image.width / 2, 50, Image.width, Image.height), Image);

            GUI.EndGroup();

            if (Input.GetButtonDown("Pause") || Input.GetButtonDown("Attack 1"))
                MenuXTarget = Screen.width;
	}
}
