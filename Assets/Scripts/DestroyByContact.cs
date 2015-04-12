using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public int scoreValue;
	private GameController gameController;

	void Start() {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		gameController = gameControllerObject.GetComponent<GameController>();
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Bullet") {
			Destroy(this.gameObject);
			gameController.addScore (scoreValue);
		}
	}}
	
