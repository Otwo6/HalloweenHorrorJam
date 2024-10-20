using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorMatchMaster : MonoBehaviour
{
	public Material[] possibleColors;
	[SerializeField] private Material mirrorMat;

	public Material[] round1 = new Material[3];
	public Material[] round2 = new Material[5];
	public Material[] round3 = new Material[7];
	
	public bool showMode = false;
	public int round = 1;
	public int index = 0;
	
	[SerializeField] private Renderer mirror;

	private void Start()
	{
		SetRounds(round1);
		SetRounds(round2);
		SetRounds(round3);

		ShowPattern(round1);
	}

	private void SetRounds(Material[] round)
	{
		for(int i = 0; i < round.Length; i++)
		{
			round[i] = possibleColors[Random.Range(0, possibleColors.Length)];
		}
	}

	IEnumerator changeMaterial(Material[] newMat)
	{
		for(int i = 0; i < newMat.Length; i++)
		{
			mirror.material = newMat[i];
			yield return new WaitForSeconds(1);
		}
		mirror.material = mirrorMat;
		showMode = false;
	}

	private void ShowPattern(Material[] round)
	{
		showMode = true;
		StartCoroutine(changeMaterial(round));
	}

	IEnumerator delayedShowPattern(Material[] round)
	{
		yield return new WaitForSeconds(1);
		ShowPattern(round);
	}

	public void CheckSpot()
	{
		if(round == 1)
		{
			if(index >= round1.Length)
			{
				showMode = true;
				index = 0;
				round = 2;
				StartCoroutine(delayedShowPattern(round2));
			}
		}
		else if(round == 2)
		{
			if(index >= round2.Length)
			{
				showMode = true;
				index = 0;
				round = 3;
				StartCoroutine(delayedShowPattern(round3));
			}
		}
		else if(round == 3)
		{
			if(index >= round1.Length)
			{
				index = 0;
				print("DONE");
			}
		}
	}
}
