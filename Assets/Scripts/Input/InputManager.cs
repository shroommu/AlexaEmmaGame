using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using RoboRyanTron.Unite2017.Events;

public class InputManager : MonoBehaviour {

	public static InputManager instance;

	public SO_InputType currentInputType;
	public SO_InputType[] inputTypes;

	private float verticalSpeed = 0;
	private float horizontalSpeed = 0;

	private bool canGetInput = true;

	public GameEvent lmbEvent;
	public GameEvent rmbEvent;
	public GameEvent leftShiftEvent;
	public GameEvent leftShiftUpEvent;
	public GameEvent spaceDownEvent;

	void Awake()
	{
		if(instance == null)
		{
			instance = this;
		}
		else if(instance != this)
		{
			Destroy(this);
		}
	}
	
	void Start()
	{
		StartCoroutine(GetInput());
	}

	IEnumerator GetInput()
	{
		while(canGetInput)
		{
			verticalSpeed = Input.GetAxis("Vertical");
			horizontalSpeed = Input.GetAxis("Horizontal");

			if(Input.GetMouseButtonDown(0))
			{
				lmbEvent.Raise();
			}

			if(Input.GetMouseButtonDown(1))
			{
				rmbEvent.Raise();
			}

			if(Input.GetKey(KeyCode.LeftShift))
			{
				leftShiftEvent.Raise();
			}
			if(Input.GetKeyUp(KeyCode.LeftShift))
			{
				leftShiftUpEvent.Raise();
			}

			if(Input.GetKeyDown(KeyCode.Space))
			{
				spaceDownEvent.Raise();
			}

			yield return null;
		}
	}

	public float GetVertical()
	{
		return verticalSpeed;
	}

	public float GetHorizontal()
	{
		return horizontalSpeed;
	}
}
