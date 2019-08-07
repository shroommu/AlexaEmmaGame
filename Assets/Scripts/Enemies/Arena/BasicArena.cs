using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicArena : MonoBehaviour {

	public List<GameObject> walls;
	public List<GameObject> enemies;

	void OnTriggerEnter(Collider other)
	{
		if(other.GetComponent<PlayerData>() != null)
		{
			foreach (GameObject wall in walls)
			{
				wall.SetActive(true);
			}

			foreach (GameObject enemy in enemies)
			{
				enemy.GetComponent<BasicAIMovement>().targets.Add(other.gameObject);
				enemy.GetComponent<BasicAIMovement>().targets.Add(other.GetComponent<PlayerData>().companion1);
				enemy.GetComponent<BasicAIMovement>().targets.Add(other.GetComponent<PlayerData>().companion2);
			}

			GetComponent<Collider>().enabled = false;
		}
	}


}
