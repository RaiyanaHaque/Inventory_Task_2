using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryInput : MonoBehaviour
{
    [SerializeField] GameObject inventoryGameObject;
    [SerializeField] KeyCode[] toggleInventoryKeys; //An array would allow multiple key codes

    // Update is called once per frame
    void Update()
    {
        //Look through the keys
        for (int i = 0; i < toggleInventoryKeys.Length; i++)
        {
            //If key is being pressed from the index
            if (Input.GetKeyDown(toggleInventoryKeys[i]))
            {
                inventoryGameObject.SetActive(!inventoryGameObject.activeSelf); //Opposite value of its curr state
                break; //Get out of the loop, not risk pressing multiple keys in the same frame
            }
        }              
	}
}
