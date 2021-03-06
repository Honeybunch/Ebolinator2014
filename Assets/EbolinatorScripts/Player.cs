﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	Camera playerCamera;

	AudioSource audioSource;
	AudioClip goodBeep;
	AudioClip badBeep;

	string interactionText;
	string pickupText;

	bool displayInteractionText;
	bool displayPickupText;

	GUIStyle style;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () 
	{
		interactionText = "Press E or Left Mouse Button To Interact";
		pickupText = "Press E or Left Mouse Button to Pick Up";

		displayInteractionText = false;
		displayPickupText = false;

		playerCamera = Camera.main;

		style = new GUIStyle();

		audioSource = GetComponent<AudioSource>();
		goodBeep = (AudioClip)Resources.Load("Sounds/goodbeep");
		badBeep = (AudioClip)Resources.Load("Sounds/badbeep");
	}
	
	/// <summary>
	/// Update this instance and fire raycasts to determine how we interact
	/// with the environment
	/// </summary>
	void Update ()
	{
		//Fire a raycast
		RaycastHit hit;
		if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, 4))
		{				
			GameObject hitObject = hit.transform.gameObject;
			InteractionItem interactionItem = hitObject.GetComponent<InteractionItem>();
			PickupableItem pickupableItem = hitObject.GetComponent<PickupableItem>();

			if(interactionItem != null)
			{
				//Set flag so we can display interaction text in OnGUI
				displayInteractionText = true;
		
				interactionItem.Selected = true;

				if(Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
				{
					interactionItem.Interaction();

					if(interactionItem.exhausted)
						audioSource.clip = badBeep;
					else
						audioSource.clip = goodBeep;

					audioSource.Play();
				}

			}
			else if(pickupableItem != null)
			{
				//Set flag to display pickup text in OnGUI
				displayPickupText = true;

				pickupableItem.Selected = true;

				if(Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
				{

					pickupableItem.Pickup();
				}
			}
		}
		else
		{
			displayInteractionText = false;
			displayPickupText = false;
		}
	}

	/// <summary>
	/// Used to display whether or not the player can interact with an object
	/// </summary>
	void OnGUI()
	{
		style = GUI.skin.GetStyle("Box");
		style.fontSize = 16;

		if(displayInteractionText)
		{
			Vector2 textSize = style.CalcSize(new GUIContent(interactionText));
			float textWidth = textSize.x;
			float textHeight = textSize.y;

			float halfTextWidth = textWidth / 2;

			float halfScreenWidth = Screen.width / 2;
			float halfScreenHeight = Screen.height / 2;

			Rect interactionTextRect = new Rect(halfScreenWidth - halfTextWidth/2, halfScreenHeight + 200, textWidth + 12, textHeight);

			GUI.Box(interactionTextRect, interactionText, style);
		}
		else if(displayPickupText)
		{
			Vector2 textSize = style.CalcSize(new GUIContent(pickupText));
			float textWidth = textSize.x;
			float textHeight = textSize.y;
			
			float halfTextWidth = textWidth / 2;
			
			float halfScreenWidth = Screen.width / 2;
			float halfScreenHeight = Screen.height / 2;
			
			Rect pickupTextRect = new Rect(halfScreenWidth - halfTextWidth/2, Screen.height - halfScreenHeight/2, textWidth + 12, textHeight);
			
			GUI.Box(pickupTextRect, pickupText, style);
		}
	}
}