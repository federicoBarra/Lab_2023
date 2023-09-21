using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EntityData
{
	public int health = 100;
	public int minHealth = 20;
}


public class StateMachineBase : MonoBehaviour // esto podria ser una clase Enemy
{
	public EntityData ed;

	private StateMachine fsm;
	// Start is called before the first frame update
	void Start()
	{
		fsm = new StateMachine();
		fsm.AddState<IdleState>(new IdleState(fsm, ed));
		fsm.AddState<MovingState>(new MovingState(fsm, ed, 17));
		fsm.AddState<FlyingState>(new FlyingState(fsm, ed, 20));

		fsm.ChangeState<IdleState>();
	}

    // Update is called once per frame
    void Update()
    {
        fsm.Update();
    }
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
		conditions.Add(typeof(LowHeathCondition), new LowHeathCondition(_data));
		movingSpeed = _movingSpeed;
	}

	public override void Enter() { }

	public override void Update() 
	{ 
		//hacer algo
	}

	public override void Exit() { }
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