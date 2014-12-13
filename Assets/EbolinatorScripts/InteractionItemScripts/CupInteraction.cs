using UnityEngine;
using System.Collections;

public class CupInteraction : InteractionItem
{
	int allowedInteractionCount = 1;
	int usedInteractionCount = 0;
	public ParticleSystem spit;
	
	public override void Interaction()
	{
		if(usedInteractionCount >= allowedInteractionCount)
			exhausted = true;
		
		if(!exhausted)
		{
			gameMaster.Interact(2);
			spit.Play();
			usedInteractionCount++;
			StartCoroutine(ShowMessage("Spit take! +2", 2));
		}
		else
		{
			gameMaster.Interact(0);
			ExhaustedMessage();
		}
	}
}