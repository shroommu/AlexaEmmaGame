using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class BasicAIMovement : MonoBehaviour {

	public NavMeshAgent navMeshAgent;

	public bool canMove;

	public List<GameObject> targets;

	void Start()
	{
		navMeshAgent = GetComponent<NavMeshAgent>();
	}

	public void SetDestination(Transform dest)
	{
		StartCoroutine(Move(dest));
	}

	IEnumerator Move(Transform dest)
	{
		while(Vector3.Distance(transform.position, navMeshAgent.destination) <= navMeshAgent.stoppingDistance)
		{
			navMeshAgent.SetDestination(dest.position);
			yield return null;
		}


		
	}

	public void StopAgent()
	{
		navMeshAgent.isStopped = true;
	}

	public void StartAgent()
	{
		navMeshAgent.isStopped = false;
	}


}
