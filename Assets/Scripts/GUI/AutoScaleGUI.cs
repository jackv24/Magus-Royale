using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class AutoScaleGUI : MonoBehaviour
{
    //public int baseResX = 1280;
    public int BaseResY = 720;

    private float ratio = 1.0f;

    private Camera cam;
    private float startSize = 0;

    void Start()
    {
        cam = GetComponent<Camera>();
        startSize = cam.orthographicSize;
    }

    void Update()
    {
        ratio = Screen.height / (float)BaseResY;

        cam.orthographicSize = startSize * ratio;
    }
}
