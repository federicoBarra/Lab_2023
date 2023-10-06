using System;
using UnityEngine;

namespace SomeGame.Entities
{
	public interface IDamageable
	{
		void ReceiveDamage(float damage, Transform damageOwner);
		event Action<float, Transform> OnReceiveDamage;
	}


	public class EntityHealth : MonoBehaviour, IDamageable
	{
		[SerializeField] private float health = 100;
		[SerializeField] private float maxHealth = 100;

		public float Health => health;
		public float MaxHealth => maxHealth;
		public event Action<float, Transform> OnReceiveDamage;

		void Awake()
		{
			health = maxHealth;
		}

		public void ReceiveDamage(float damage, Transform damageOwner)
		{
			health -= damage;
			OnReceiveDamage?.Invoke(damage, damageOwner);
		}
	}
}