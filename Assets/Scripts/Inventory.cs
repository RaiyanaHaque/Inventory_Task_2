﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    [SerializeField] List<Item> items;
    [SerializeField] Transform itemsParent;
	[SerializeField] ItemSlot[] itemSlots;

    public event Action<Item> OnItemLeftClikedEvent;

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

	private void RefreshUI()
	{
		int i = 0;
		for(; i < items.Count && i < itemSlots.Length; i++)
		{
			itemSlots[i].Item = items[i];
		}

		for (; i < itemSlots.Length; i++) //Remaining slots with no items are set to null
		{
			itemSlots[i].Item = null;
		}
	}

	public bool AddItem(Item item)
	{
		if (IsFull())
			return false;

		items.Add(item);
		RefreshUI();
		return true;
	}

	public bool RemoveItem(Item item)
	{
		if (items.Remove(item))
		{
			RefreshUI();
			return true;
		}

		return false;
	}

	public bool IsFull()
	{
		return items.Count >= itemSlots.Length;
	}
}