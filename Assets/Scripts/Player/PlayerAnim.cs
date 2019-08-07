using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour {

	public Animator animator;

	private Rigidbody rigidbody;
	public float walkSpeed = .5f;

	void Start()
	{
		rigidbody = GetComponent<Rigidbody>();
	}
	
	public void Attack1()
	{
		animator.SetTrigger("LMB");
	}

	public void Attack2()
	{
		animator.SetTrigger("RMB");
	}

	public void Walk()
	{
		animator.SetBool("IsRunning", false);
		animator.SetBool("IsWalking", true);
		animator.SetFloat("moveSpeed", rigidbody.velocity.magnitude * walkSpeed);
	}
	public void Idle()
	{
		animator.SetBool("IsWalking", false);
	}

	public void Run()
	{
		animator.SetBool("IsRunning", true);
	}

	public void Jump()
	{
		animator.SetTrigger("IsJumping");
	}

}
