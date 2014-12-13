using UnityEngine;
using System.Collections;

public class PilotInteraction : InteractionItem {
	
	int allowedInteractionCount = 0;
	int usedInteractionCount = 0;
	
	public override void Interaction()
	{
		
		if(usedInteractionCount >= allowedInteractionCount)
			exhausted = true;
		
		if(!exhausted)
		{
			gameMaster.Interact(0);
			usedInteractionCount++;
		}
		else
		{
			gameMaster.Interact(0);
			StartCoroutine(ShowMessage("Roger, over! +0", 2));
		}
	}
}
