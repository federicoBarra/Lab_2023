using System;
using UnityEngine;

[Serializable]
public class PlayerData
{
	public float maxHealth;
	public string playerName;
}

public class PlayerController_15 : MonoBehaviour
{
	public PlayerData data;

	public float currentHealth;

	public static event Action<PlayerController_15> OnReceiveDamage;

	void Awake()
	{
		currentHealth = data.maxHealth;
		//DontDestroyOnLoad(gameObject);
	}

    void Update()
    {
	    if (Input.GetKeyDown(KeyCode.Space))
		    ReceiveDamage(10);
    }

    private void ReceiveDamage(int damage)
    {
	    currentHealth -= damage;
	    //if (currentHealth < 0)
		//    currentHealth = 0;
	    currentHealth = Mathf.Clamp(currentHealth, 0, data.maxHealth);

	    OnReceiveDamage?.Invoke(this);
	}
}
