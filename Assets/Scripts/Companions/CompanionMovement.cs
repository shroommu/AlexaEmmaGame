using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CompanionMovement : MonoBehaviour {

	private NavMeshAgent navMeshAgent;
	public GameObject player;
    public float jumpHeight;

	public bool canFollow = true;

	void Start()
	{
		navMeshAgent = GetComponent<NavMeshAgent>();
		StartCoroutine(FollowPlayer());
	}

	IEnumerator FollowPlayer()
	{
		while(canFollow)
		{
			navMeshAgent.destination = player.transform.position;
			yield return null;
		}
	}

	public void Jump()
	{
		transform.GetChild(0).GetComponent<Rigidbody>().AddForce(0, jumpHeight, 0);
	}

}
