using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {
	private GameController gameController;
	
	void Start() {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		gameController = gameControllerObject.GetComponent<GameController>();
	}	
	void OnTriggerExit2D(Collider2D other) {
		// Destroy everything that leaves the trigger
		if (other.tag != "Ground") {
			if (other.gameObject.tag == "Player") {
				gameController.gameOver();
			}
			Destroy (other.gameObject);
		}
	}
}
