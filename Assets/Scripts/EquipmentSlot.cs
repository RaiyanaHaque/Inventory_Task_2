using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSlot : ItemSlot //Subclass of ItemSlot
{
    public EquipmentType EquipmentType; //Enum created before

    protected override void OnValidate()
    {
        base.OnValidate();
        gameObject.name = EquipmentType.ToString() + " Slot";
		// Name the slot automatically depending on the equipment type
    }
	
}
