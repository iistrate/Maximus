using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	Rigidbody2D rigidBody;
	Animator animator;
	bool jumping = false;
	bool flipped = false;
	bool flip = false;

	public int speed;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();	
		animator = GetComponent<Animator> ();
	}
	
	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
		rigidBody.velocity = movement * speed;

		if (Input.GetKey ("up") && jumping == false) {
			jumping = true;
		}

		if (jumping) {
			animator.CrossFade ("Player_Jumping", 0.0f);
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
			animator.CrossFade ("Player_Walking", 0.0f);
		} 
		else {
			animator.CrossFade ("Player_Idle", 0.0f);
		}
	}
}
