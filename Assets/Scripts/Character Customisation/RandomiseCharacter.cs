using UnityEngine;
using System.Collections;

public class RandomiseCharacter : MonoBehaviour
{
    private CharacterCustomisationGUI c;

	void Start ()
    {
        c = GameObject.FindWithTag("Game Manager").GetComponent<CharacterCustomisationGUI>();
	}

    void OnMouseUp()
    {
        Randomise();
    }

    void Update()
    {
        
    }

    void CheckColourLerping()
    {
        
    }

    public void Randomise()
    {
        c.Hat1 = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        c.Hair1 = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        c.Clothes1 = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }
}
