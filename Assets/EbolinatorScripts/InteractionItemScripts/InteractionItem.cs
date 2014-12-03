using UnityEngine;
using System.Collections;

public class InteractionItem : Selectable
{
	protected GameMaster gameMaster;
	public bool exhausted = false;

	// Use this for initialization
	public override void Start ()
	{
		gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
		base.Start();
	}

	// Update is called once per frame
	public override void Update ()
	{
		base.Update();
	}

	public override void HandleSelection()
	{
		if(Selected)
			SetOutlineColor(Color.green);
		else
			SetOutlineColor(Color.black);

		Selected = false;
	}

	public virtual void Interaction()
	{
		Debug.Log("This interaction needs to be overridden");
	}
}
