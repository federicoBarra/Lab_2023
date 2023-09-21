using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine { }

public class StateMachine
{
	private State currentState;
	private Dictionary<Type, State> states;

	public StateMachine()
	{
		states = new Dictionary<Type, State>();
	}
	public void AddState<T>(State state) where T : State
	{
		states.Add(typeof(T), state);
	}

	//Ejemplo
	//fsm = new StateMachine();
	//fsm.AddState<IdleState>(new IdleState(fsm, ed));

	public void Update()
	{
		//if (currentState != null)
		//	currentState.Update();
		//esto de arriba es lo mismo que escriir lo de abajo.

		currentState?.Update();
	}

	public void ChangeState<T>() where T : State //SetCurrentState
	{
		currentState?.Exit();

		Type nextStateType = typeof(T);
		if (states.TryGetValue(nextStateType, out var state))
		{
			currentState = state;
			currentState.Enter();

			Debug.Log("Changing state to: " + nextStateType.Name);
		}
		else
		{
			Debug.LogError(nextStateType.Name + " : is not registered.");
		}
	}
}

public abstract class State
{
	protected StateMachine machine;
	protected Dictionary<Type, Condition> conditions = new Dictionary<Type, Condition>();

	protected State(StateMachine _machine)
	{
		machine = _machine;
	}
	public bool CheckCondition<T>() where T : Condition
	{
		bool ret = false;
		Type conditionType = typeof(T);
		if (conditions.TryGetValue(conditionType, out var condition))
			ret = condition.Check();
		else
			Debug.LogError("Condition not found: " + conditionType.Name);

		return ret;
	}
	public abstract void Enter();
	public abstract void Update();
	public abstract void Exit();
}


public class Condition
{
	public virtual bool Check() => true;
}