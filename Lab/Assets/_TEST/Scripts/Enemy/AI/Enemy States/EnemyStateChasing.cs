using SomeGame.Entities;
using UnityEngine;
using Utils.NewStateMachine;

namespace SomeGame.Enemies
{
	public class EnemyStateChasing : EnemyState
	{
		EnemyStateChasingConfig chaseConfig;
		EntityTargetProvider targetProvider;

		Transform target;

		public EnemyStateChasing(EnemyStateMachine _machine, StateConfig _config) : base(_machine, _config)
		{
			chaseConfig = (EnemyStateChasingConfig)_config;
			targetProvider = Owner.GetComponent<EntityTargetProvider>();
		}

		public override void Enter()
		{
			base.Enter();
			Agent.isStopped = false;
			target = targetProvider.Target;
		}

		public override void Update()
		{
			base.Update();
			Agent.SetDestination(target.position);
			EnemyAnimator.SetFloat("Forward", Agent.velocity.magnitude / Agent.speed);
			float distanceToTarget = Vector3.Distance(Owner.position, target.position);

			if (distanceToTarget < chaseConfig.ChaseStopDistance)
				machine.SetState(chaseConfig.ArrivedAtTargetNextState);
		}
	}
}