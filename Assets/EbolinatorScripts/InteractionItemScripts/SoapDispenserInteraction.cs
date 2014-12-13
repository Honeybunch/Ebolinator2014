using UnityEngine;
using System.Collections;

public class SoapDispenserInteraction : InteractionItem
{
	int allowedInteractionCount = 1;
	int usedInteractionCount = 0;
	
	public override void Interaction()
	{
		rigidbody.useGravity = true;
		rigidbody.AddTorque(new Vector3(5.0f, 0.1f, 0.1f));
		rigidbody.AddForce(new Vector3(10.0f, 0.0f, -500.0f));

		if(usedInteractionCount >= allowedInteractionCount)
			exhausted = true;

		if(!exhausted)
		{
			gameMaster.Interact(3);
			usedInteractionCount++;
			StartCoroutine(ShowMessage("No soap for you! +3", 2));
		}
		else
		{
			gameMaster.Interact(0);
		}
	}
}
