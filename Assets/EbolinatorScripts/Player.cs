using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	Camera playerCamera;

	string interactionText;
	bool displayInteractionText;

	float raycastTimer;
	float raycastTimerMax;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () 
	{
		interactionText = "Press E or Left Mouse Button To Interact";
		displayInteractionText = false;

		raycastTimer = 0;
		raycastTimerMax = .1f;

		playerCamera = Camera.main;
	}
	
	/// <summary>
	/// Update this instance and fire raycasts to determine how we interact
	/// with the environment
	/// </summary>
	void Update ()
	{
		//Do a raycast every few milliseconds to see if we're in front of something
		raycastTimer += Time.deltaTime;

		if(raycastTimer > raycastTimerMax)
		{
			raycastTimer = 0;

			//Fire a raycast
			RaycastHit hit;
			if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, 5))
			{
				Debug.Log("Raycast - Automatic!");
				
				GameObject hitObject = hit.transform.gameObject;
				InteractionItem interaction = null;
				
				interaction = hitObject.GetComponent<InteractionItem>();
				
				if(interaction != null)
					displayInteractionText = true;
			}
			else
			{
				displayInteractionText = false;
			}
		}


		if(Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
		{
			//Raycast out in the forward direction
			//If we hit an object with an interactable object script, interact with it
			RaycastHit hit;
			if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, 5))
			{
				Debug.Log("Raycast");

				GameObject hitObject = hit.transform.gameObject;
				InteractionItem interaction = null;

				interaction = hitObject.GetComponent<InteractionItem>();

				if(interaction != null)
				{
					Debug.Log("Interaction!");
				}
			}

		}

	}

	/// <summary>
	/// Used to display whether or not the player can interact with an object
	/// </summary>
	void OnGUI()
	{
		if(displayInteractionText)
		{
			Vector2 textSize = GUI.skin.GetStyle("TextArea").CalcSize(new GUIContent(interactionText));
			float textWidth = textSize.x;
			float textHeight = textSize.y;

			float halfTextWidth = textWidth / 2;

			float halfScreenWidth = Screen.width / 2;
			float halfScreenHeight = Screen.height / 2;

			Rect interactionTextRect = new Rect(halfScreenWidth - halfTextWidth/2, halfScreenHeight + 200, textWidth, textHeight);

			GUI.TextArea(interactionTextRect, interactionText);
		}
	}
}
