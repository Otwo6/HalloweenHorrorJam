using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag != "Poison" || col.gameObject.tag != "Brew")
		{
			Destroy(gameObject);
		}
	}
}
