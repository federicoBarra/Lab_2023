using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code05 : MonoBehaviour
{
	public Vector3 spherePos;
	public float sphereRadius;

	public GameObject objectoConCollider;

    // Start is called before the first frame update
    void Start()
    {
	    SphereCollider sc = objectoConCollider.GetComponent<SphereCollider>();

	    sphereRadius = sc.radius;
	    spherePos = sc.transform.position;
    }

    void CastLoco()
    {
        //Physics.SphereCast()
    }
}
