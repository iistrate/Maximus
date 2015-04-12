using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	Rigidbody2D rigidBody;
	Transform firing;
	int direction;
	private float speed;

	void Awake() {
		speed = 10;
		rigidBody = GetComponent<Rigidbody2D> ();
		firing = GameObject.FindWithTag("Player").GetComponent<Transform> ();
		//flip bullet
		direction = firing.localScale.x > 0 ? 1 : -1;
		rigidBody.velocity = transform.TransformDirection(Vector2.right * direction * speed);
	}

}
