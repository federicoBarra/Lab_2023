using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "FactionConfig", menuName = "WC/FactionConfig")]
public class FactionConfig : ScriptableObject
{
	public string displayName;
	[TextArea]
	public string description;

	public List<FactionConfig> enemyFactions;

}
