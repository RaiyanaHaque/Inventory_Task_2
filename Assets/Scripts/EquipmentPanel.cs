using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EquipmentPanel : MonoBehaviour
{
    [SerializeField] Transform equipmentSlotsParent;
    [SerializeField] EquipmentSlot[] equipmentSlots;

    public event Action<Item> OnItemLeftClikedEvent; //Equip it on click

    private void Start()
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            equipmentSlots[i].OnLeftClickEvent += OnItemLeftClikedEvent;
        }
    }

    /* private void OnValidate()
     {
         equipmentSlots = equipmentSlotsParent.GetComponentInChildren<EquipmentSlot>();
     } */

    public bool AddItem(EquippableItem item, out EquippableItem previousItem) 
    {
        for (int i = 0; i < equipmentSlots.Length; i++) //Look for slots
        {
            if (equipmentSlots[i].EquipmentType == item.EquipmentType) //If slot can hold the item type
            {
                previousItem = (EquippableItem)equipmentSlots[i].Item; //Replace old item
                equipmentSlots[i].Item = item;
                return true;
            } else
            {
                Debug.Log("Slot does not exist");
            }
        }
        previousItem = null;
        return false;
    }

    public bool RemoveItem(EquippableItem item) 
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if (equipmentSlots[i].Item == item) //Get the item out of the equipment slot
            {
                equipmentSlots[i].Item = null;
                return true;
            }
        }

        return false;
    }
}