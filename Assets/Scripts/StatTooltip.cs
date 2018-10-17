using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;
using Inventor.CharacterStats;

public class StatTooltip : MonoBehaviour
{
    [SerializeField] Text StatNameText;
    [SerializeField] Text ModifierLabelText;
    [SerializeField] Text ModifierText;

    private StringBuilder sb = new StringBuilder(); //Allows to connect several things together

    public void ShowToolTip(CharacterStat stat, string statName) //Looking char stat instead of item
    {
        StatNameText.text = GetStatTopText(stat, statName);
        ModifierText.text = GetStatModifierText(stat);
        gameObject.SetActive(true);
    }

    public void HideToolTip()
    {
        gameObject.SetActive(false); //Disables the tooltip section
    }

    private string GetStatTopText(CharacterStat stat, string statName)
    {
        sb.Length = 0; //Reset string
        sb.Append(statName); //Add stat name
        sb.Append(" ");
        sb.Append(stat.Value);

        if (stat.Value != stat.BaseVal) //Parantheses should not should show unless theres any changes
        {
            sb.Append(" (");
            sb.Append(stat.BaseVal);

            if (stat.Value > stat.BaseVal)
                sb.Append("+"); //Only plus sign if stat val bigger that base val

            sb.Append(System.Math.Round(stat.Value - stat.BaseVal, 4)); //Due to floats, use significant numbers
            sb.Append(")"); //Difference calc
        }
        
        return sb.ToString();
    }

    private string GetStatModifierText(CharacterStat stat)
    {
        sb.Length = 0; //Reset
        foreach (StatModifier mod in stat.StatModifiers) //Look at all stat modifiers
        {
            if (sb.Length > 0) //If not the first modifier added to the string
                sb.AppendLine();
            if (mod.Value > 0)
                sb.Append("+");

            if (mod.Type == StatModType.Flat) //Check if the modif is a percentage
            {
                sb.Append(mod.Value);
            } else
            {
                sb.Append(mod.Value * 100);
                sb.Append("%");
            }
            
            EquippableItem item = mod.Source as EquippableItem; //Acess source variable

            if (item != null) //Not equippable
            {
                sb.Append(" ");
                sb.Append(item.ItemName);
            }

            else
            {
                Debug.LogError("Modifier is not EquippableItem");
            }
        }

        return sb.ToString();
    }
}

