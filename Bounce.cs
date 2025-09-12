using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{

	public int speed = 3;
	
	public Vector3 distance = new Vector3(0, -1, 0);

    void Update()
    {
	    transform.position = ( distance * Time.deltaTime * speed ) + transform.position;
    }

	protected void OnCollisionEnter2D(Collision2D collisionInfo)
	{
		if (distance.y < 0)
		{
			distance = new Vector3(0, 1, 0);
		}
		else
		{
			distance = new Vector3(0, -1, 0);
		}
	}
    
    
}

