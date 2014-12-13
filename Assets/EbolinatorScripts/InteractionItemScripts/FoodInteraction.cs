using UnityEngine;
using System.Collections;

public class FoodInteraction : InteractionItem
{
	int allowedInteractionCount = 6;
	int usedInteractionCount = 0;
	public ParticleSystem vomit;
	
	public override void Interaction()
	{
		if(usedInteractionCount >= allowedInteractionCount)
			exhausted = true;
		
		if(!exhausted)
		{
			if(usedInteractionCount < 5){
				gameMaster.Interact(0);
				StartCoroutine(ShowMessage("Whats the deal with this? +0", 2));
			}
			else{
				gameMaster.Interact(10);
				vomit.Play();
				StartCoroutine(ShowMessage("THAR SHE BLOWS! +10", 2));
			}
			usedInteractionCount++;
		}
		else
		{
			gameMaster.Interact(0);
			ExhaustedMessage();
		}
	}
}