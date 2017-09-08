using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D rb;

	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {
		// Debug.Log (Input.GetAxis ("Horizontal"));
		/*rb.AddForce (new Vector2 (
			Input.GetAxis ("Horizontal"),
			Input.GetAxis ("Vertical")
		));*/

		float x = 0;
		if (Input.GetAxis ("Horizontal") > 0) {
			x = 1;
		} else if (Input.GetAxis ("Horizontal") < 0) {
			x = -1;
		}

		rb.velocity = new Vector2 (
			x,
			Input.GetAxis ("Vertical")
		);

	}
}
