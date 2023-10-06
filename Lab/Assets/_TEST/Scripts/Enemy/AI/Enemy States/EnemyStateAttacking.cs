using SomeGame.Entities;
using UnityEngine;
using Utils.NewStateMachine;

namespace SomeGame.Enemies
{
	public class EnemyStateAttacking : EnemyState
	{
		EnemyStateAttackingConfig attackConfig;
		EntityTargetProvider targetProvider;
		EntityAttack attack;
		float originalAgentSpeed;

		Transform targetIWantToAttack;

		public EnemyStateAttacking(EnemyStateMachine _machine, StateConfig _config) : base(_machine,
			_config)
		{
			attackConfig = (EnemyStateAttackingConfig)_config;
			targetProvider = Owner.GetComponent<EntityTargetProvider>();
			attack = Owner.GetComponent<EntityAttack>();
		}

		public override void Enter()
		{
			base.Enter();
			Agent.isStopped = false;
			targetIWantToAttack = targetProvider.Target;
			originalAgentSpeed = Agent.speed;
			Agent.speed = originalAgentSpeed * attackConfig.SpeedMultiplierOnState;
		}

		public override void Update()
		{
			base.Update();
			Agent.SetDestination(targetIWantToAttack.position);
			EnemyAnimator.SetFloat("Forward", Agent.velocity.magnitude / originalAgentSpeed);

			float distanceToTarget = Vector3.Distance(Owner.position, targetIWantToAttack.position);

			if (distanceToTarget > attackConfig.TargetMaxDistance)
				machine.SetState(attackConfig.TargetGotAwayNextState);

			if (attack.CanAttack)
				attack.StartAttack(attackConfig.HitTime, attackConfig.ReleaseTime);
		}

		public override void Exit()
		{
			base.Exit();
			Agent.speed = originalAgentSpeed;
		}
	}
}