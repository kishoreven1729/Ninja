#region References
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
#endregion

public class State
{
	#region Private Variables
	private object		stateTransitionData;
	#endregion

	#region Public Variables
	public string 		stateName;
	public Func<int>	stateUpdateFunction;
	public string		animationTriggerString;
	#endregion

	#region Constructor
	/// <summary>
	/// Initializes a new instance of the <see cref="CharacterState"/> class. Each state is a node in the <see cref="CharacterStateManager"/>
	/// </summary>
	/// <param name="name">Name of the State for use in dictionary.</param>
	/// <param name="udpateFunction">Udpate function that will called in character update loop when the state is active.</param>
	/// <param name="animationTriggerValue">Animation trigger string if the state changes needs an animation to be played. Pass null if there isn't any.</param>
	public State(string name, Func<int> udpateFunction, string animationTriggerValue)
	{	
		stateName = name;
		stateUpdateFunction = udpateFunction;
		animationTriggerString = animationTriggerValue;
	}
	#endregion
	
	#region Methods
	public void PushTransitionData(object transitionData)
	{
		stateTransitionData = transitionData;
	}

	public object PullTransitionData()
	{
		if(stateTransitionData != null)
		{
			object returnData = stateTransitionData;
			stateTransitionData = null;

			return returnData;
		}

		return null;
	}
	#endregion
}
