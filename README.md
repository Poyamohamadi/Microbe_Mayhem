![[1.PNG]]
```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {  
    
    }

    // Update is called once per frame
    void Update()
    {

    }
}
```

---
![[2.PNG]]
```csharp
void Start()
	{
		Debug.Log("Hello, World!"); 
    }
```

> `Hello, World!`

---
![[3.PNG]]
```csharp
void Start()
	{
	
    }
 void Update()
	{
		Debug.Log("Hello, World!");
	}
```
>`Hello, World!`
> `Hello, World!`
> `Hello, World!`
> `...`
> `...`   

---
![[4.PNG]]
```csharp
void Update()
	{
		Vector3 movement = new Vector3(
			Input.GetAxisRaw("Horizontal"),
			Input.GetAxisRaw("Vertical"),
			0 );
	}
```
---
![[5.PNG]]
```csharp
void Update()
	{
		Vector3 movement = new Vector3(
			Input.GetAxisRaw("Horizontal"),
			Input.GetAxisRaw("Vertical"),
			0 );
		movement = movement.normalized;
	}
```

---
![[6.PNG]]
```csharp
public class Player : MonoBehaviour
{
    public int movementSpeed = 5;

    void Start(){ }
    void Update(){ }
}
```
---
![[7.PNG]]
```csharp
Vector3 newMove = (movement * Time.deltaTime * movementSpeed)
			+ transform.position;
```

---
![[8.PNG]]
```csharp
transform.position = new Vector3(
			newMove.x,
			newMove.y, 
			transform.position.z);
```
---
![[9.PNG]]
```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    void Start()
	{
	    
    }
	public int movementSpeed = 5;
	
    void Update()
	{
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
}
```
---
![[10.PNG]]
```csharp
public class Player : MonoBehaviour
{
    void Start(){ ... } 
    void Update(){ ... }
	
	// Sent when another object enters a trigger collider attached to this object (2D physics only).
	protected void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log(other);
	}
}
```
---
![[11.PNG]]
```csharp
protected void OnTriggerEnter2D(Collider2D other)
	{
		other.GetComponent<SpriteRenderer>().color = Color.red;
	}
```
---

![[12.PNG]]

```csharp
public int speed = 3;

public Vector3 distance = new Vector3(0, -1, 0);

    void Update()
    {
	    transform.position = ( distance * Time.deltaTime * speed ) + transform.position;
    }
	// Sent when an incoming collider makes contact with this object's collider (2D physics only).
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
```

---![[13.PNG]]
```csharp
public int speed = 3;
	
    void Update()
	{	
		transform.position = 
(( speed * Time.deltaTime ) *
( new Vector3(Random.Range(-1f,1f),Random.Range(-1f,1f),0f).normalized ) + transform.position);
    }
```
---
![[14.PNG]]
```csharp
public int movementSpeed = 3;
    // Update is called once per frame
    void Update()
	{	
		if (!isReady && Time.time >= readyTime)
		    {
			isReady = true;
			readyTime = 0f;
			movementSpeed = 5;
			}
			  . 
			  .
			  .
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
```
