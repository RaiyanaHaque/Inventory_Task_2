using UnityEngine;
using UnityEditor;

[CreateAssetMenu]

//Allows to create assets for items
public class Item : ScriptableObject {

	//Every item is going to be unique in the inventory despite being the same in items
	[SerializeField] string id;
	public string ID {  get { return id; } }
    public string ItemName;
    public Sprite Icon;

	private void OnValidate()
	{
		string path = AssetDatabase.GetAssetPath(this);
		id = AssetDatabase.AssetPathToGUID(path);
	}
	
}
