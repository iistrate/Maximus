using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {
	public float timeTillDestroy = 5;
	void Start () {
		Destroy (gameObject, timeTillDestroy);
	}
}
