using UnityEngine;
using System.Collections;

public class AnchorTransformToScreen : MonoBehaviour
{

    public AnchorPos Position;
    public Vector3 Offset = Vector3.zero;

    private Camera cam;

    public enum AnchorPos
    {
        TopLeft, TopCentre, TopRight,
        CentreLeft, Centre, CentreRight,
        BottomLeft, BottomCentre, BottomRight
    }

	void Start ()
    {
        cam = GameObject.FindWithTag("MenuCamera").GetComponent<Camera>();
	}
	
	void Update ()
    {
        AnchorToScreen();
	}

    void AnchorToScreen()
    {
        switch (Position)
        {
            case AnchorPos.TopLeft:
                transform.position = cam.ScreenToWorldPoint(new Vector3(0, Screen.height, 0) + Offset);
                break;
            case AnchorPos.TopCentre:
                transform.position = cam.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height, 0) + Offset);
                break;
            case AnchorPos.TopRight:
                transform.position = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0) + Offset);
                break;
            case AnchorPos.CentreLeft:
                transform.position = cam.ScreenToWorldPoint(new Vector3(0, Screen.height / 2, 0) + Offset);
                break;
            case AnchorPos.Centre:
                transform.position = cam.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 0) + Offset);
                break;
            case AnchorPos.CentreRight:
                transform.position = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height / 2, 0) + Offset);
                break;
            case AnchorPos.BottomLeft:
                transform.position = cam.ScreenToWorldPoint(new Vector3(0, 0, 0) + Offset);
                break;
            case AnchorPos.BottomCentre:
                transform.position = cam.ScreenToWorldPoint(new Vector3(Screen.width / 2, 0, 0) + Offset);
                break;
            case AnchorPos.BottomRight:
                transform.position = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0) + Offset);
                break;
        }
    }
}
