using UnityEngine;
using System.Collections;

public class ToiletInteraction : InteractionItem
{
	int allowedInteractionCount = 1;
	int usedInteractionCount = 0;
	public ParticleSystem urine;

	public override void Interaction()
	{
		if(usedInteractionCount >= allowedInteractionCount)
			exhausted = true;
		
		if(!exhausted)
		{
			gameMaster.Interact(2);
			urine.Play();
			usedInteractionCount++;
		}
		else
		{
			gameMaster.Interact(0);
		}
	}
}