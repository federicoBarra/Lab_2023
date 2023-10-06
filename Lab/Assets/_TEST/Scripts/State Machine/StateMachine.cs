using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utils.NewStateMachine
{
	public class StateMachine
	{
		private MachineState currentState;
		private Dictionary<StateConfig, MachineState> newStates;

		public StateMachine()
		{
			newStates = new Dictionary<StateConfig, MachineState>();
		}

		public void AddState(StateConfig state)
		{
			MachineState newState = (MachineState)Activator.CreateInstance(state.StateType, this, state);
			newStates.Add(state, newState);
		}

		public void Update()
		{
			currentState?.Update();
		}

		public void SetState(StateConfig config)
		{
			currentState?.Exit();

			MachineState nextState = null;
			if (newStates.TryGetValue(config, out nextState))
			{
				currentState = nextState;
				currentState.Enter();
			}
			else
			{
				Debug.LogError(config.StateType + " : is not registered.");
			}
		}

		public MachineState DEBUGCurrentState => currentState;
	}

	public abstract class MachineState
	{
		protected StateConfig config;
		protected StateMachine machine;

		protected MachineState(StateMachine _machine, StateConfig _config)
		{
			machine = _machine;
			config = _config;
		}

		public abstract void Enter();
		public abstract void Update();
		public abstract void Exit();

		public StateConfig DEBUGConfig => config;
	}
}