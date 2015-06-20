using UnityEngine;
using System.Collections;

public class SaveLoadPreset : MonoBehaviour
{
    public bool IsLoad = false;

    private CharacterCustomisationGUI c;

	void Start()
    {
        c = GameObject.FindWithTag("Game Manager").GetComponent<CharacterCustomisationGUI>();
	}
	
	void OnMouseUp()
    {
        SaveLoad();
	}

    public void SaveLoad()
    {
        if (IsLoad)
        {
            c.Hat1.r = PlayerPrefs.GetFloat("Hat1R");
            c.Hat1.g = PlayerPrefs.GetFloat("Hat1G");
            c.Hat1.b = PlayerPrefs.GetFloat("Hat1B");

            c.Hair1.r = PlayerPrefs.GetFloat("Hair1R");
            c.Hair1.g = PlayerPrefs.GetFloat("Hair1G");
            c.Hair1.b = PlayerPrefs.GetFloat("Hair1B");

            c.Clothes1.r = PlayerPrefs.GetFloat("Clothes1R");
            c.Clothes1.g = PlayerPrefs.GetFloat("Clothes1G");
            c.Clothes1.b = PlayerPrefs.GetFloat("Clothes1B");
        }
        else
        {
            PlayerPrefs.SetFloat("Hat1R", c.Hat1.r);
            PlayerPrefs.SetFloat("Hat1G", c.Hat1.g);
            PlayerPrefs.SetFloat("Hat1B", c.Hat1.b);

            PlayerPrefs.SetFloat("Hair1R", c.Hair1.r);
            PlayerPrefs.SetFloat("Hair1G", c.Hair1.g);
            PlayerPrefs.SetFloat("Hair1B", c.Hair1.b);

            PlayerPrefs.SetFloat("Clothes1R", c.Clothes1.r);
            PlayerPrefs.SetFloat("Clothes1G", c.Clothes1.g);
            PlayerPrefs.SetFloat("Clothes1B", c.Clothes1.b);
        }
    }
}
