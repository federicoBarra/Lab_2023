using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public interface IHitable
{
	void ReceiveDamage(int damage);
}

public class EnemyTest : MonoBehaviour, IHitable
{
	public float attackRadius;
	public float forwardDistance;
	public float hitTime =0.5f;

	public GameObject hitSimulation;
	public float hitSimulationTime = 0.2f;
	void Start()
    {
		hitSimulation.SetActive(false);
	}

    void Update()
    {
	    if (Input.GetKeyDown(KeyCode.Space))
	    {
		    StartCoroutine(HitSimulation());
	    }
    }

    IEnumerator HitSimulation()
    {
	    justHitted.Clear();

		float t = 0;

	    while (t < hitTime)
	    {
		    t += Time.deltaTime;
		    yield return null;
	    }
		//spheracast aca

		AttackNow();
		hitSimulation.SetActive(true);
	    hitSimulation.transform.position = transform.position + transform.right * forwardDistance;

		t = 0;
	    while (t < hitSimulationTime)
	    {
		    t += Time.deltaTime;
		    AttackNow();
			yield return null;
	    }
	    hitSimulation.SetActive(false);


		yield return null;

		justHitted.Clear();

	}

    public List<IHitable> justHitted;
	public LayerMask enemiesMask;
	
	void AttackNow()
    {
	    RaycastHit[] hits = null;

	    hits = Physics.SphereCastAll(Vector3.zero, 5, Vector3.right, 10, enemiesMask);

		for (int i = 0; i < hits.Length; i++)
	    {
		    RaycastHit hit = hits[i];

			IHitable aQuienLepegue = hit.transform.gameObject.GetComponent<IHitable>();

			if (justHitted.Contains(aQuienLepegue))
				continue;

			justHitted.Add(aQuienLepegue);

			//Vector3.Angle()
			//Angulo entre (hit.point, myRight) < 90 
			//	entonces le pegue
			// 90 es el angulo de ataque

			aQuienLepegue.ReceiveDamage(10);
	    }
    }

	//https://docs.unity3d.com/ScriptReference/Physics.SphereCastNonAlloc.html
	RaycastHit[] hitsNonAlloc = new RaycastHit[256];
	void AttackNow02()
	{
		int hitAmount = Physics.SphereCastNonAlloc(Vector3.zero, 5, Vector3.right, hitsNonAlloc, enemiesMask);

		for (int i = 0; i < hitAmount; i++)
		{
			RaycastHit hit = hitsNonAlloc[i];


		}
	}

	public void ReceiveDamage(int damage)
	{
		//resto damage a mi vida
	}

}


public class ComboAttack
{
	public ComboAttack prevAttack;
	public KeyCode[] keysNeeded;

	public float hitTime = 0.5f;
	public float nextComboIn = 1;
}


public class AttackSytem
{
	public ComboAttack[] attacks;
	public int attackIndex;
	public ComboAttack currentAttack;

	public float t;

	void Update()
	{
		t -= Time.deltaTime;
		//if press -> Attack()
	}

	void Attack()
	{
		if (t < 0)
		{
			attackIndex = 0;
		}
		else
		{
			attackIndex++;
		}

		currentAttack = attacks[attackIndex];

		t = currentAttack.nextComboIn;

	}

}