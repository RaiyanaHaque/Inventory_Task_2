using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class ItemChest : MonoBehaviour
{

	[SerializeField] Item item;
	[SerializeField] Inventory inventory;
	[SerializeField] SpriteRenderer spriteRenderer;
	[SerializeField] ParticleSystem chestGlow;
	[SerializeField] Color emptyColor;
	private bool inRange;
	private bool isEmpty;

	private void Start()
	{
		spriteRenderer.sprite = item.Icon; //Set the sprite as the image of the icon
		spriteRenderer.enabled = false; 
	}
	private void Update()
	{
		if (inRange && Input.GetMouseButton(1)) 
		{
			if (!isEmpty)
			{
				inventory.AddItem(item); //Once the item is added to the inventory
				isEmpty = true; //Item in chest is null
				spriteRenderer.color = emptyColor; //Change color when it is empty
				chestGlow.Stop();
			}			
		}
	}

	private void OnTriggerEnter(Collider gameObject) //In range of the item
	{
     
        if (gameObject.CompareTag("Player"))
        {
            inRange = true;
            spriteRenderer.enabled = true;
            Debug.Log("Working range");
        }
   
    }

	private void OnTriggerExit(Collider gameObject)
	{
        if (gameObject.CompareTag("Player"))
        {
            inRange = false;
            spriteRenderer.enabled = false;
        }
	}
}
