using System;
using UnityEngine;

namespace Utils.NewStateMachine
{
	public class StateConfig : ScriptableObject
	{
		protected Type stateType;
		public virtual Type StateType { get; }
	}
}