using System.Collections.Generic;
using UnityEngine;

namespace SomeGame.Enemies
{
	public class StateMachineHandler : MonoBehaviour
	{
		public List<EnemyStateConfig> states;
		EnemyStateMachine fsm;

		Transform enemy;

		[Header("DEBUG")] public EnemyStateConfig DEBUG_currentState;

		// Start is called before the first frame update
		void Awake()
		{
			enemy = transform;
			fsm = new EnemyStateMachine(enemy);

			foreach (EnemyStateConfig config in states)
			{
				fsm.AddState(config);
			}

			fsm.SetState(states[0]);


		}

		// Update is called once per frame
		void Update()
		{
			fsm.Update();

			//Next stuff is DEBUG
			EnemyState cState = (EnemyState)fsm.DEBUGCurrentState;
			EnemyStateConfig eConfig = (EnemyStateConfig)cState.DEBUGConfig;

			DEBUG_currentState = eConfig;
		}
	}
}