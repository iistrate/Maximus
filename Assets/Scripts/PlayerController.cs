using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	Rigidbody2D rigidBody;
	Animator animator;
	bool jumping = false;
	bool flipped = false;
	bool flip = false;
	bool fire = false;
	string animation = "Player_Idle";

	public int maxSpeed;
	public float jumpFactor;

	public GameObject bullet;
	public Transform shotSpawn;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();	
		animator = GetComponent<Animator> ();
	}
	// Physics update
	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float horizontalForce = 30f;

		if (rigidBody.velocity.x * moveHorizontal < maxSpeed) {
			rigidBody.AddForce (Vector2.right * moveHorizontal * horizontalForce);
		}
		if (rigidBody.velocity.x > maxSpeed) {
			rigidBody.velocity = new Vector2(Mathf.Sign(rigidBody.velocity.x) * maxSpeed, rigidBody.velocity.y);
		}
	}
	//Game update
	void Update() {
		if (Input.GetKeyDown (KeyCode.UpArrow) && jumping == false) {
			rigidBody.AddForce(Vector3.up * jumpFactor, ForceMode2D.Impulse);
			jumping = true;
		} 
		if (Input.GetKeyDown (KeyCode.Space)) {
			Instantiate(bullet, shotSpawn.position, Quaternion.identity);
			fire = true;
		}
		if (Input.GetKeyUp(KeyCode.Space)) {
			fire = false;
		}
		
		if (jumping && !fire) {
			animation = "Player_Jumping";
		} 
		else if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.LeftArrow)) {
			animation = "Player_Walking";
		} 
		else if (fire) {
			animation = "Player_Fire";
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
		}
	}
}
