using System;
using UnityEngine;

namespace SomeGame.Enemies
{
	[CreateAssetMenu(fileName = "Enemy Chasing", menuName = "FedeFSM/Enemy/State Configs/Chasing")]
	public class EnemyStateChasingConfig : EnemyStateConfig
	{
		public override Type StateType => typeof(EnemyStateChasing);

		[SerializeField] float chaseStopDistance = 1;
		public float ChaseStopDistance => chaseStopDistance;

		[SerializeField] EnemyStateConfig arrivedAtTargetNextState;
		public EnemyStateConfig ArrivedAtTargetNextState => arrivedAtTargetNextState;
	}
}