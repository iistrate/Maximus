using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public int scoreValue;
	private GameController gameController;
	public GameObject explosion;

	void Start() {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		gameController = gameControllerObject.GetComponent<GameController>();
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Bullet") {
			explosion.GetComponent<Animator>().StartPlayback();
			Instantiate(explosion, transform.position, transform.rotation);
			if (this.gameObject.tag == "Player") {
				gameController.gameOver();
			}
			Destroy(this.gameObject);
			Destroy(coll.gameObject);
			gameController.addScore (scoreValue);
		}
	}}
	
