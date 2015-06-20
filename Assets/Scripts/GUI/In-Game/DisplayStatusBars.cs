using UnityEngine;
using System.Collections;

/* Displays and manages the stats HUD. Calculates current stat percentages
 * from PlayerStats and scales status bars smoothly. */

public class DisplayStatusBars : MonoBehaviour
{
    public GUISkin skin;

	private GameObject player;
    private PlayerStats playerStats;

    public Texture2D Circle;

	public Texture2D FullHealthTex;
	public Texture2D EmptyHealthTex;

    public Texture2D FullManaTex;
    public Texture2D EmptyManaTex;

    private float healthPercent = 1.0f;
    private float manaPercent = 1.0f;

	void Start ()
	{
        player = GameObject.Find("Player");
        playerStats = player.GetComponent<PlayerStats>();
	}

	void Update ()
	{
        MonitorAndChangeStatPercentages();
	}

	void OnGUI()
	{
		//Draw empty, then health bar
        GUI.DrawTexture(new Rect(10 + Circle.width / 2, 10, EmptyHealthTex.width, EmptyHealthTex.height), EmptyHealthTex, ScaleMode.StretchToFill);
        GUI.DrawTexture(new Rect(10 + Circle.width / 2, 10, (FullHealthTex.width) * healthPercent, FullHealthTex.height), FullHealthTex, ScaleMode.StretchToFill);

		//Draw empty mana bar, then mana bar
		GUI.DrawTexture(new Rect(10 + (Circle.width / 2), 10 + EmptyHealthTex.height, EmptyManaTex.width, EmptyManaTex.height), EmptyManaTex, ScaleMode.StretchToFill);
		GUI.DrawTexture(new Rect(10 + (Circle.width / 2), 10 + FullHealthTex.height, (FullManaTex.width) * manaPercent, FullManaTex.height), FullManaTex, ScaleMode.StretchToFill);

		//Draw circle graphic
		GUI.DrawTexture(new Rect(10, 10, Circle.width, Circle.height), Circle, ScaleMode.StretchToFill);

        //Draw stat text
        GUI.Label(new Rect(10 + Circle.width / 2, 10, EmptyHealthTex.width, EmptyHealthTex.height), playerStats.CurrentHealth + "/" + playerStats.MaxHealth, skin.GetStyle("StatBar"));
        GUI.Label(new Rect(10 + (Circle.width / 2), 10 + EmptyHealthTex.height, EmptyManaTex.width, EmptyManaTex.height), playerStats.CurrentMana + "/" + playerStats.MaxMana, skin.GetStyle("StatBar"));
	}

    void MonitorAndChangeStatPercentages()
    {
        if (playerStats.CurrentHealth / playerStats.MaxHealth != healthPercent)
            healthPercent = Mathf.Lerp(healthPercent, playerStats.CurrentHealth / playerStats.MaxHealth, 0.1f);

        if (playerStats.CurrentMana / playerStats.MaxMana != manaPercent)
            manaPercent = Mathf.Lerp(manaPercent, playerStats.CurrentMana / playerStats.MaxMana, 0.1f);
    }
}
