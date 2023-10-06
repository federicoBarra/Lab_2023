using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SomeGame.Entities
{
	public class EntityTargetProvider : MonoBehaviour
	{
		[SerializeField] private Transform target;
		public Transform Target { get; set; }
		public bool HasTarget => target != null;
	}
}