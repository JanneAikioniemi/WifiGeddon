using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMapTiles : MonoBehaviour {
	public int rows = 10;
	public int columns = 10;
	public int tileWidth = 5;
	public int tileHeight = 5;
	public int maxEmptyTileCount = 10;
	public GameObject emptyTile;
	public GameObject towerTile;
	public GameObject forestTile;
	List<int> tileIndexList;

	private bool towerTilePlaced = false;
	private int emptyTileCount = 0;
	private int forestTileCount = 0;
	private int maxForestTileCount = 0;
	private static Random rng = new Random();  

	// Use this for initialization
	void Start () {
		tileIndexList = new List<int> ();
		for (int i = 1; i < rows*columns+1; i++) {
			tileIndexList.Add (i);
		}
		for (int i = 0; i < tileIndexList.Count; i++) {
			int temp = tileIndexList[i];
			int randomIndex = Random.Range(i, tileIndexList.Count);
			tileIndexList[i] = tileIndexList[randomIndex];
			tileIndexList[randomIndex] = temp;
		}
			
		maxForestTileCount = (rows*columns)-1-maxEmptyTileCount;
		//Debug.Log (maxForestTileCount);
		float startX = (rows / 2) * -tileWidth;
		float startY = (columns / 2) * -tileHeight;

		for (int i = 0; i < rows; i++) 
		{
			for (int j = 0; j < columns; j++) 
			{
				//Debug.Log (tileIndexList[i*rows + j]);
				float x = startX + tileWidth * i;
				float y = startY + tileHeight * j;
				if (tileIndexList [i * rows + j] == 1) {
					GameObject newTile = Instantiate (towerTile, new Vector3 (x, 0, y), Quaternion.identity);
					ResourceManager.Instance.towerLocation = new Vector2 (i, j);
					newTile.transform.parent = this.transform;
				} else if (tileIndexList [i * rows + j] > 1 && tileIndexList [i * rows + j] <= 1 + maxEmptyTileCount) {
					GameObject newTile = Instantiate (emptyTile, new Vector3 (x, 0, y), Quaternion.identity);
					newTile.transform.parent = this.transform;
				} else if (tileIndexList [i * rows + j] > 1 + maxEmptyTileCount) {
					GameObject newTile = Instantiate (forestTile, new Vector3 (x, 0, y), Quaternion.identity);
					newTile.transform.parent = this.transform;
				}
			}
		}
	}
}
