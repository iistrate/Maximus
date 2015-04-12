using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

	GameObject Player;

	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (Player.transform.position.x, 3.5f, -20f);
	}
}
