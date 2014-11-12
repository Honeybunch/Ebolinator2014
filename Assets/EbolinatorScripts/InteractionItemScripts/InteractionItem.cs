using UnityEngine;
using System.Collections;

public class InteractionItem : MonoBehaviour
{
	[HideInInspector]
	public bool selected;

	Material material;
	bool materialHasOutline;

	// Use this for initialization
	void Start ()
	{
		material = renderer.material;

		if(material.name.Contains("Outline"))
		   materialHasOutline = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(selected)
			SetOutlineColor(Color.green);
		else
			SetOutlineColor(Color.black);

		selected = false;
	}

	public virtual void Interaction()
	{
		Debug.Log("This interaction needs to be overridden");
	}
	
	/// <summary>
	/// Sets the color of the outline.
	/// </summary>
	/// <param name="color">Color.</param>
	public void SetOutlineColor(Color color)
	{
		if(materialHasOutline)
			material.SetColor("_OutlineColor", color);
	}
}
