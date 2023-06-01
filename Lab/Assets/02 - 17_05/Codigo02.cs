using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif
/// <summary>
/// 
/// </summary>
public class Codigo02 : MonoBehaviour
{
	public class LevelData
	{
		public int width;
		public int length;
		public int enemyCount;
	}

	[Serializable]
	public class Alumno
	{
		public string name;
		[SerializeField]
		int age = 30;
		public int vida = 100;
	}
	/// <summary>
	/// 
	/// </summary>
	public Alumno alumno;

    /// <summary>
	/// Funcion de start
	/// </summary>
    void Start()
    {
	    Alumno a = new Alumno()
	    {
		    name = "Pepe",
	    };

	    Debug.Log("Aluimno:" + a.name);

	    string json = JsonUtility.ToJson(a);

		Debug.Log(json);

		PlayerPrefs.SetString("DataAlumno", json);

		string data02 = PlayerPrefs.GetString("DataAlumno");

#if UNITY_EDITOR
		Alumno b = JsonUtility.FromJson<Alumno>(data02);
#endif

#if Android_6354687
		Alumno b = JsonUtility.FromJson<Alumno>(data02);
#endif

	    Type t = a.GetType();

		Debug.Log(t);
		//Debug.Log(typeof(int));

	}

    public void RestaVida()
    {
	    alumno.vida -= 10;
    }

	// Update is called once per frame
	void Update()
    {
        
    }
}
#if UNITY_EDITOR
[CustomEditor(typeof(Codigo02))]
public class Codigo02Editor : Editor
{
	private Codigo02 c;

	void OnEnable()
	{
		c = target as Codigo02;
		//c = (Codigo02) target;
		//if (target is Codigo02)
		//{ }
		//c.GetComponent<Rigidbody>();
	}

	public override void OnInspectorGUI()
	{
		//DrawDefaultInspector();
		GUILayout.Label("Chabon: " + c.alumno.name);
		if (GUILayout.Button("Restá Vida"))
		{
			c.RestaVida();
		}
	}
}
#endif