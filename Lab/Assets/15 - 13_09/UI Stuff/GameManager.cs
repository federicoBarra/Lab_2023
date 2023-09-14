using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//Disclaimer - Esto es basico


public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	void Awake()
	{
		if (!instance)
		{
			//DontDestroyOnLoad(gameObject);
			instance = this;
		}
		else
			Destroy(gameObject);
	}

	public PlayerData data;

	public float finalPlayerHealth;
	public float maxPlayerHealth;

	public void SaveScoring(float _h, float _mh)
	{
		finalPlayerHealth = _h;
		maxPlayerHealth = _mh;
	}

	public void FinishLevel()
	{
		SceneManager.LoadScene("15_ResultScreen");
	}
}
