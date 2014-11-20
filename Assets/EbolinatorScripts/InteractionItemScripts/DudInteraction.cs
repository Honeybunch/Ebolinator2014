using UnityEngine;
using System.Collections;

public class DudInteraction : InteractionItem {

	int allowedInteractionCount = 0;
	int usedInteractionCount = 0;
	
	public override void Interaction()
	{
		
		if(usedInteractionCount < allowedInteractionCount)
		{
			gameMaster.Interact(0);
			usedInteractionCount++;
		}
		else
		{
			gameMaster.Interact(0);
		}
	}
}
