using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

	GameObject player;

	// Use this for initialization
	void Awake () {
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (player.transform.position.x, 3.5f, -20f);
	}
}
