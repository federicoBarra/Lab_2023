using System.Collections;
using UnityEngine;
using static UnityEngine.UI.Image;

namespace SomeGame.Entities
{
	public class EntityAttack : MonoBehaviour
	{
		[SerializeField] float attackDamage = 1;

		[SerializeField] float attackRange = 1;

		[SerializeField] bool attacking = false;

		[SerializeField] LayerMask enemies;

		[SerializeField] Animator animator;

		public bool CanAttack => !attacking;

		public void StartAttack(float hitTime, float releaseTime)
		{
			StartCoroutine(Attack(hitTime, releaseTime));
		}

		private Collider[] colliders = new Collider[8];

		IEnumerator Attack(float hitTime, float releaseTime)
		{
			attacking = true;
			animator.SetTrigger("Attack");
			yield return new WaitForSeconds(hitTime);

			int amount = Physics.OverlapSphereNonAlloc(transform.position, attackRange, colliders, enemies);

			for (int i = 0; i < amount; i++)
			{
				Collider col = colliders[i];
				IDamageable damageable = col.transform.GetComponent<IDamageable>();
				if (damageable != null)
					damageable.ReceiveDamage(attackDamage, transform);
			}

			yield return new WaitForSeconds(releaseTime - hitTime);
			attacking = false;
		}
	}
}