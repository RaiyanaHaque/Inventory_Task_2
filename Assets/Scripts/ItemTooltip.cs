using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemTooltip : MonoBehaviour
{
	[SerializeField] Text ItemNameText;
	[SerializeField] Text ItemSlotText;
	[SerializeField] Text ItemStatsText;

    private StringBuilder sb = new StringBuilder(); //Allows to connect several things together

    public void ShowToolTip(EquippableItem item)
    {
        ItemNameText.text = item.ItemName;
        ItemSlotText.text = item.EquipmentType.ToString();

        sb.Length = 0; //Reset


        //8 possible stat options
        sb.Length = 0;
        AddStat(item.StrengthBonus, "Strength");
        AddStat(item.AgilityBonus, "Agility");
        AddStat(item.IntelligenceBonus, "Intelligence");
        AddStat(item.VitalityBonus, "Vitality");

        //Set percent to true
        AddStat(item.StrengthPercentBonus, "Strength", isPercent: true); 
        AddStat(item.AgilityPercentBonus, "Agility", isPercent: true);
        AddStat(item.IntelligencePercentBonus, "Intelligence", isPercent: true);
        AddStat(item.VitalityPercentBonus, "Vitality", isPercent: true);

        ItemStatsText.text = sb.ToString(); //Call the correct text object

        gameObject.SetActive(true);
    }

    public void HideToolTip()
    {
        gameObject.SetActive(false); //Disables the tooltip section
    }

    private void AddStat(float value, string statName, bool isPercent = false) //Method to add stats in the string builder
    {
        if (value != 0)
        {
            if (sb.Length > 0)
                sb.AppendLine(); //If not the first stat, write in next line

            if (value > 0)
                sb.Append("+"); //If negative

            if (isPercent) //Multiply by 100
            {
                sb.Append(value * 100);
                sb.Append("% ");
            } 
            else //Go back to the previous way
            {
                sb.Append(value);
                sb.Append(" ");
            }
            sb.Append(statName);
        }
    }
}
