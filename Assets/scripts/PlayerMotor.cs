using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

	private CharacterController controller;
	private float speed = 4.0f;
	private Vector3 moveVector;
	private float verticalVelocity = 0.0f;
	private float gravity = 12.0f;
	private float animationDuration = 3.0f;
	private bool isDead = false;
	private float startTime;

	void Start () 
	{
		controller = GetComponent<CharacterController> ();
		startTime = Time.time;
	}
	

	void Update () 
	{

		if (isDead) 
		{
			return;
		}
		
		if (Time.time - startTime < animationDuration) 
		{
			controller.Move (Vector3.forward * speed * Time.deltaTime);
			return;
		}

		moveVector = Vector3.zero;

		if (controller.isGrounded)
		{
			verticalVelocity = -0.5f;
		} 
		else
		{
			verticalVelocity -= gravity * Time.deltaTime;
		}

	moveVector.x = Input.GetAxisRaw ("Horizontal") * speed;		
	moveVector.y = verticalVelocity;
	moveVector.z = speed;		
		controller.Move (moveVector * speed * Time.deltaTime);
	}

	public void SetSpeed(float modifier)
	{
		speed = 3.0f + modifier;
	}

	//Collider

	private void OnControllerColliderHit (ControllerColliderHit hit)

	{
		if (hit.gameObject.tag == "Enemy") 
		{
			Death ();
		}
			
	}

	private void Death()
	{
		isDead = true;
		GetComponent<Score> ().OnDeath ();
	}
}

