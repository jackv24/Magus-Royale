using UnityEngine;
using System.Collections;

public class Properties : MonoBehaviour
{
	public static bool IsGamePaused = false;

	void Awake()
	{
		IsGamePaused = false;
	}
}
