using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

	public GUISkin ebolaskin;

	int interactionCount; //How many interactions has the player made
	int infectedCount; //How many people are potentially infected
	int interactionMax; //How many interactions are we allowed this level
	int infectedQuota;	//How many people do we need to put at risk this level

	// Use this for initialization
	void OnGUI(){
		GUI.skin = ebolaskin;
		GUI.Label( new Rect(50,50,177,75), "Infected: " + infectedCount + "/" + infectedQuota);
		GUI.Label( new Rect(50,150,177,75), "Interactions: " + interactionCount + "/" + interactionMax);
	}
	/*Set up level
		max - The maximum amount of interactions this level
		quota - The amount of people to put at risk this level
	*/
	void SetUpLevel(int max, int quota){
		interactionCount = 0;
		infectedCount = 0;
		interactionMax = max;
		infectedQuota = quota;
	}

}
