using UnityEngine;
using System.Collections;

public class LoadSceneAfterTime : MonoBehaviour
{
    public float TimeToLoad = 0f;
    public string SceneName = "";

    void Update()
    {
        if (TimeToLoad < 0)
            Application.LoadLevel(SceneName);

        TimeToLoad -= Time.deltaTime;

    }
}
