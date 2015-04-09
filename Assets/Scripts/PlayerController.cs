using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	Rigidbody2D rigidBody;
	Animator animator;
	bool jumping = false;
	bool flipped = false;
	bool flip = false;
	bool flying = false;
	string animation = "Player_Idle";

	public int speed;
	public int jumpFactor;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();	
		animator = GetComponent<Animator> ();
	}
	// Physics update
	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
		rigidBody.velocity = movement * speed;

		if (Input.GetKeyDown (KeyCode.Space) && jumping == false && !flying) {
			rigidBody.AddForce(Vector3.up * jumpFactor, ForceMode2D.Impulse);
			jumping = true;
		} 
		else if (Input.GetKeyDown (KeyCode.UpArrow) && flying == false) {
			flying = true;
		}


		if (jumping || flying) {
			animation = "Player_Jumping";
		} 
		else if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.LeftArrow)) {
			animation = "Player_Walking";
		}
		else {
			animation = "Player_Idle";
		}

		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.LeftArrow)) {
			if ((flipped && Input.GetKey (KeyCode.RightArrow)) || (!flipped && Input.GetKey(KeyCode.LeftArrow))) {
				flip = true;
			}
			if (flip) {
				Vector3 scale = transform.localScale;
				scale.x *= -1;
				transform.localScale = scale;
				flip = false;
				flipped = flipped == true ? false : true;
			}
		} 
		animator.CrossFade (animation, 0.0f);
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Ground") {
			jumping = false;
			flying = false;
		}
	}
}
