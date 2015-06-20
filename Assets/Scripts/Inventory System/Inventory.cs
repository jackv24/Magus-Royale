using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Inventory : MonoBehaviour
{
	public int SlotsX = 9, SlotsY = 5;
    public int BindingSlots = 4;
	public GUISkin Skin;
	public List<Item> InventoryList = new List<Item>();
	public List<Item> SlotsList = new List<Item>();

    public GameObject ItemDropped;

	private bool showInventory;

    private GameObject gamemanager;
	private ItemDatabase database;
    private PlayerControl playerControl;

	private bool showToolTip;
	private string tooltip;

	private bool draggingItem;
	private Item draggedItem;
	private int previousIndex;

    private bool setMouseTexture = false;

	void Start()
	{
		for(int i = 0; i < (SlotsX * SlotsY); i++)
		{
			SlotsList.Add(new Item());
			InventoryList.Add (new Item());
		}

        gamemanager = GameObject.FindGameObjectWithTag("Game Manager");
		database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();
        playerControl = GetComponent<PlayerControl>();
	}

	void Update()
	{
        if (playerControl.LocallyControlled)
        {
            //Input for opening and closing the inventory
            if (Input.GetButtonDown("Inventory"))
            {
                showInventory = !showInventory;
                Screen.lockCursor = !showInventory;
                Properties.IsGamePaused = !Properties.IsGamePaused;
            }
            if (Input.GetButtonDown("Pause") && showInventory)
            {
                showInventory = !showInventory;
                Screen.lockCursor = !showInventory;
            }

            //For testing purposes
            if (Input.GetKeyDown(KeyCode.R))
            {
                AddItem(Random.Range(0, database.Items.Count + 1));
            }

            int i = -1;

            if (Input.GetButtonDown("Item 1"))
                i = 0;
            if (Input.GetButtonDown("Item 2"))
                i = 1;
            if (Input.GetButtonDown("Item 3"))
                i = 2;
            if (Input.GetButtonDown("Item 4"))
                i = 3;

            if (i >= 0)
                if (SlotsList[i].ItemsType == Item.ItemType.Consumable)
                {
                    UseConsumable(SlotsList[i].ItemID, i, true);
                }
        }
	}

	void OnGUI()
	{
        if (playerControl.LocallyControlled)
        {
            tooltip = "";

            //Handles the main inventory.
            DrawInventory();

            if (showToolTip)
                GUI.Box(new Rect(Event.current.mousePosition.x + 8, Event.current.mousePosition.y + 8, 200, Skin.GetStyle("Tooltip").CalcHeight(new GUIContent(tooltip), 200.0f)), tooltip, Skin.GetStyle("Tooltip"));

            if (draggingItem)
            {
                gamemanager.GetComponent<ShowTextureAtMouse>().SetTexture(draggedItem.ItemIcon);
                setMouseTexture = true;
            }
            else if (setMouseTexture)
            {
                gamemanager.GetComponent<ShowTextureAtMouse>().SetTexture(null);
                setMouseTexture = false;
            }
        }
	}

	void DrawInventory()
	{
		Event e = Event.current;
		int i = 0;

        bool isOverSlot = false;

        //Position inventory rect in bottom left if inventory is hidden (for hotbar), center if shown
        Rect groupRect;
        if (!showInventory)
            groupRect = new Rect(10, Screen.height - 85, SlotsX * 75, SlotsY * 75);
        else
            groupRect = new Rect((Screen.width / 2) - (SlotsX * 75 / 2), (Screen.height / 2) - (SlotsY * 75 / 2), SlotsX * 75, SlotsY * 75);

        GUI.BeginGroup(groupRect);

		for(int y = 0; y < SlotsY; y++)
		{
			for(int x = 0; x < SlotsX; x++)
			{
                Rect slotRect = new Rect(x * 75, y * 75, 64, 64);

                //Set first four inventory slots to be styled differently - for binding.
                if (i < BindingSlots) //Always draw the binding slots
                    GUI.Box(slotRect, "" + (i + 1), Skin.GetStyle("ItemSlot"));
                if (i >= BindingSlots && showInventory) //Only draw the rest of the slots if showInventory
                    GUI.Box(slotRect, "", Skin.GetStyle("ItemSlot"));
				SlotsList[i] = InventoryList[i];

				Item item = SlotsList[i];

                //Only run if there is an item in the current slot
				if(item.ItemName != null)
				{
                    if (i < BindingSlots)
                        GUI.DrawTexture(slotRect, item.ItemIcon);
                    if (i >= BindingSlots && showInventory)
					    GUI.DrawTexture(slotRect, item.ItemIcon);

                    if (slotRect.Contains(e.mousePosition) && showInventory)
					{
                        isOverSlot = true;

						tooltip = CreateTooltip(item);
						showToolTip = true;

                        //If left click and drag, store the slot's item and remove it
                        if (e.button == 0 && e.type == EventType.mouseDrag && !draggingItem)
						{
							draggingItem = true;
							previousIndex = i;
							draggedItem = item;
							InventoryList[i] = new Item();
						}
                        //If left click, store the slot's item and remove it
                        if (e.isMouse && e.type == EventType.mouseDown && e.button == 0 && !draggingItem)
                        {
                            draggingItem = true;
                            previousIndex = i;
                            draggedItem = item;
                            InventoryList[i] = new Item();
                        }
                        //If left click released over item, switch the items in slots
						if(e.type == EventType.mouseUp && draggingItem)
						{
							InventoryList[previousIndex] = InventoryList[i];
							InventoryList[i] = draggedItem;
							draggingItem = false;
							draggedItem = null;
						}

                        //Use consumable when item is right clicked
						if(e.isMouse && e.type == EventType.mouseDown && e.button == 1)
						{
							if(item.ItemsType == Item.ItemType.Consumable)
							{
								UseConsumable(item.ItemID, i, true);
							}
						}
					}
				}
				else //If slot is empty
				{
                    //If mouse is released over slot, and an item is being dragged, place the dragged item in that slot
					if(slotRect.Contains(e.mousePosition))
					{
						if(e.type == EventType.mouseUp && draggingItem)
						{
							InventoryList[i] = draggedItem;
							draggingItem = false;
							draggedItem = null;
						}
					}
				}

				if(tooltip == "")
					showToolTip = false;

				i++;
			}
		}

        GUI.EndGroup();

        //If item is dropped outside inventory slot, throw it out.
        if (!isOverSlot)
        {
            if (e.type == EventType.mouseUp && draggingItem)
            {
                GameObject droppedItem = Instantiate(ItemDropped, transform.position + new Vector3(Random.insideUnitCircle.normalized.x * 2, 1, Random.insideUnitCircle.normalized.y) * 2, Quaternion.identity) as GameObject;
                droppedItem.GetComponent<DroppedItem>().UpdateItem(draggedItem);

                InventoryList[previousIndex] = new Item();//draggedItem;
                draggingItem = false;
                draggedItem = null;
            }
        }
	}

	public string CreateTooltip(Item item)
	{
        tooltip = "<color=#000000>" + item.ItemName + "</color>"
            + "\n\n<color=#535353>" + item.ItemDescription + "</color>"
            + "\n\n<color=#683c11>" + item.ItemsType + "</color>";

		return tooltip;
	}

	public void RemoveItem(int id)
	{
		if(InventoryContains(id))
			InventoryList[id] = new Item();
	}

	public void AddItem(int id)
	{
		for(int i = 0; i < InventoryList.Count; i++)
		{
			if(InventoryList[i].ItemName == null)
			{
				for(int j = 0; j < database.Items.Count; j++)
				{
					if(database.Items[j].ItemID == id)
					{
						InventoryList[i] = database.Items[j];
					}
				}
				break;
			}
		}
	}

	bool InventoryContains(int id)
	{
		for(int i = 0; i < InventoryList.Count; i++)
			if(InventoryList[i].ItemID == id)
				return true;

		return false;
	}

    //Code consumable behaviours here
	void UseConsumable(int id, int slot, bool deleteItem)
	{
		PlayerStats stats = GetComponent<PlayerStats>();

		switch(id)
		{
		    case 0: //Health Potion
			    if(stats.CurrentHealth >= stats.MaxHealth)
				    deleteItem = false;
			    stats.AddHealth(10.0f);
			    break;
		    case 1: //Mana Potion
			    if(stats.CurrentMana >= stats.MaxMana)
				    deleteItem = false;
			    stats.AddMana(10.0f);
			    break;
            case 2: //Heart
                stats.MaxHealth += 10;
                stats.CurrentHealth += 10;
                break;
            case 3: //Mana Crystal
                stats.MaxMana += 10;
                stats.CurrentMana += 10;
                break;
		}

		if(deleteItem)
			InventoryList[slot] = new Item();
	}

	void SaveInventory()
	{
		for(int i = 0; i < InventoryList.Count; i++)
			PlayerPrefs.SetInt("Inventory " + i, InventoryList[i].ItemID);
	}

	void LoadInventory()
	{
        for (int i = 0; i < InventoryList.Count; i++)
            InventoryList[i] = PlayerPrefs.GetInt("Inventory " + i, -1) >= 0 ? database.Items[PlayerPrefs.GetInt("Inventory " + i)] : new Item();
	}
}