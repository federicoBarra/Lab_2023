using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//public class Weapon
//{
//	void UpdateMio()
//	{
//		//StartCoroutine NO HAY
//	}
//}

public class Player09 : MonoBehaviour
{
	public static Player09 instance;
	void Awake()
	{
		instance  =this;
	}
}


public class Code09 : MonoBehaviour
{
	public float animDuration = 5;
	public AnimationCurve curve;

	public Gradient grandient;
	public Image imagen;


	private Coroutine c;
	private Coroutine c02;

	void Awake()
	{
		Debug.Log(Player09.instance);
	}

	// Start is called before the first frame update
	void Start()
    {
	    Doanim();
	    StartCoroutine(DispararSonidoEn(1.2f));
	    LoaderManager.OnLevelFinishedLoading += metodo;
    }

	void OnDestroy()
	{
		LoaderManager.OnLevelFinishedLoading -= metodo;
	}


	private void metodo()
	{
		Debug.Log("metodo");
	}


	public void Doanim()
    {
	    //if (c != null)
		//	return;
		    //StopCoroutine(c);

	    c = StartCoroutine(CorutinaLoca(0));
	    //c02 = StartCoroutine(CorutinaLoca02(1));

	    //StopCoroutine(c02);
		//StopAllCoroutines();
	}

    private Action OnAnimationEnded;

    IEnumerator DispararSonidoEn(float inTime)
    {
	    yield return new WaitForSeconds(inTime);
		//reproducir sonido

		OnAnimationEnded?.Invoke();
	}


	IEnumerator CorutinaLoca(int param)
    {
	    float time = 0;
	    Transform tra = transform;

	    while (time <= animDuration)
	    {
			//time / animDuration 0 => 0
			//time / animDuration 2 => 0.x 
			//time / animDuration 5 => 1

			float eval = curve.Evaluate(time / animDuration);
			tra.position = new Vector3(eval, tra.position.y, tra.position.z);
			tra.localScale = Vector3.one * eval;

			time += Time.deltaTime;

			imagen.color = grandient.Evaluate(time / animDuration);

			yield return null;
		}
	}

    IEnumerator CorutinaLoca02(int param)
    {
	    Debug.Log("Pepe");
	    yield return new WaitForSeconds(2);

	    yield return null;
	    Debug.Log("Pepe02");
	    yield return new WaitForSecondsRealtime(2);
	    Debug.Log("Pepe03");

		yield return null;
	}

}
