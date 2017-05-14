using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public Rigidbody2D rb;
	public SpriteRenderer sr;
	public float jumpForce = 10f;
	public string currentColour;

	public enum ColourChoice { Cyan, Yellow, Pink, Magenta }

	public Color colourCyan;
	public Color colourYellow;
	public Color colourPink;
	public Color colourMagenta;

	private int scoreCounter;
	public Text scoreDisplay;

	// Use this for initialization
	void Start () {

		scoreCounter = 0;

		SetRandomColour ();

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Jump") || Input.GetMouseButtonDown (0)) {
			rb.velocity = Vector2.up * jumpForce;
		}

		scoreDisplay.text = scoreCounter.ToString();

	}

	void OnTriggerEnter2D (Collider2D col) {

		if (col.tag == "ColourChanger") {
			SetRandomColour ();
			Destroy (col.gameObject);

			scoreCounter++;

			return;
		}

		if (col.name != currentColour) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}

	}

	void SetRandomColour () {

		Debug.Log ("Colour Change");

		int index = Random.Range (0, 4);

		switch (index) {
		case 0:
			currentColour = "Cyan";
			sr.color = colourCyan;
			break;
		case 1:
			currentColour = "Yellow";
			sr.color = colourYellow;
			break;
		case 2:
			currentColour = "Pink";
			sr.color = colourPink;
			break;
		case 3:
			currentColour = "Magenta";
			sr.color = colourMagenta;
			break;
		}

	}
}
