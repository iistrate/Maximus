using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	public GameObject bullet;
	public Transform shotSpawn;
	public float maxSpeed;
	private float range;

	void FixedUpdate () { 
		range = 7;
		//Debug.DrawRay (shotSpawn.position, Vector2.right*-1); //test ray direction
		RaycastHit2D hit = Physics2D.Raycast(shotSpawn.position, Vector2.right*-1, range);
		if (hit) {
			//Debug.Log(hit.transform.gameObject.tag);
			if (hit.rigidbody.tag == "Player") {
				GameObject instance = Instantiate (bullet, shotSpawn.position, Quaternion.identity) as GameObject;
			}
		}
	}
}
