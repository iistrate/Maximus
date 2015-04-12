using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Bullet") {
			Destroy(this.gameObject);
		}
	}}
