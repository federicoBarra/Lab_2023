using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "WC/EnemyConfig")]
public class EnemyConfig : ScriptableObject
{
	//public enum FactionType
	//{
	//	Orco,		//0
	//	Skeleton,	//1
	//	MarcianoGilastrun,	//2
	//	Cubano		//3
	//}

	public enum Planets
	{
		VEnu,
		Marte, 
		Tierra
	}



	public string nombre = "Tito";
	//public string nombreDeFaction = "Marciano";
	//public FactionType faction;

	public FactionConfig factionConfig;
}

public class Planet
{
	public Planet type;
	public int size;
}

public class PlanetConfig : ScriptableObject
{
	public string nombre = "Tito";
	public int size;
	public string description = "Tito";

}