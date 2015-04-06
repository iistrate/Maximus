using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	Rigidbody2D rigidBody;
	Animator animator;
	bool jumping = false;
	bool flipped = false;
	bool flip = false;
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

		if (Input.GetKey ("up") && jumping == false) {
			movement.y = (float)jumpFactor;
			jumping = true;
		} 
		else {
			movement.y = 0;
		}
		rigidBody.velocity = movement * speed;

		if (jumping) {
			animation = "Player_Jumping";
		}
		else if (Input.GetKey ("right") || Input.GetKey ("left")) {
			if ((flipped && Input.GetKey ("right")) || (!flipped && Input.GetKey("left"))) {
				flip = true;
			}
			if (flip) {
				Vector3 scale = transform.localScale;
				scale.x *= -1;
				transform.localScale = scale;
				flip = false;
				flipped = flipped == true ? false : true;
			}
			animation = "Player_Walking";
		} 
		else {
			animation = "Player_Idle";
		}
		animator.CrossFade (animation, 0.0f);
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Ground") {
			jumping = false;
		}
	}
}
