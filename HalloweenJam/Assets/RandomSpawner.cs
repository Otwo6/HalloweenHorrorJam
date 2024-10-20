using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
	[SerializeField] private GameObject objectToSpawn; // The object to spawn
	[SerializeField] private Vector3 minSpawnPosition; // Minimum spawn range
	[SerializeField] private Vector3 maxSpawnPosition; // Maximum spawn range

	void Start()
	{
		SpawnObject(1);
	}

	public void SpawnObject(int mugFill)
	{
		// Generate a random position between the specified ranges
		Vector3 randomPosition = new Vector3(
			Random.Range(minSpawnPosition.x, maxSpawnPosition.x),
			Random.Range(minSpawnPosition.y, maxSpawnPosition.y),
			Random.Range(minSpawnPosition.z, maxSpawnPosition.z)
		);

		// Instantiate the object at the random position
		GameObject spawned = Instantiate(objectToSpawn, randomPosition, Quaternion.Euler(90, 0, 0));
		spawned.GetComponent<Rigidbody>().drag = 5 * 1 / mugFill;
	}
}
