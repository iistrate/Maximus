using UnityEngine;
using System.Collections.Generic;

public class TileManager : MonoBehaviour {

	public List <GameObject> groundTiles;
	public List <GameObject> boxTiles;
	public int levelSize;

	//holds all our tiles in hierarchy
	Transform groundHolder;
	Transform surpriseHolder;

	//position for left bottom
	float leftPos = -10.75f;
	float bottomPos = -1.35f;


	int maxPlatforms = 50;

	int minHeight = 1;
	int maxHeight = 2;
	int minWidth = 5;
	int maxWidth = 15;

	int jumpX = 10;
	int jumpY = 3;
	int init = 10;

	//image sizes
	float imageW = 0.64f;
	float imageH = 0.64f;

	// Use this for initialization
	void Start () {
		groundHolder = new GameObject ("GroundTileHolder").transform;
		surpriseHolder = new GameObject ("SurpriseHolder").transform;
		SpawnPlatforms ();
	}

	void SpawnPlatforms() {
		//get player position
		GameObject player = GameObject.Find ("Player");
		Vector2 pos = player.GetComponent<Transform> ().position;

		//calculate initial platform x and y
		float initialPlatformX = pos.x;
		float initialPlatformY = pos.y - player.transform.localScale.y; 

		while (maxPlatforms != 0) {
			GameObject platform = groundTiles[Random.Range(0, groundTiles.Count)];

			//platform size
			Vector3 scale = platform.transform.localScale;
			scale.x = Random.Range(minWidth, maxWidth);
			scale.y = Random.Range(minHeight, maxHeight);
			platform.transform.localScale = scale;

			//platform position
			Vector3 position = platform.transform.position;
			position.x = initialPlatformX;
			position.y = initialPlatformY;
			platform.transform.position = position;

			//instantiate
			GameObject instance = Instantiate(platform, position, Quaternion.identity) as GameObject;
			//add to ground hierarchy
			instance.transform.SetParent(groundHolder);


			initialPlatformX += jumpX;
			initialPlatformY = Random.Range(bottomPos, initialPlatformY+jumpY);

			//place player surprise
			placeSurprise(initialPlatformX, initialPlatformY);

			maxPlatforms--;
		}
	}
	void placeSurprise(float x, float y) {
		int dice = Random.Range (1, 6);
		if (dice > 0) {
			GameObject box = boxTiles [Random.Range (0, boxTiles.Count)];
			Vector3 position = box.transform.position;
			//set above platform
			position.y = y + maxHeight;
			//set in middle of platform
			position.x = x;
			box.transform.position = position;
			GameObject instance = Instantiate(box, position, Quaternion.identity) as GameObject;
			instance.transform.SetParent(surpriseHolder);
		}
		else {
		}
	}
	
}