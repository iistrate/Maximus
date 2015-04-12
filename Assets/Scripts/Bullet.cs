using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	Rigidbody2D rigidBody;
	Transform player;
	public float speed;
	int direction;

	void Start() {
		rigidBody = GetComponent<Rigidbody2D> ();
		player = GameObject.Find ("Player").GetComponent<Transform> ();
		direction = player.localScale.x > 0 ? 1 : -1;

		rigidBody.velocity = new Vector2(transform.right.x * direction, 0) * speed;
	}
}
