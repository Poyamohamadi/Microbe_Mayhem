using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiggle : MonoBehaviour
{
	public int speed = 3;
	
    void Update()
	{	
		transform.position = 
		(( speed * Time.deltaTime ) *
		( new Vector3(Random.Range(-1f,1f),Random.Range(-1f,1f),0f).normalized ) + 
			transform.position);    
    }
}

