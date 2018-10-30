using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharacterName : MonoBehaviour
{

	public Dropdown dropdown;
	public Text selectedTitle;
	
	
	public InputField nameField;
	private string charName;
	public Text nameDisplay;
	
	
	public GameObject canvas;
	public GameObject nameCanvas;

	public void Start()
	{
		canvas.SetActive(false);
	}

	public void OnSubmit()
	{

		
		charName = nameField.text;
		nameDisplay.text = charName;
		nameCanvas.SetActive(false);
		nameField.enabled = false;
		Time.timeScale = 1;
		canvas.SetActive(true);
		
	}
}
