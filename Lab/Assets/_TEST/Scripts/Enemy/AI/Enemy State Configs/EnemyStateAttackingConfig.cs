using System;
using UnityEngine;

namespace SomeGame.Enemies
{
	[CreateAssetMenu(fileName = "Enemy Attack", menuName = "FedeFSM/Enemy/State Configs/Attack")]
	public class EnemyStateAttackingConfig : EnemyStateConfig
	{
		public override Type StateType => typeof(EnemyStateAttacking);

		[SerializeField] float hitTime = 0.5f;
		public float HitTime => hitTime;

		[SerializeField] float releaseTime = 1;
		public float ReleaseTime => releaseTime;

		[SerializeField] float targetMaxDistance = 1;
		public float TargetMaxDistance => targetMaxDistance;

		[SerializeField] float speedMultiplierOnState = 0.8f;
		public float SpeedMultiplierOnState => speedMultiplierOnState;

		[SerializeField] EnemyStateConfig targetGotAwayNextState;
		public EnemyStateConfig TargetGotAwayNextState => targetGotAwayNextState;
	}
}