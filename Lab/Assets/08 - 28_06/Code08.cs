using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navecita
{
	public Player07 player;

	public enum NAveState
	{
		Movement,
		MidAir,
		PegandoLaVueltereta,
		Stuned
	}

	private NAveState currentState;

	void Update()
	{
		switch (currentState)
		{
			case NAveState.Movement: //monobehaiurs
				//puedo pegar?
				player.Move();
				// 1000 lineas
				break;
			case NAveState.MidAir:
				//puedo pegar?
				player.Move();
				// 1000 lineas diferentes a las de Movement
				break;
			case NAveState.PegandoLaVueltereta:
				player.Move();
				break;
			case NAveState.Stuned:
				break;
		}
	}


}



public class Code08 : MonoBehaviour
{
	private Player07 player;

    // Start is called before the first frame update
    void Start()
    {
		int lastLevelSaved = 0;

	    try
	    {
		    Debug.Log(player.speed);
		    Debug.Log("Hola");
		    //lastLevelSaved = leer de disco;
		}
	    catch (NullReferenceException e)
	    {
		    Debug.Log("Catcheo el error");
		    Debug.Log(e);
		    //throw;
	    }
	    catch (AggregateException ne)
	    {

	    }

		//Time.unscaledDeltaTime
		//Debug.Log(player.speed);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}


public class PEpe
{
	Action action;


	void Subscribe()
	{
		action += MetodoLoco;
		action += MetodoLoco02;
		action += MetodoLoco;
		action += MetodoLoco;
		action += MetodoLoco;


		action();

		action -= MetodoLoco;

	}

	void MetodoLoco()
	{

	}

	void MetodoLoco02()
	{

	}
}
