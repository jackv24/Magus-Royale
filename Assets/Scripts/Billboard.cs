using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour
{
    public bool Horizontal = false;
    public bool Vertical = true;

	void Update ()
	{
        if (Vertical && Horizontal)
            transform.rotation = Quaternion.Euler(Camera.main.transform.rotation.eulerAngles.x, Camera.main.transform.rotation.eulerAngles.y, Camera.main.transform.rotation.eulerAngles.z);
        if(Vertical && !Horizontal)
		    transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, Camera.main.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        if (!Vertical && Horizontal)
            transform.rotation = Quaternion.Euler(Camera.main.transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Camera.main.transform.rotation.eulerAngles.z);
	}
}
