using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour
{
    public float Time = 10.0f;

    void Start()
    {
        Destroy(gameObject, Time);
    }
}
