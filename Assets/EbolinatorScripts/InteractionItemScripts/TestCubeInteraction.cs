using UnityEngine;
using System.Collections;

public class TestCubeInteraction : InteractionItem
{
	public override void Interaction()
	{
		rigidbody.AddForce(new Vector3(100, 0, 100));
	}
}
