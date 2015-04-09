using UnityEngine;
using System.Collections.Generic;

public class TileManager : MonoBehaviour {

	public List <GameObject> groundTiles;
	public List <GameObject> boxTiles;
	public int levelSize;

	//holds all our tiles in hierarchy
	Transform groundHolder;

	//position for left bottom
	float leftPos = -10.75f;
	float bottomPos = -1.2f;

	//image sizes
	float imageW = 0.64f;
	float imageH = 0.64f;

	// Use this for initialization
	void Start () {
		groundHolder = new GameObject ("GroundTileHolder").transform;

		int counter = 0;
		while (levelSize != 0) {
			//select tile
			GameObject toInstantiate = groundTiles[Random.Range(0, groundTiles.Count)];
			//get size
			Vector3 position = new Vector3(leftPos + (float)counter*imageW, bottomPos,0f);
			//instantiate object at position with no rotation
			GameObject instance = Instantiate(toInstantiate, position, Quaternion.identity) as GameObject;
			//add child to hierarchy
			instance.transform.SetParent(groundHolder);

			levelSize--;
			counter++;
		}

	}
	
}