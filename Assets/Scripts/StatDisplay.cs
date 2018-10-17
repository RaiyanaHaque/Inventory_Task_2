using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Inventor.CharacterStats;

public class StatDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    private CharacterStat _stat;
    public CharacterStat Stat
    {
        get { return _stat; }
        set
        {
            _stat = value; //return stat variable
            UpdateStatValue(); //Assign value to the stat variable & update value text object with value of stat
        }
    }


    private string _name;
    public string Name
    {
        get { return _name; }
        set
        {
            _name = value;
            nameText.text = _name;
        }
    }


    [SerializeField] Text nameText;
    [SerializeField] Text valueText;
    [SerializeField] StatTooltip tooltip;

    private void OnValidate()
    {
        Text[] texts = GetComponentsInChildren<Text>();
        //Same order as they appear in the hierarchy
        nameText = texts[0];
        valueText = texts[1];

    }

    //Show the stats when hovered over
    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.ShowToolTip(Stat, Name);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.HideToolTip();
    }

    public void UpdateStatValue()
    {
        valueText.text = _stat.Value.ToString();
    }

}
