using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class Code06 : MonoBehaviour
{

	public Transform target;
	public Vector3 offset;

	public Camera cam;

	public Image i;

	public float scaleMultiplier = 10;
	public float min = 10;
	public float max = 20;


	void Update()
	{
		float dist = Vector3.Distance(cam.transform.position, target.transform.position);

		Vector3 screenPos = cam.WorldToScreenPoint(target.position + offset);
		i.rectTransform.position = screenPos;
		//Debug.Log("target is " + screenPos.x + " pixels from the left");


		float newScale = dist * scaleMultiplier;

		newScale = Mathf.Clamp(newScale, min, max);

		i.rectTransform.localScale = Vector3.one * newScale;


	}
}