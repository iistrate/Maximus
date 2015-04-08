using UnityEngine;
using System.Collections.Generic;

public class TileManager : MonoBehaviour {

	public List <GameObject> groundTiles;
	public int levelSize;
	//holds all our tiles in hierarchy
	Transform groundTileHolder;

	// Use this for initialization
	void Start () {
		float leftPos = -10.75f;
		float bottomPos = -1.2f;
		groundTileHolder = new GameObject ("GroundTileHolder").transform;
		int counter = 0;
		while (levelSize != 0) {
			//select tile
			GameObject toInstantiate = groundTiles[Random.Range(0, groundTiles.Count)];
			//get size
			float width = toInstantiate.GetComponent<BoxCollider2D>().size.x;
			Vector3 position = new Vector3(leftPos + (float)counter*width, bottomPos,0f);
			//instantiate object at position with no rotation
			GameObject instance = Instantiate(toInstantiate, position, Quaternion.identity) as GameObject;
			//add child to hierarchy
			instance.transform.SetParent(groundTileHolder);

			levelSize--;
			counter++;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
