using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
	{
	    
    }
	public int movementSpeed = 3;
    // Update is called once per frame
    void Update()
	{	
		if (!isReady && Time.time >= readyTime){
			isReady = true;
			readyTime = 0f;
			movementSpeed = 5;}
			
		Vector3 movement = new Vector3(
			Input.GetAxisRaw("Horizontal"),
			Input.GetAxisRaw("Vertical"),
			0 );
		movement = movement.normalized;
		
		Vector3 newMove = 
			transform.position + (movement * movementSpeed * Time.deltaTime);
			
		transform.position = new Vector3(newMove.x,
			newMove.y, transform.position.z);
	}
	
	// Sent when another object enters a trigger collider attached to this object (2D physics only).
	protected void OnTriggerEnter2D(Collider2D other)
	{
		other.GetComponent<SpriteRenderer>().color = Color.red;
	
	}
	
	public float duration = 1;
	private float readyTime ;
	public bool isReady = true;
	protected void OnCollisionEnter2D(Collision2D collisionInfo)
	{	
		if (isReady){
			isReady = false;
			readyTime = Time.time + duration;
			movementSpeed = 1;
		}
	}
		
}
