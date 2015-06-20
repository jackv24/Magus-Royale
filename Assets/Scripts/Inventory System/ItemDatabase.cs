using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System;

public class ItemDatabase : MonoBehaviour
{
	public List<Item> Items = new List<Item>();

	void Start()
	{
        //Items.Add(new Item("Health Potion", 0, "Drink for +10 health.", 0, 0, Item.ItemType.Consumable));
        //Items.Add(new Item("Mana Potion", 1, "Drink for +10 mana.", 0, 0, Item.ItemType.Consumable));
        //Items.Add(new Item("Heart", 2, "Consume for +10 max health.", 0, 0, Item.ItemType.Consumable));
        //Items.Add(new Item("Mana Crystal", 3, "Consume for +10 max mana.", 0, 0, Item.ItemType.Consumable));

        //Load
        TextAsset textXML = (TextAsset)Resources.Load("Items", typeof(TextAsset));
        XmlDocument xml = new XmlDocument();
        xml.LoadXml(textXML.text);

        //Read
        XmlNode root = xml.DocumentElement;

        int id;
        string name;
        string description;
        int power;
        int speed;
        Item.ItemType type;

        foreach (XmlNode node in root.ChildNodes)
        {
            id = int.Parse(node.SelectSingleNode("id").InnerText);
            name = node.SelectSingleNode("name").InnerText;
            description = node.SelectSingleNode("description").InnerText;
            power = int.Parse(node.SelectSingleNode("power").InnerText);
            speed = int.Parse(node.SelectSingleNode("speed").InnerText);
            type = (Item.ItemType)Enum.Parse(typeof(Item.ItemType), node.SelectSingleNode("type").InnerText, true);

            Items.Add(new Item(name, id, description, power, speed, type));
        }
	}
}
