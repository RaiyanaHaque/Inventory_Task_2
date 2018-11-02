using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inventor.CharacterStats;

public enum EquipmentType
{
	Helmet,
	Chest, 
	Arm,
	Boots, 
	Weapon,
    Misc
}

[CreateAssetMenu]
public class EquippableItem : Item

{
	//Four stats
	public int StrengthBonus;
	public int AgilityBonus;
	public int IntelligenceBonus;
	public int VitalityBonus;

	[Space] //Space b

	//Percentage bonus to the base value
	public float StrengthPercentBonus;
	public float AgilityPercentBonus;
	public float IntelligencePercentBonus;
	public float VitalityPercentBonus;

	[Space]

	public EquipmentType EquipmentType;

    public void Equip(Character c) //Character only input param
    {
		//Add on score
        if (StrengthBonus != 0)
            c.Strength.AddModifier(new StatModifier(StrengthPercentBonus, StatModType.Flat, this));
        if (AgilityBonus != 0)
            c.Agility.AddModifier(new StatModifier(AgilityPercentBonus, StatModType.Flat, this));
        if (IntelligenceBonus != 0)
            c.Intelligence.AddModifier(new StatModifier(IntelligencePercentBonus, StatModType.Flat, this));
        if (VitalityBonus != 0)
            c.Vitality.AddModifier(new StatModifier(VitalityPercentBonus, StatModType.Flat, this));

        if (StrengthPercentBonus != 0)
            c.Strength.AddModifier(new StatModifier(StrengthPercentBonus, StatModType.PercentMult, this));
        if (AgilityPercentBonus != 0)
            c.Agility.AddModifier(new StatModifier(AgilityPercentBonus, StatModType.PercentMult, this));
        if (IntelligencePercentBonus != 0)
            c.Intelligence.AddModifier(new StatModifier(IntelligencePercentBonus, StatModType.PercentMult, this));
        if (VitalityPercentBonus != 0)
            c.Vitality.AddModifier(new StatModifier(VitalityPercentBonus, StatModType.PercentMult, this));
    }

    public void Unequip(Character c) //Remove all the modiefied points
    {
        c.Strength.RemoveAllModifiersFromSource(this);
        c.Agility.RemoveAllModifiersFromSource(this);
        c.Intelligence.RemoveAllModifiersFromSource(this);
        c.Vitality.RemoveAllModifiersFromSource(this);
    }


}
