using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIResultScreen : MonoBehaviour
{
	public TMP_Text finalHealth;
	public TMP_Text maxHealth;

	void Awake()
	{
		PlayerController_15 p =FindAnyObjectByType<PlayerController_15>();
	}

	void Start()
	{
		float fh = GameManager.instance.finalPlayerHealth;
		float fmh = GameManager.instance.maxPlayerHealth;


		finalHealth.text = fh.ToString();
		maxHealth.text = fmh.ToString();
	}
}
