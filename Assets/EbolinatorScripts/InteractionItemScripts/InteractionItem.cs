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

	//Found on unityAnswers, credit to user Eric5h5 
	public IEnumerator ShowMessage (string message, float delay) {
		GameObject textObj = GameObject.Find("popUpText");
		GUIText text = textObj.GetComponent<GUIText>();
		text.pixelOffset = new Vector2(Random.Range(-50,50), Random.Range(-10,10));
		text.text = message;
		text.enabled = true;
		yield return new WaitForSeconds(delay);
		text.enabled = false;
	}

	public void ExhaustedMessage(){
		StartCoroutine(ShowMessage("Already did that! +0", 2));
	}
}
