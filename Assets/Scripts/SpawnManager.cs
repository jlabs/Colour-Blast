using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	public GameObject smallCircle;
	public GameObject colourChanger;

	public Transform lastCircleSpawnPoint;

	private Vector3 spawnerWorldPosition;
	private Vector3 nextCircleSpawnPosition;
	private Vector3 nextColourChangerSpawnPosition;

	private float spawnOffset;

	//public Camera camera;
	private Vector3 cameraCentre;

	// Use this for initialization
	void Start () {

		nextCircleSpawnPosition.y = lastCircleSpawnPoint.position.y + 10f;

		cameraCentre = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, 0f));
		
	}
	
	// Update is called once per frame
	void Update () {

		spawnerWorldPosition = transform.parent.position + transform.position;
		spawnerWorldPosition.z = 0;
	
		if (spawnerWorldPosition.y >= nextCircleSpawnPosition.y) { 
			Instantiate (smallCircle, spawnerWorldPosition, Quaternion.identity);
			nextCircleSpawnPosition.y = spawnerWorldPosition.y + (cameraCentre.y * 2);

			nextColourChangerSpawnPosition = new Vector3 (0f, spawnerWorldPosition.y + cameraCentre.y, 0f);
			Instantiate (colourChanger, nextColourChangerSpawnPosition, Quaternion.identity);
		}

	}
}
