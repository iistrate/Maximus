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
				PlayerController playerControler = GetComponentInChildren<PlayerController>();
				if (playerControler.getHealth() > 50) {
					Destroy(coll.gameObject);
					playerControler.Hit();
					return;
				}
				else {
					playerControler.Hit();
					gameController.gameOver();
				}
			}
			else if (this.gameObject.tag == "BoxSmall") {
				GameObject health = Instantiate(Resources.Load("Health")) as GameObject;
				health.transform.position = this.gameObject.transform.position;
			}
			Destroy(this.gameObject);
			Destroy(coll.gameObject);
			gameController.addScore (scoreValue);
		}
	}}
	
