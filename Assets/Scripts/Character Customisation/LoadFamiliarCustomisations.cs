using UnityEngine;
using System.Collections;

public class LoadFamiliarCustomisations : MonoBehaviour
{
    public MeshRenderer ArmourRend;
    public MeshRenderer BodyRend;

    public LoadPlayerCustomisations PlayerGraphic;

    void Start()
    {
        if (ArmourRend == null || BodyRend == null)
            Debug.Log("Missing a MeshRenderer!");

        ArmourRend.material.color = new Color(PlayerGraphic.ClothesRend.material.color.r, PlayerGraphic.ClothesRend.material.color.g, PlayerGraphic.ClothesRend.material.color.b);
        BodyRend.material.color = new Color(PlayerGraphic.HairRend.material.color.r, PlayerGraphic.HairRend.material.color.g, PlayerGraphic.HairRend.material.color.b);
    }
}
