using UnityEngine;
using System.Collections;

public class SoapDispenserInteraction : InteractionItem
{
	int allowedInteractionCount = 1;
	int usedInteractionCount = 0;
	
	public override void Interaction()
	{
		
		if(usedInteractionCount < allowedInteractionCount)
		{
			gameMaster.Interact(3);
			usedInteractionCount++;
		}
		else
		{
			gameMaster.Interact(0);
		}
	}
}
