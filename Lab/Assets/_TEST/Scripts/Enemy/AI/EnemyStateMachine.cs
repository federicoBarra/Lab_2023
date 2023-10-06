using UnityEngine;
using Utils.NewStateMachine;

namespace SomeGame.Enemies
{
	public class EnemyStateMachine : Utils.NewStateMachine.StateMachine
	{
		public Transform Enemy { get; }

		public EnemyStateMachine(Transform enemy) : base()
		{
			Enemy = enemy;
		}
	}
}