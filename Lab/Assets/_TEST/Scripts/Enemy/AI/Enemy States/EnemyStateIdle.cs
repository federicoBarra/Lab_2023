using SomeGame.Entities;
using UnityEngine;
using Utils.NewStateMachine;

namespace SomeGame.Enemies
{
	public class EnemyStateIdle : EnemyState
	{
		EnemyStateIdleConfig idleConfig;
		EntityHealth entityHealth;
		EntityTargetProvider targetProvider;

		public EnemyStateIdle(EnemyStateMachine _machine, StateConfig _config) : base(_machine, _config)
		{
			idleConfig = (EnemyStateIdleConfig)_config;
			entityHealth = Owner.GetComponent<EntityHealth>();
			targetProvider = Owner.GetComponent<EntityTargetProvider>();
		}

		public override void Enter()
		{
			base.Enter();
			entityHealth.OnReceiveDamage += DamageReceived;
			Agent.isStopped = true;
		}

		public override void Update()
		{
			base.Update();
			EnemyAnimator.SetFloat("Forward", 0);

			if (stateTime > idleConfig.TimeOutTime)
			{
				if (idleConfig.TimeoutNextState)
					machine.SetState(idleConfig.TimeoutNextState);
			}
		}

		void DamageReceived(float damage, Transform damageOwner)
		{
			if (entityHealth.Health < idleConfig.MinHealthToChangeState)
			{
				targetProvider.Target = damageOwner;
				machine.SetState(idleConfig.MinHealthNextState);
			}
		}

		public override void Exit()
		{
			entityHealth.OnReceiveDamage -= DamageReceived;
			base.Exit();
		}
	}
}