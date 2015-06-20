using UnityEngine;
using System.Collections;

public class LoadPlayerCustomisations : MonoBehaviour
{
    public SkinnedMeshRenderer HatRend;
    public SkinnedMeshRenderer HairRend;
    public SkinnedMeshRenderer ClothesRend;

    private PlayerControl playerControl;

	void Start ()
    {
        playerControl = transform.parent.GetComponent<PlayerControl>();

        if (HatRend == null || HairRend == null || ClothesRend == null)
            Debug.Log("Missing a MeshRenderer!");
        else
        {
            if (playerControl.LocallyControlled)
            {
                HatRend.material.color = new Color(PlayerPrefs.GetFloat("Hat1R"), PlayerPrefs.GetFloat("Hat1G"), PlayerPrefs.GetFloat("Hat1B"));
                HairRend.material.color = new Color(PlayerPrefs.GetFloat("Hair1R"), PlayerPrefs.GetFloat("Hair1G"), PlayerPrefs.GetFloat("Hair1B"));
                ClothesRend.material.color = new Color(PlayerPrefs.GetFloat("Clothes1R"), PlayerPrefs.GetFloat("Clothes1G"), PlayerPrefs.GetFloat("Clothes1B"));
            }
            else
            {
                HatRend.material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                HairRend.material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                ClothesRend.material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            }
        }
	}
}
