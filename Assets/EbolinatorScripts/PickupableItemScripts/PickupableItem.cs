using UnityEngine;
using System.Collections;

public class PickupableItem : Selectable
{
	public override void Start()
	{
		base.Start();
	}

	public virtual void Pickup()
	{
		Debug.Log("This pickup should be overridden");
	}

	// Update is called once per frame
	public override void Update ()
	{
		base.Update();
	}

	public override void HandleSelection()
	{
		if(Selected)
			SetOutlineColor(Color.blue);
		else
			SetOutlineColor(Color.black);
		
		Selected = false;
	}
}
