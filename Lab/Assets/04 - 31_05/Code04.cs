using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Tito
{
	private int a;
	private int b;
}

public class Code04 : MonoBehaviour
{
	private byte pepe; //8
	private int max;

	private int gameSaveData; //bit 1: tiene tal llave, bit 2: completo el tutorial

	public LayerMask mask;

	void Start()
	{
		Tito a = new Tito();

		int number = 1;
		string binary = Convert.ToString(number, 2).PadLeft(32, '0');
		Debug.Log(binary);

		Debug.Log(int.MaxValue);

		number = int.MaxValue;
		binary = Convert.ToString(number, 2).PadLeft(32, '0');
		Debug.Log(binary);

		uint number02 = UInt32.MaxValue;
		binary = Convert.ToString(number02, 2).PadLeft(32, '0');
		Debug.Log(binary);

		int number03 = mask.value;
		string binary03 = Convert.ToString(number03, 2).PadLeft(32, '0');
		Debug.Log("Mask:" + binary03);

		Debug.Log("el layer: " + gameObject.layer + " Esta contenido en LayerMask? " + Contains(mask, gameObject.layer) );

		int n01 = 1;
		string b = Convert.ToString(n01, 2).PadLeft(32, '0');
		Debug.Log("N01:" + b);

		int n02 = n01<<1;
		b = Convert.ToString(n02, 2).PadLeft(32, '0');
		Debug.Log("N02:" + b);
		
	}

	public LayerMask enemiesMask;
	public LayerMask playersMask;

	void Update()
	{
		RaycastHit hit;
		if (Physics.SphereCast(Vector3.zero, 10, transform.forward, out hit, 10, mask))
		{
			Debug.Log(hit.transform.name);
			if (Contains(enemiesMask, hit.transform.gameObject.layer))
			{
				Debug.Log("Choque un enemy");
			}
			if (Contains(playersMask, hit.transform.gameObject.layer))
			{
				Debug.Log("Choque un Player");
			}
		}
	}

	//void OnTreigger


	bool Contains(LayerMask lm, int layer)
	{
		bool ret = false;

		ret = lm == (lm | (1 << layer));

		//layer es 6
		//(1 << layer):			0000...000010000000
		//lm:					0000...000110000000

		// (lm | (1 << layer))	0000...000110000000
		//lm 0000...000110000000 == 0000...000110000000

		//0100
		//0010
		// |
		//0110

		//0100
		//0010
		// &
		//0000

		return ret;
	}


	private int damage = 100; //127, no va ocupar mas de 5 bits

	private Vector3 direction;

	//server
	void EnviarAlserver(Vector3 c, int d)
	{
		



	}

	//cliente
	void HiceAlgo()
	{
		int data; //32 bit, 5 de damage, 7bits para x,y,z

		//data = damage << 28;
		//data |= direction.x << 21;
		//data |= direction.y << 14;

		//mensaje al server ("EnviarAlserver", direction, damage)
	}
}


public interface IHittable
{
	void ReceiveDamage(int damage);
	bool CanBeHitted();
}

public class DamageInfo
{
	public int physicalDamage;
	public int magicDamage;
	public int cutThrough;

	public enum DamageType
	{
		Fire,
		Ice
	}

	public DamageType damageType;

}
