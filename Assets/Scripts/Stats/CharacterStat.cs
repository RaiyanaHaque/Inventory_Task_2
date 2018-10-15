using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;

namespace Inventor.CharacterStats
{
	[Serializable]
	public class CharacterStat
	{

		public float BaseVal;
		public float Value
		{
			get
			{
				if (isStat || BaseVal != lastBaseVal)
				{
					lastBaseVal = BaseVal;
					_value = CalculateFinalVal();
					isStat = false;
				}

				return _value;
			}
		}
		private bool isStat = true;
		private float _value;
		private float lastBaseVal = float.MinValue;
		private readonly List<StatModifier> statModifiers;
		public readonly ReadOnlyCollection<StatModifier> StatModifiers;

		public CharacterStat()
		{
			statModifiers = new List<StatModifier>();
			StatModifiers = statModifiers.AsReadOnly();
		}

		public CharacterStat(float baseVal) : this()
		{
			BaseVal = baseVal;

		}

		public void AddModifier(StatModifier mod)
		{
			isStat = true;
			statModifiers.Add(mod);
			statModifiers.Sort(CompareModifierOrder);
		}

		private int CompareModifierOrder(StatModifier a, StatModifier b)
		{
			if (a.Order < b.Order)
				return -1;
			else if (a.Order > b.Order)
				return 1;
			return 0;
		}

		public bool RemoveModifier(StatModifier mod)
		{
			if (statModifiers.Remove(mod))
			{
				isStat = true;
				return true;
			}

			return false;
		}

		public bool RemoveAllModifiersFromSource(object source)
		{
			bool didRemove = false;

			for (int i = statModifiers.Count - 1; i >= 0; i--)
			{
				if (statModifiers[i].Source == source)
				{
					isStat = true;
					didRemove = true;
					statModifiers.RemoveAt(i);
				}
			}

			return didRemove;
		}

		private float CalculateFinalVal()
		{
			float finalVal = BaseVal;
			float sumPercentAdd = 0;
			for (int i = 0; i < statModifiers.Count; i++)
			{
				StatModifier mod = statModifiers[i];

				if (mod.Type == StatModType.Flat)
				{
					finalVal += mod.Value;
				}

				else if (mod.Type == StatModType.PercentAdd)
				{
					sumPercentAdd += mod.Value;

					if (i + 1 >= statModifiers.Count || statModifiers[i + 1].Type != StatModType.PercentAdd)
					{
						finalVal *= 1 + sumPercentAdd;
						sumPercentAdd = 0;
					}
				}

				else if (mod.Type == StatModType.PercentMult)
				{
					finalVal *= 1 + mod.Value;
				}
			}

			return (float)Math.Round(finalVal, 4);
		}
	}
}
