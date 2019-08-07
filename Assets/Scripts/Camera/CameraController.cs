using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject target;
	public Vector3 offset;

	public bool canFollow = true;

	private void Start()
	{
		offset = target.transform.position - transform.position;
		StartCoroutine(Follow());
	}

	IEnumerator Follow()
	{	
		while(canFollow)
		{
			transform.position = new Vector3(target.transform.position.x - offset.x, target.transform.position.y - offset.y, target.transform.position.z - offset.z);
			yield return null;
		}
	}

}
