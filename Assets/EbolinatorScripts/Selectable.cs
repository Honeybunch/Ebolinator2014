using UnityEngine;
using System.Collections;

public class Selectable : MonoBehaviour
{
	public bool Selected
	{
		get
		{ 
			if(isSelectable) 
				return selected;
			else
				return false;
		}

		set{selected = value;}
	}

	public bool IsSelectable
	{
		get{return isSelectable;}
		set{isSelectable = value;}
	}

	private bool selected = false;
	private bool isSelectable = true;

	protected Material material;
	protected bool materialHasOutline;

	// Use this for initialization
	public virtual void Start ()
	{
		material = renderer.material;

		if(material.shader.name.Contains("Outline"))
			materialHasOutline = true;
	}
	
	// Update is called once per frame
	public virtual void Update ()
	{
		HandleSelection();
	}

	public virtual void HandleSelection(){}

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
