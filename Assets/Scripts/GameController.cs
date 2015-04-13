using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GUIText scoreText;
	public GUIText gameOverText;
	public GUIText gameHint;
	public Transform tileManager;

	int score;

	bool b_gameOver;
	bool b_restart;

	// Use this for initialization
	void Start () {
		b_gameOver = false;
		b_gameOver = false;
		gameHint.text = "Hint: You can double jump when hitting a wall.";

		score = 0;
		UpdateScore ();
		startNewGame();
	}

	void Update() {

		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.LoadLevel(0);
		}

		if (b_gameOver) {
			if (Input.GetKey(KeyCode.R)) {
				b_restart = true;
				b_gameOver = false;
			}
		}
		if (b_restart) {
			Application.LoadLevel(Application.loadedLevel);
			b_restart = false;
		}
	}

	void startNewGame() {
		Instantiate(tileManager, new Vector3(0, 0, 0), Quaternion.identity);
		gameOverText.text = "";
	}

	public void gameOver() {
		gameOverText.text = "Game Over, Thanks for playing!! Press R to restart.";
		b_gameOver = true;
	}

	// Update is called once per frame
	void UpdateScore () {
		scoreText.text = "Score: " + score;
	}

	public void addScore(int newScore) {
		score += newScore;
		UpdateScore ();
	}
}
