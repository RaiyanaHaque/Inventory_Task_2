using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inventor.CharacterStats;

public class Character : MonoBehaviour
{
	public CharacterStat Strength; 
	public CharacterStat Agility;
	public CharacterStat Intelligence;
	public CharacterStat Vitality;

	[SerializeField] Inventory inventory;
    [SerializeField] EquipmentPanel equipmentPanel;
    [SerializeField] StatPanel statPanel;
    private void Awake()
    {
        statPanel.SetStats(Strength, Agility, Intelligence, Vitality);
        statPanel.UpdateStatValues();

        inventory.OnItemLeftClikedEvent += EquipFromInventory; //Item clicked equip it from inventory
        equipmentPanel.OnItemLeftClikedEvent += UnequipFromEquipPanel; //Item clicked goes back to inventory
    }

    private void EquipFromInventory(Item item)
    {
        if (item is EquippableItem)
        {
            Equip((EquippableItem)item); //Equip only equippable items when clicked
        }
    }

    private void UnequipFromEquipPanel(Item item)
    {
        if (item is EquippableItem)
        {
            Unequip((EquippableItem)item);
        }
    }

    public void Equip(EquippableItem item)
    {
        if(inventory.RemoveItem(item)) //Remove item from inventory 
        {
            EquippableItem previousItem;
            if (equipmentPanel.AddItem(item, out previousItem)) //Add to equipment panel
            {
                if(previousItem != null) //Equipment slot already occupied
                {
                    inventory.AddItem(previousItem); //Return it back to inventory
                    previousItem.Unequip(this);
                    statPanel.UpdateStatValues();
                }

                item.Equip(this);
                statPanel.UpdateStatValues(); //Update the values
            }

            else
            {
                inventory.AddItem(item); //Can't be equipped = return to inventory
            }
        }
    }

    public void Unequip(EquippableItem item)
    {
        if (!inventory.IsFull() && equipmentPanel.RemoveItem(item)) //Inventory is not full
        {
            item.Unequip(this);
            statPanel.UpdateStatValues(); //Update value after unequiping
            inventory.AddItem(item); //Add item back to inventory
        }
    }

}
