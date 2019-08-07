using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoboRyanTron.Unite2017.Events;

public class GameEventRaise : MonoBehaviour {

	public GameEvent gameEvent;
	public void Raise()
	{
		gameEvent.Raise();
	}
}
