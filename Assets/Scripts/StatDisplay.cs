using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StatDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {


    public Text NameText;
	public Text ValueText;
    [SerializeField] StatTooltip tooltip;
    private void OnValidate()
	{
		Text[] texts = GetComponentsInChildren<Text>();
		//Same order as they appear in the hierarchy
		NameText = texts[0];
		ValueText = texts[1];
	}

    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }
}
