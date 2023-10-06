using System;
using UnityEngine;

namespace SomeGame.Enemies
{
	[CreateAssetMenu(fileName = "Enemy Idle", menuName = "FedeFSM/Enemy/State Configs/Idle")]
	public class EnemyStateIdleConfig : EnemyStateConfig
	{
		public override Type StateType => typeof(EnemyStateIdle);

		[SerializeField] float timeOutTime = 1;
		public float TimeOutTime => timeOutTime;

		[SerializeField] EnemyStateConfig timeoutNextState;
		public EnemyStateConfig TimeoutNextState => timeoutNextState;

		[SerializeField] float minHealthToChangeState = 80;
		public float MinHealthToChangeState => minHealthToChangeState;

		[SerializeField] EnemyStateConfig minHealthNextState;
		public EnemyStateConfig MinHealthNextState => minHealthNextState;

	}
}