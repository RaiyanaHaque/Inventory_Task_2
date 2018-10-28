using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    float moveSpeed = 10;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime); //Player movement
        float mouseInput = moveSpeed * Input.GetAxis("Mouse X"); //Get mouse input axis
        Vector3 lookHere = new Vector3(0, mouseInput, 0); //X axis follows the cursor position 
        transform.Rotate(lookHere); 
    }
}
