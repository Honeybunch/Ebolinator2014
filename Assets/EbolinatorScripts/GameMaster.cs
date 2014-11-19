using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

	public GUISkin ebolaskin;

	int interactionCount; //How many interactions has the player made
	int infectedCount; //How many people are potentially infected
	int interactionMax; //How many interactions are we allowed this level
	int infectedQuota;	//How many people do we need to put at risk this level

	public enum GameState{
		game,
		win,
		lose
	}

	GameState state = GameState.game;
	void Start(){
		SetUpLevel(6, 10);
	}

	// Use this for initialization
	void OnGUI(){
		//Just to test
		switch(state){
		case GameState.game:
			GUI.skin = ebolaskin;
			GUI.Label( new Rect(50,50,177,75), "Infected: " + infectedCount + "/" + infectedQuota);
			GUI.Label( new Rect(50,150,177,75), "Interactions: " + interactionCount + "/" + interactionMax);
			UpdateGame();
			break;
		case GameState.win:
			GUI.Label(new Rect(Screen.width/2, Screen.height/2, 500, 100), "Level Completed");
			break;
		case GameState.lose:
			GUI.Label(new Rect(Screen.width/2, Screen.height/2, 500, 100), "Failure");
			break;
		}

	}
	/*Set up level
		max - The maximum amount of interactions this level
		quota - The amount of people to put at risk this level
	*/
	public void SetUpLevel(int max, int quota){
		interactionCount = 0;
		infectedCount = 0;
		interactionMax = max;
		infectedQuota = quota;
	}
	/*Interact
	 	points - how many people does this infect
	*/
	public void Interact(int points)
	{
		interactionCount += 1;
		infectedCount += points;
	}
	/*UpdateGame
		check if level completed or lost
	*/
	void UpdateGame(){
		if(infectedCount >= infectedQuota){
			infectedCount = infectedQuota;
			state = GameState.win;
		}

		if(interactionCount >= interactionMax){
			interactionCount = interactionMax;
			state = GameState.lose;
		}
	}
}
