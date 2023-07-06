using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[CreateAssetMenu(fileName = "FactionsConfig", menuName = "WC/FactionsConfig")]
public class FactionsConfig : ScriptableObject
{
	public List<FactionConfig> availableFactions;

	void OnValidate()
	{
		FactionConfig[] factions = Resources.FindObjectsOfTypeAll<FactionConfig>();
		availableFactions = factions.ToList();
	}

}
