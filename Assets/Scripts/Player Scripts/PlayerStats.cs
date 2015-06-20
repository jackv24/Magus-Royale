using UnityEngine;
using System.Collections;

/* Contains all current player stats as variables, such as MaxHealth, CurrentHealth,
 * MaxMana and CurrentMana. Also contains public methods for removing and adding
 * health and mana. */

public class PlayerStats : MonoBehaviour
{
    public float MaxHealth = 100;
    public float CurrentHealth;
    public float MaxMana = 50;
    public float CurrentMana;

    public GUISkin Skin;

    private PlayerBehaviour playerBehaviour;

	void Start ()
    {
        CurrentHealth = MaxHealth;
        CurrentMana = MaxMana;

        playerBehaviour = GetComponent<PlayerBehaviour>();
	}

    void Update()
    {
        if (CurrentHealth <= 0)
            playerBehaviour.Die();
    }

    public void AddHealth(float amount)
    {
        if(CurrentHealth < MaxHealth)
            CurrentHealth += amount;

		if(CurrentHealth > MaxHealth)
			CurrentHealth = MaxHealth;
    }

    public void RemoveHealth(float amount)
    {
        CurrentHealth -= amount;

        if (CurrentHealth < 0)
            CurrentHealth = 0;
    }

    public void AddMana(float amount)
    {
        if (CurrentMana < MaxMana)
            CurrentMana += amount;

		if(CurrentMana > MaxMana)
			CurrentMana = MaxMana;
    }

    public void RemoveMana(float amount)
    {
        CurrentMana -= amount;

        if (CurrentMana < 0)
            CurrentMana = 0;
    }
}
