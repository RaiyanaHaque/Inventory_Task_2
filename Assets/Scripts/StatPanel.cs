using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inventor.CharacterStats;

public class StatPanel : MonoBehaviour {

	[SerializeField] StatDisplay[] statDisplays;
	[SerializeField] string[] statNames; //Change stat names in UI

	private CharacterStat[] stats;

	private void OnValidate()
	{
		statDisplays = GetComponentsInChildren<StatDisplay>();
	}

	public void SetStats(params CharacterStat[] charStats) //Array of character stats
	{
		stats = charStats;

		if(stats.Length > statDisplays.Length) //More stats than stats display
		{
			Debug.LogError("Not enough stat displays");
				return;
		}

		for (int i = 0; i < statDisplays.Length; i++) //More stat displays than stats
		{
			statDisplays[i].gameObject.SetActive(i < stats.Length);
		}
	} 

	public void UpdateStatValue()
	{
		for(int i = 0; i < stats.Length; i++)
		{
			statDisplays[i].ValueText.text = stats[i].Value.ToString(); //Sets correspoinding stat display values. called from character class
		}
	}

	public void UpdateStatNames() //Sets correspoing names from the stat displays
	{
		for (int i = 0; i < statNames.Length; i++)
		{
			statDisplays[i].NameText.text = statNames[i];
		}
	}
}
