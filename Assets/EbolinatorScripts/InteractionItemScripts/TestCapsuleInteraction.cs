using UnityEngine;
using System.Collections;

public class TestCapsuleInteraction : InteractionItem
{
	public override void Interaction()
	{
		rigidbody.AddTorque(new Vector3(5, 0, 0));
	}
}
