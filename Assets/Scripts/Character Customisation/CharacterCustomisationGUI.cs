using UnityEngine;
using System.Collections;

public class CharacterCustomisationGUI : MonoBehaviour
{
    public GUISkin Skin;
    public Color HatOptionsColour = Color.black;
    public Color HairOptionsColour = Color.black;
    public Color ClothesOptionsColour = Color.black;
    public float LerpSpeed = 0.1f;

    private Rect controlsBox;

    public Color Hat1 = Color.grey;
    public Color Hat2 = Color.grey;
    public Color Hair1 = Color.grey;
    public Color Hair2 = Color.grey;
    public Color Clothes1 = Color.grey;
    public Color Clothes2 = Color.grey;

    public SkinnedMeshRenderer HatRend;
    public SkinnedMeshRenderer ClothesRend;
    public SkinnedMeshRenderer HairRend;

    void Start()
    {
        Hat1 = new Color(PlayerPrefs.GetFloat("Hat1R"), PlayerPrefs.GetFloat("Hat1G"), PlayerPrefs.GetFloat("Hat1B"));
        Hair1 = new Color(PlayerPrefs.GetFloat("Hair1R"), PlayerPrefs.GetFloat("Hair1G"), PlayerPrefs.GetFloat("Hair1B"));
        Clothes1 = new Color(PlayerPrefs.GetFloat("Clothes1R"), PlayerPrefs.GetFloat("Clothes1G"), PlayerPrefs.GetFloat("Clothes1B"));
    }

    void Update()
    {
        HatRend.material.color = Color.Lerp(HatRend.material.color, new Color(Hat1.r, Hat1.g, Hat1.b), LerpSpeed);
        ClothesRend.material.color = Color.Lerp(ClothesRend.material.color, new Color(Clothes1.r, Clothes1.g, Clothes1.b), LerpSpeed);
        HairRend.material.color = Color.Lerp(HairRend.material.color, new Color(Hair1.r, Hair1.g, Hair1.b), LerpSpeed);
    }

    void OnGUI()
    {
        GUI.skin = Skin;

        GUI.Label(new Rect(0, 0, 612, 64), "Character Customisation", Skin.GetStyle("PageHeading"));
        
        //If screen width is greater than 1280px then center at 90% of screen width to right edge, else anchor at right edge.
        if(Screen.width > 1280)
            controlsBox = new Rect(Screen.width * 0.9f - 425, Screen.height / 2 - 257, 400, 515);
        else
            controlsBox = new Rect(Screen.width - 425, Screen.height / 2 - 257, 400, 515);
        //GUI.Box(controlsBox, "");

        GUI.BeginGroup(controlsBox);
            GUI.BeginGroup(new Rect(0, 0, controlsBox.width, 155));
                DrawHatOptions();
            GUI.EndGroup();
            GUI.BeginGroup(new Rect(0, 180, controlsBox.width, 155));
                DrawHairOptions();
            GUI.EndGroup();
            GUI.BeginGroup(new Rect(0, 360, controlsBox.width, 155));
                DrawClothesOptions();
            GUI.EndGroup();
        GUI.EndGroup();
    }

    void DrawHatOptions()
    {
        //GUI element rects
        Rect ColourLabel = new Rect(0, 0, controlsBox.width, 42);
        Rect Colour1Box = new Rect(25, 50, 170, 105);
        Rect Colour2Box = new Rect(Colour1Box.width + 35, 50, 170, 105);

        //Save current background colour and set new colour.
        Color col = GUI.backgroundColor;
        GUI.backgroundColor = HatOptionsColour;

        //Draw containing boxes.
        GUI.Box(ColourLabel, "Hat", Skin.GetStyle("CycleLabel"));
        GUI.Box(Colour1Box, "Colour 1");
        GUI.Box(Colour2Box, "Colour 2");

        //Restore old background colour.
        GUI.backgroundColor = col;

        //Draw first hat colour options box.
        GUI.BeginGroup(Colour1Box);
            GUI.Label(new Rect(5, 20, 30, 35), "R");
            Hat1.r = GUI.HorizontalSlider(new Rect(30, 32, Colour1Box.width - 40, 16), Hat1.r, 0, 1);
            GUI.Label(new Rect(5, 40, 30, 35), "G");
            Hat1.g = GUI.HorizontalSlider(new Rect(30, 52, Colour1Box.width - 40, 16), Hat1.g, 0, 1);
            GUI.Label(new Rect(5, 60, 30, 35), "B");
            Hat1.b = GUI.HorizontalSlider(new Rect(30, 72, Colour1Box.width - 40, 16), Hat1.b, 0, 1);
        GUI.EndGroup();

        //Draw second hat colour options box.
        GUI.BeginGroup(Colour2Box);
            GUI.Label(new Rect(5, 20, 30, 35), "R");
            Hat2.r = GUI.HorizontalSlider(new Rect(30, 32, Colour1Box.width - 40, 16), Hat2.r, 0, 1);
            GUI.Label(new Rect(5, 40, 30, 35), "G");
            Hat2.g = GUI.HorizontalSlider(new Rect(30, 52, Colour1Box.width - 40, 16), Hat2.g, 0, 1);
            GUI.Label(new Rect(5, 60, 30, 35), "B");
            Hat2.b = GUI.HorizontalSlider(new Rect(30, 72, Colour1Box.width - 40, 16), Hat2.b, 0, 1);
        GUI.EndGroup();
    }

    void DrawHairOptions()
    {
        //GUI element rects
        Rect ColourLabel = new Rect(0, 0, controlsBox.width, 42);
        Rect Colour1Box = new Rect(25, 50, 170, 105);
        Rect Colour2Box = new Rect(Colour1Box.width + 35, 50, 170, 105);

        //Save current background colour and set new colour.
        Color col = GUI.backgroundColor;
        GUI.backgroundColor = HairOptionsColour;

        //Draw containing boxes.
        GUI.Box(ColourLabel, "Body", Skin.GetStyle("CycleLabel"));
        GUI.Box(Colour1Box, "Hair");
        GUI.Box(Colour2Box, "Eyes");

        //Restore old background colour.
        GUI.backgroundColor = col;

        //Draw first hat colour options box.
        GUI.BeginGroup(Colour1Box);
        GUI.Label(new Rect(5, 20, 30, 35), "R");
        Hair1.r = GUI.HorizontalSlider(new Rect(30, 32, Colour1Box.width - 40, 16), Hair1.r, 0, 1);
        GUI.Label(new Rect(5, 40, 30, 35), "G");
        Hair1.g = GUI.HorizontalSlider(new Rect(30, 52, Colour1Box.width - 40, 16), Hair1.g, 0, 1);
        GUI.Label(new Rect(5, 60, 30, 35), "B");
        Hair1.b = GUI.HorizontalSlider(new Rect(30, 72, Colour1Box.width - 40, 16), Hair1.b, 0, 1);
        GUI.EndGroup();

        //Draw second hat colour options box.
        GUI.BeginGroup(Colour2Box);
        GUI.Label(new Rect(5, 20, 30, 35), "R");
        Hair2.r = GUI.HorizontalSlider(new Rect(30, 32, Colour1Box.width - 40, 16), Hair2.r, 0, 1);
        GUI.Label(new Rect(5, 40, 30, 35), "G");
        Hair2.g = GUI.HorizontalSlider(new Rect(30, 52, Colour1Box.width - 40, 16), Hair2.g, 0, 1);
        GUI.Label(new Rect(5, 60, 30, 35), "B");
        Hair2.b = GUI.HorizontalSlider(new Rect(30, 72, Colour1Box.width - 40, 16), Hair2.b, 0, 1);
        GUI.EndGroup();
    }

    void DrawClothesOptions()
    {
        //GUI element rects
        Rect ColourLabel = new Rect(0, 0, controlsBox.width, 42);
        Rect Colour1Box = new Rect(25, 50, 170, 105);
        Rect Colour2Box = new Rect(Colour1Box.width + 35, 50, 170, 105);

        //Save current background colour and set new colour.
        Color col = GUI.backgroundColor;
        GUI.backgroundColor = ClothesOptionsColour;

        //Draw containing boxes.
        GUI.Box(ColourLabel, "Clothes", Skin.GetStyle("CycleLabel"));
        GUI.Box(Colour1Box, "Colour 1");
        GUI.Box(Colour2Box, "Colour 2");

        //Restore old background colour.
        GUI.backgroundColor = col;

        //Draw first hat colour options box.
        GUI.BeginGroup(Colour1Box);
        GUI.Label(new Rect(5, 20, 30, 35), "R");
        Clothes1.r = GUI.HorizontalSlider(new Rect(30, 32, Colour1Box.width - 40, 16), Clothes1.r, 0, 1);
        GUI.Label(new Rect(5, 40, 30, 35), "G");
        Clothes1.g = GUI.HorizontalSlider(new Rect(30, 52, Colour1Box.width - 40, 16), Clothes1.g, 0, 1);
        GUI.Label(new Rect(5, 60, 30, 35), "B");
        Clothes1.b = GUI.HorizontalSlider(new Rect(30, 72, Colour1Box.width - 40, 16), Clothes1.b, 0, 1);
        GUI.EndGroup();

        //Draw second hat colour options box.
        GUI.BeginGroup(Colour2Box);
        GUI.Label(new Rect(5, 20, 30, 35), "R");
        Clothes2.r = GUI.HorizontalSlider(new Rect(30, 32, Colour1Box.width - 40, 16), Clothes2.r, 0, 1);
        GUI.Label(new Rect(5, 40, 30, 35), "G");
        Clothes2.g = GUI.HorizontalSlider(new Rect(30, 52, Colour1Box.width - 40, 16), Clothes2.g, 0, 1);
        GUI.Label(new Rect(5, 60, 30, 35), "B");
        Clothes2.b = GUI.HorizontalSlider(new Rect(30, 72, Colour1Box.width - 40, 16), Clothes2.b, 0, 1);
        GUI.EndGroup();
    }
}
