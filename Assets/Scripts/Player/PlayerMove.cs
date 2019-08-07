using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMove : MonoBehaviour {

	public bool canMove = true;

	public float velocity = 0;

	public float speed = 1;
	private float baseSpeed;
	public float jumpSpeed = 1;

	public bool isJumping = false;
	public bool isGrounded = true;

	private PlayerAnim playerAnim;
	private Rigidbody rigidbody;

	void Start ()
	{
		baseSpeed = speed;
		playerAnim = GetComponent<PlayerAnim>();
		rigidbody = GetComponent<Rigidbody>();
		StartCoroutine(Move());
	}

	IEnumerator Move()
	{
		while(canMove)
		{
			//calculate new transform.position
			Vector3 newPos = Vector3.Normalize(new Vector3(InputManager.instance.GetHorizontal(), 0, InputManager.instance.GetVertical())) * speed;
            //print (newPos);

			//rotate character
			if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
			{
				transform.rotation = Quaternion.LookRotation(newPos);
			}
			else
			{
				playerAnim.Idle();
			}

			//move to new position
			rigidbody.AddForce(newPos);

			if(rigidbody.velocity.magnitude > 0.1)
			{
				playerAnim.Walk();
			}
			if(speed > baseSpeed)
			{
				playerAnim.Run();
			}

            //Resets velocity to 0 each frame so character doesn't slide around
            rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, 0);

			yield return null;
		}
	}

	public void ChangeToSprintSpeed()
	{
		speed = baseSpeed * 2;
	}

	public void ChangeToRegularSpeed()
	{
		speed = baseSpeed;
	}

	public void Jump()
	{
		if(isGrounded)
		{
			rigidbody.AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);
			isGrounded = false;
			playerAnim.Jump();
		}
	}

	void OnCollisionStay(Collision other)
	{
		isGrounded = true;
		isJumping = false;
	}

}