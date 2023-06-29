using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player07 : MonoBehaviour
{
	public float speed = 10;

	public void Move()
	{

	}

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
}
