using UnityEngine;
using System.Collections;

public class ToiletInteraction : InteractionItem
{
	int allowedInteractionCount = 1;
	int usedInteractionCount = 0;
	
	public override void Interaction()
	{
		
		if(usedInteractionCount < allowedInteractionCount)
		{
			gameMaster.Interact(2);
			usedInteractionCount++;
		}
		else
		{
			gameMaster.Interact(0);
		}
	}
}