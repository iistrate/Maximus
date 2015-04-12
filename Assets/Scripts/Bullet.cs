using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	Rigidbody2D rigidBody;
	public float speed;

	void Start() {
		rigidBody = GetComponent<Rigidbody2D> ();
		rigidBody.velocity = new Vector2(speed, 0.0f);
	}
}
