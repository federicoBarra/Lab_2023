using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Code14 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class PlayerTest
{
	public float life;
	public float maxLife;
	//private UIPlayerHUD ui;

	public static event Action<PlayerTest> OnDatachanged;
	//delegate void ActionLoca(PlayerTest a);
	//private event ActionLoca pepe;
	//scriptable Object

	void Update()
	{
		//ui.SetLife(100);

		//scriptableObject.setValue()
	}

	void ReceiveDamage()
	{
		OnDatachanged?.Invoke(this);
	}
}


public class UIPlayerBase : MonoBehaviour
{
	public Image fillImage;

	void Start()
	{

	}
	public void SetLife(float f)
	{
		fillImage.fillAmount = f;
	}
}

public class UIPlayerHUD : MonoBehaviour
{
	public PlayerTest player;
	public Image fillImage;

	//scriptable Object

	void Start()
	{
		//scriptableObjectEvent += RefreshLife();
		PlayerTest.OnDatachanged += RefreshData;
		PlayerTest.OnDatachanged += RefreshData02;

		PlayerTest.OnDatachanged -= RefreshData;
	}

	private void RefreshData(PlayerTest obj)
	{
		//refreshUI
	}

	private void RefreshData02(PlayerTest obj)
	{
		//refreshUI
	}


	void Update()
	{
		fillImage.fillAmount = player.life / player.maxLife;
	}

	public void SetLife(float f)
	{
		fillImage.fillAmount = f;
	}
}

public class UIHelthOverPlayer : MonoBehaviour
{
	void Start()
	{
		//scriptableObjectEvent += RefreshLife();
		PlayerTest.OnDatachanged += RefreshData;
	}

	private void RefreshData(PlayerTest obj)
	{
		throw new NotImplementedException();
	}
}
public interface IParticulas
{

}


public interface IObjecto : IParticulas
{

}

public interface ITargeteable : IObjecto
{
	void GetCosa();

	//public Transform Target
}

public interface ILoca : ITargeteable
{
	void GetOtraCosa();
}


public class EnemyManager
{
	public ITargeteable Target;

	public ITargeteable Player;

	public List<Enemy> enmemies;

	void Awake()
	{
		//GameObject.FindObjectsOfType<ITargeteable>();

		//FindObejct
	}

	public void InstanciateEnemy()
	{
		//new enemty(Target)
	}


	void ChangeTargetOnAllEnemies()
	{
		foreach (Enemy enemy in enmemies)
		{
			//get enemi mas cerca;
			//enemy.SetNewTarget(enemy cerca);
		}
	}
}

public class Enemy : ITargeteable
{
	public ITargeteable Target;

	public PlayerTest target;

	void Awwake()
	{
		// NOOOOOOO FindObejct
	}

	public void SetNewTarget(ITargeteable t)
	{

	}

	public void GetCosa()
	{
		throw new NotImplementedException();
	}
}