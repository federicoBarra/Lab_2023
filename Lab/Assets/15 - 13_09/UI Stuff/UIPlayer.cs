using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayer : MonoBehaviour
{
	public PlayerController_15 player;

	public TMP_Text playerName;
	public Image lifeBarFill;
	
    void Start()
    {
	    playerName.text = player.data.playerName;

	    lifeBarFill.fillAmount = player.currentHealth / player.data.maxHealth;
	    PlayerController_15.OnReceiveDamage += RefreshCosas;
    }

    void OnDisable()
    {
	    PlayerController_15.OnReceiveDamage -= RefreshCosas;
	}

    private void RefreshCosas(PlayerController_15 obj)
    {
		lifeBarFill.fillAmount = player.currentHealth / player.data.maxHealth;
	}


    public void EndLevel()
    {
	    GameManager.instance.SaveScoring(player.currentHealth, player.data.maxHealth);
		GameManager.instance.FinishLevel();
    }
}
