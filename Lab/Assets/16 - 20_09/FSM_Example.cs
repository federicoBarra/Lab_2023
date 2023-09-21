using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingState : EntityState
{
	private float flyingSpeed;
	private bool floating;

	public FlyingState(StateMachine _machine, EntityData _data, float _flyingSpeed) : base(_machine, _data)
	{
		flyingSpeed = _flyingSpeed;
	}

	public override void Enter()
	{
		floating = true;
		//throw new System.NotImplementedException();
	}

	public override void Update()
	{
		// update de flying al enemigo
		//muevo al entity usando flying speed

		//Checkeo condicion y si pasa algo
		//machine.ChangeState<IdleState>();

	}

	public override void Exit()
	{
		throw new System.NotImplementedException();
	}
}
