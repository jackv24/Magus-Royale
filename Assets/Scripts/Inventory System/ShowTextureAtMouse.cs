using UnityEngine;
using System.Collections;

public class ShowTextureAtMouse : MonoBehaviour
{
    private Texture2D textureToShow;

    void OnGUI()
    {
        if(textureToShow != null)
            GUI.DrawTexture(new Rect(Event.current.mousePosition.x - (textureToShow.width / 2), Event.current.mousePosition.y - (textureToShow.height / 2), textureToShow.width, textureToShow.height), textureToShow);
    }

    public void SetTexture(Texture2D texture)
    {
        textureToShow = texture;
    }
}
