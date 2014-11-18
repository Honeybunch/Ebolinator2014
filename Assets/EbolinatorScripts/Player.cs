using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	Camera playerCamera;

	string interactionText;
	bool displayInteractionText;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () 
	{
		interactionText = "Press E or Left Mouse Button To Interact";
		displayInteractionText = false;

		playerCamera = Camera.main;
	}
	
	/// <summary>
	/// Update this instance and fire raycasts to determine how we interact
	/// with the environment
	/// </summary>
	void Update ()
	{
		//Fire a raycast
		RaycastHit hit;
		if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, 2))
		{				
			GameObject hitObject = hit.transform.gameObject;
			
			InteractionItem interactionItem = hitObject.GetComponent<InteractionItem>();

			if(interactionItem != null)
			{
				//Set flag so we can display interaction text in OnGUI
				displayInteractionText = true;
		
				interactionItem.selected = true;

				if(Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
				{
					interactionItem.Interaction();
				}
			}
		}
		else
		{
			displayInteractionText = false;
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

			Rect interactionTextRect = new Rect(halfScreenWidth - halfTextWidth/2, halfScreenHeight + 200, textWidth + 12, textHeight);

			GUI.Box(interactionTextRect, interactionText);
		}
	}
}