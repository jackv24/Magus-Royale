using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item
{
	public string ItemName;
	public int ItemID;
	public string ItemDescription;
	public Texture2D ItemIcon;
	public int ItemPower;
	public int ItemSpeed;
	public ItemType ItemsType;

	public enum ItemType
	{
		Weapon,
		Consumable,
		Garment
	}

	public Item(string name, int id, string desc, int power, int speed, ItemType type)
	{
		ItemName = name;
		ItemID = id;
		ItemDescription = desc;
		ItemIcon = Resources.Load<Texture2D>("ItemIcons/" + name);
		ItemPower = power;
		ItemSpeed = speed;
		ItemsType = type;
	}

	public Item()
	{
        ItemID = -1;
	}
}
