using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	public Rigidbody2D bullet;
	public Transform shotSpawn;
	public float maxSpeed;
	private float range;
	public float fireRate = 0.5F;
	private float nextFire = 0.0F;
	int direction;

	void Start() {
		direction = -1;
	}

	void FixedUpdate () { 
		range = 7;
		//Debug.DrawRay (shotSpawn.position, Vector2.right*-1); //test ray direction
		RaycastHit2D hit = Physics2D.Raycast(shotSpawn.position, Vector2.right*-1, range);
		if (hit) {
			//Debug.Log(hit.transform.gameObject.tag);
			if (hit.rigidbody.tag == "Player" && Time.time > nextFire) {
				nextFire = Time.time + fireRate;
				Rigidbody2D instance = Instantiate (bullet, shotSpawn.position, Quaternion.identity) as Rigidbody2D;
				int speed = 7;
				instance.velocity = transform.right * speed * direction;
			}
		}
	}
}
