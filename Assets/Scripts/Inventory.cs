using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    [SerializeField] List<Item> items; 
    [SerializeField] Transform itemsParent;
	[SerializeField] ItemSlot[] itemSlots;

    public event Action<Item> OnItemLeftClikedEvent; //Equippable/Interact with item

    private void Start()
    {
       for(int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].OnLeftClickEvent += OnItemLeftClikedEvent;
        }
    }

    private void OnValidate()
	{
		RefreshUI();
	}

	private void RefreshUI() //Everytime change happens in inventory
	{
		int i = 0;
		for(; i < items.Count && i < itemSlots.Length; i++)
		{
			itemSlots[i].Item = items[i]; //Assign item for every item slot
		}

		for (; i < itemSlots.Length; i++) //Remaining slots with no items are set to null
		{
			itemSlots[i].Item = null;
		}
	}

	public bool AddItem(Item item)
	{
		if (IsFull())
			return false; //Can't add items if full

		items.Add(item); //Add items to list
		RefreshUI();
		return true;
	}

	public bool RemoveItem(Item item)
	{
		if (items.Remove(item))
		{
			RefreshUI(); //If item removed then true
			return true;
		}

		return false;
	}

	public bool IsFull()
	{
		return items.Count >= itemSlots.Length; //Items greater than item slots available
	}
}
