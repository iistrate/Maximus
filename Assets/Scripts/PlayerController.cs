﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	Rigidbody2D rigidBody;
	Animator animator;
	bool jumping = false;
	bool flipped = false;
	bool flip = false;
	bool fire = false;
	string animation = "Player_Idle";
	int direction;
	public float fireRate = 0.5F;
	private float nextFire = 0.0F;
	public int health;
	public GUIText healthText;

	public int maxSpeed;
	public float jumpFactor;

	public Rigidbody2D bullet;
	public Transform shotSpawn;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();	
		animator = GetComponent<Animator> ();
		direction = 1;
		healthText.text = "Health: " + health;
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
			rigidBody.AddForce (Vector3.up * jumpFactor, ForceMode2D.Impulse);
			jumping = true;
		} 
		else if (Input.GetKeyDown (KeyCode.DownArrow) && jumping == true) {
			rigidBody.AddForce (Vector3.down * (jumpFactor / 2), ForceMode2D.Impulse);
		}
		if (Input.GetKeyDown (KeyCode.Space) && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Rigidbody2D instance = Instantiate(bullet, shotSpawn.position, Quaternion.identity) as Rigidbody2D;
			int speed = 10;
			instance.velocity = transform.right * speed * direction;
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
				direction *= -1;
				transform.localScale = scale;

				flip = false;
				flipped = flipped == true ? false : true;
			}
		} 
		animator.CrossFade (animation, 0.0f);
	}

	void OnCollisionEnter2D(Collision2D collision) {
		string tag = collision.gameObject.tag;
		if (tag == "Ground" || tag == "Enemy") {
			jumping = false;
		}
	}

	public int getHealth() {
		return health;
	}
	public void addHealth() {
		health += 50;
		healthText.text = "Health: " + health;
	}

	public void Hit() {
		health -= 50;
		healthText.text = "Health: " + health;
	}
}
