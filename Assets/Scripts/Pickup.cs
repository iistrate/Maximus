using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			PlayerController playerController = other.GetComponentInChildren<PlayerController>();
			playerController.addHealth();
			Destroy(this.gameObject);
		}
	}}
