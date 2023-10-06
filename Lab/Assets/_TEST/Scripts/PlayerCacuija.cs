using System;
using System.Collections;
using SomeGame.Entities;
using UnityEngine;

public class PlayerCacuija : MonoBehaviour, IDamageable //XXX muchas cosas de este script son bastante cacuija
{
	public EntityHealth enemy;

	public float speed = 5;
	float addedSpeed = 5;
	public float maxAddedSpeed = 5;
	float angle = 0;
	public float moveRadius = 3;

	public AnimationCurve curve;
	public Gradient colorGrad;
	public float duration = 1;

	private Material mat;

	public event Action<float, Transform> OnReceiveDamage;

	void Start()
	{
		mat = GetComponent<Renderer>().material;
	}

	// Update is called once per frame
	void Update()
	{
		addedSpeed -= Time.deltaTime;
		addedSpeed = Mathf.Clamp(addedSpeed, 0, maxAddedSpeed);

		angle += Time.deltaTime * (speed + addedSpeed);

		Vector2 circle = new Vector2(moveRadius * MathF.Cos(angle), moveRadius * MathF.Sin(angle));
		
		// circle parametric equation
		//x = r cos a
		//y = r sin a

		transform.position = new Vector3(circle.x, 0.5f, circle.y);

		if (Input.GetKeyDown(KeyCode.Space))
			enemy.ReceiveDamage(15, transform);
	}

	public void ReceiveDamage(float damage, Transform damageOwner)
    {
	    OnReceiveDamage?.Invoke(damage, damageOwner);
	    StartCoroutine(ReceiveDamageAnimation());
	}

    IEnumerator ReceiveDamageAnimation()
    {
	    float t = 0;
	    addedSpeed = maxAddedSpeed;
		while (t < duration)
	    {
		    t += Time.deltaTime;
		    float val = curve.Evaluate(t / duration); // 0 - 1
		    mat.color = colorGrad.Evaluate(t / duration);
		    transform.localScale = Vector3.one * val;
		    yield return null;
	    }
    }
}
