using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EAMono : MonoBehaviour
{
	protected bool isPaused;
	void MyUpdate()
	{

	}
}

public class Codigo : MonoBehaviour
{
	private Auto ferrari;

	public List<Auto> autos;

	private Rigidbody rig;

	private int layer; //00001000 64

	public LayerMask pepe; //00011000

	public LayerMask layerQuePuedoInteractuar; //01000000

	public event Action eventoLoco;

	private Dictionary<string, string> realAcademia;

	private Dictionary<Auto, int> puertasPorAuto;


	void Pepe()
	{
		realAcademia = new Dictionary<string, string>();

		realAcademia.Add("casa", "cosa con paredes y puerta");
		realAcademia.Add("auto", "cosa con ruedas");


		Debug.Log(realAcademia["casa"]);

		puertasPorAuto = new Dictionary<Auto, int>();

		ferrari = new Auto();
		ferrari.cantidadRuedas = 5;

		Auto ferrari02 = new Auto();
		ferrari02.cantidadRuedas = 6;
		Auto ferrari03 = new Auto();

		puertasPorAuto.Add(ferrari, 4);
		puertasPorAuto.Add(ferrari02, 3);

		Debug.Log(puertasPorAuto[ferrari]);

		Dictionary<int, List<Auto>> autosConCantidadDePuertas;
		autosConCantidadDePuertas = new Dictionary<int, List<Auto>>();

		autosConCantidadDePuertas.Add(4, new List<Auto>());

		for (int i = 0; i < autosConCantidadDePuertas[4].Count; i++)
		{
			Auto a = autosConCantidadDePuertas[4][i];
			Debug.Log(a);
		}

		autosConCantidadDePuertas.Add(3, new List<Auto>());

		List<Auto> listaAuxiliar = autosConCantidadDePuertas[4];

		listaAuxiliar.Add(ferrari);
		listaAuxiliar.Add(ferrari03);
		autosConCantidadDePuertas[3].Add(ferrari02);


	}

	void Tito()
	{
		ferrari = new Auto();
		ferrari.cantidadRuedas = 5;

		Auto ferrari02 = new Auto();
		ferrari02.cantidadRuedas = 6;

		ferrari02 = ferrari;

		int pepe02 = pepe.value;
		int pepe03 = layerQuePuedoInteractuar.value;
		int cosa = pepe02 & pepe03;


		if (cosa == (int)pepe.value)
		{

		}

		Debug.Log(ferrari02.cantidadRuedas);
		rig = GetComponent<Rigidbody>();

		//Time.timeScale = 0;
	}

	void Update()
	{
		//transform.position += Vector3.right * 5 * Time.deltaTime;
	}

	void AsignarVelocidad()
	{
		rig.AddForce(Vector3.right, ForceMode.VelocityChange);
	}

	Persona DamePersonaConDNI(int dni)
	{
		for (var i = 0; i < personas.Count; i++)
		{
			var p = personas[i];
			if (p.dni == dni)
				; //return p
		}

		if (dniPersona.ContainsKey(dni))
			return dniPersona[dni];

		return null;
	}

	private List<Persona> personas;
	private Dictionary<int, Persona> dniPersona;


	/// <summary>
	/// 
	/// </summary>
	/// <param name="param">Description </param>
	/// <returns></returns>
	public int PEpe02(int param)
	{
		return 0;
	}

	private string data = "100, 400";

	void InterpretarData()
	{
		string[] datas = data.Split(",");
		// max = data[0] 
		// mana = data[1]
	}

}

public class Persona
{
	public int dni;
	public string name;
}



public class Auto
{
	public int cantidadRuedas;
	public int cantidadPuertas;
}

