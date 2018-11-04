using UnityEngine;
using UnityEditor;

[CreateAssetMenu]

//Allows to create assets for items
public class Item : ScriptableObject {

    public string ItemName;
    public Sprite Icon;
}
