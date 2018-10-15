using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; //Detect input
using System;

public class ItemSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {

    [SerializeField] Image image;
    [SerializeField] ItemTooltip tooltip;
    public event Action<Item> OnLeftClickEvent;
    private Item _Item;
    public Item Item //Property
    {
        get { return _Item; }
        set
        {
            _Item = value; 
            if (_Item == null) //Update the image slot for the item
            {
                image.enabled = false;
            } else
            {
                image.sprite = _Item.Icon;
                image.enabled = true;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData) //Get input for 
    {
        if(eventData != null && eventData.button == PointerEventData.InputButton.Left) //If the button clicked was correct
        {
            if (Item != null && OnLeftClickEvent != null)
                OnLeftClickEvent(Item);
        }
    }

    protected virtual void OnValidate() //Get the children image of the component
    {
        if (image == null)
            image = GetComponent<Image>();

        if (tooltip == null)
            tooltip = FindObjectOfType<ItemTooltip>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (Item is EquippableItem)
        {
            tooltip.ShowToolTip((EquippableItem)Item); //Show the tip for the specific item
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.HideToolTip();
    }
}
