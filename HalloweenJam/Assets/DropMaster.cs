using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropMaster : MonoBehaviour
{
	[SerializeField] private RandomSpawner brewSpawner;
	[SerializeField] private RandomSpawner poisonSpawner;
	[SerializeField] private MugCollision mugCol;

	IEnumerator spawnBrew()
	{
		brewSpawner.SpawnObject(mugCol.fill);
		yield return new WaitForSeconds(Random.Range(0.5f, 0.75f));
		StartCoroutine(spawnBrew());
	}

	IEnumerator spawnPoison()
	{
		poisonSpawner.SpawnObject(mugCol.fill);
		yield return new WaitForSeconds(Random.Range(0.5f, 0.65f));
		StartCoroutine(spawnPoison());
	}

	private void Start()
	{
		if(brewSpawner != null)
		{
			StartCoroutine(spawnBrew());
		}
		
		if(poisonSpawner != null)
		{
			StartCoroutine(spawnPoison());
		}
	}
}
