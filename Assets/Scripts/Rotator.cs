using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
		speed = Random.Range (5, 10) * 10;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0f, 0f, speed * Time.deltaTime);
	}
}
