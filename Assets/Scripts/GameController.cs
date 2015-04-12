using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GUIText scoreText;
	private int score;

	// Use this for initialization
	void Start () {
		score = 0;
		UpdateScore ();
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
