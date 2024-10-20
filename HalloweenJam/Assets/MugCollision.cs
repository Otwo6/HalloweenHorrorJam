using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MugCollision : MonoBehaviour
{
	public int fill = 1;

	private void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Poison")
		{
			if(fill > 1)
			{
				fill--;
			}
			else
			{
				print("YOURE BAD");
			}
			Destroy(col.gameObject);
		}
		else if(col.gameObject.tag == "Brew")
		{
			fill++;
			if(fill >= 8)
			{
				print("YOURE GOOD");
			}
			Destroy(col.gameObject);
		}
		else
		{
			print(col.gameObject + " tag: " + col.gameObject.tag);
		}
	}
}
