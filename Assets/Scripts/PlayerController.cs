using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	Rigidbody2D rigidBody;
	Animator animator;
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
		if (Input.GetKey ("up") || Input.GetKey ("down") || Input.GetKey ("right") || Input.GetKey ("left")) {
			animator.CrossFade ("Player_Walking", 0.0f);
		} 
		else {
			animator.CrossFade ("Player_Idle", 0.0f);
		}
	}
}
