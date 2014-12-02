using UnityEngine;
using System.Collections;

public class TestCubeInteraction : InteractionItem
{
	int allowedInteractionCount = 3;
	int usedInteractionCount = 0;

	public override void Interaction()
	{
		rigidbody.AddForce(new Vector3(100, 0, 100));

		if(usedInteractionCount >= allowedInteractionCount)
			exhausted = true;

		if(!exhausted)
		{
			gameMaster.Interact(1);
			usedInteractionCount++;
		}
		else
		{
			gameMaster.Interact(0);
		}
	}
}
