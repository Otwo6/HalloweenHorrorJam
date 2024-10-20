using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionInteract : MonoBehaviour
{
	[SerializeField] private MirrorMatchMaster master;
	[SerializeField] private Material myMat;
	public void CheckPotion()
	{
		print("CHECKING");
		if(master.showMode == false)
		{
			if(master.round == 1)
			{
				if(master.round1[master.index] == myMat)
				{
					print("GOOD");
					master.index++;
					master.CheckSpot();
				}
			}
			else if(master.round == 2)
			{
				if(master.round2[master.index] == myMat)
				{
					print("GOOD");
					master.index++;
					master.CheckSpot();
				}
			}
			else if(master.round == 3)
			{
				if(master.round3[master.index] == myMat)
				{
					print("GOOD");
					master.index++;
					master.CheckSpot();
				}
			}
			
		}
	}
}
