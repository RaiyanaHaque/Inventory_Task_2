﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inventor.CharacterStats;

public class StatPanel : MonoBehaviour {

	[SerializeField] StatDisplay[] statDisplays;
	[SerializeField] string[] statNames;

	private CharacterStat[] stats;

	private void OnValidate()
	{
		statDisplays = GetComponentsInChildren<StatDisplay>();
	}

	public void SetStats(params CharacterStat[] charStats)
	{
		stats = charStats;

		if(stats.Length > statDisplays.Length)
		{
			Debug.LogError("Not enough stat displays");
				return;
		}

		for (int i = 0; i < statDisplays.Length; i++)
		{
			statDisplays[i].gameObject.SetActive(i < stats.Length);
		}
	} 

	public void UpdatStatValue()
	{
		for(int i = 0; i < stats.Length; i++)
		{
			statDisplays[i].ValueText.text = stats[i].Value.ToString();
		}
	}

	public void UpdatStatNames()
	{
		for (int i = 0; i < statNames.Length; i++)
		{
			statDisplays[i].NameText.text = statNames[i];
		}
	}
}