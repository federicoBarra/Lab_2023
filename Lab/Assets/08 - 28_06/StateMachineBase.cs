using System;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineBase : MonoBehaviour
{
	public EntityData ed;

	private StateMachine fsm;
	// Start is called before the first frame update
	void Start()
	{
		fsm = new StateMachine();
		fsm.AddState<IdleState>(new IdleState(fsm, ed));
		fsm.AddState<MovingState>(new MovingState(fsm, ed, 17));

		fsm.ChangeState<IdleState>();
	}

    // Update is called once per frame
    void Update()
    {
        fsm.Update();
    }
}

[Serializable]
public class EntityData
{
	public int health = 100;
	public int minHealth = 20;
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

public abstract class EntityState :State
{
	protected EntityData data;

	protected EntityState(StateMachine _machine, EntityData _data) :base(_machine)
	{
		data = _data;
	}
}

public class IdleState : EntityState
{
	public IdleState(StateMachine _machine, EntityData _data) : base(_machine, _data)
	{
		conditions.Add(typeof(LowHeathCondition), new LowHeathCondition(_data));
	}

	public override void Enter() { }

	public override void Update()
	{
		if (CheckCondition<LowHeathCondition>())
			machine.ChangeState<MovingState>();
	}

	public override void Exit() { }
}

public class MovingState : EntityState
{
	public float movingSpeed;
	public MovingState(StateMachine _machine, EntityData _data, float _movingSpeed) : base(_machine, _data)
	{
		movingSpeed = _movingSpeed;
	}

	public override void Enter() { }

	public override void Update() 
	{ 
		//hacer algo
	}

	public override void Exit() { }
}


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

	public void Update()
	{
		currentState?.Update();
	}

	public void ChangeState<T>() where T : State
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


public class Condition
{
	public virtual bool Check() => true;
}

public class LowHeathCondition : Condition
{
	private EntityData od;

	public LowHeathCondition(EntityData _od)
	{
		od = _od;
	}

	public override bool Check()
	{
		return od.health < od.minHealth;
	}
}