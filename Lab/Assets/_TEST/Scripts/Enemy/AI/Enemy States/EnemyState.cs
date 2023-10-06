using UnityEngine;
using UnityEngine.AI;
using Utils.NewStateMachine;

namespace SomeGame.Enemies
{
	public class EnemyState : MachineState
	{
		protected Transform Owner => enemyStateMachine.Enemy;
		private EnemyStateMachine enemyStateMachine;

		[SerializeField] private Animator animator;
		public Animator EnemyAnimator => animator;

		[SerializeField] private NavMeshAgent agent;
		public NavMeshAgent Agent => agent;

		protected float stateTime = 0;

		public EnemyState(EnemyStateMachine _machine, StateConfig _config) : base(_machine, _config)
		{
			enemyStateMachine = _machine;
			animator = Owner.GetComponentInChildren<Animator>();
			agent = Owner.GetComponent<NavMeshAgent>();
		}

		public override void Enter()
		{
			//Debug.Log("ENTER: " + config.StateType);
			stateTime = 0;
		}

		public override void Update()
		{
			stateTime += Time.deltaTime;
		}

		public override void Exit()
		{
		}
	}
}