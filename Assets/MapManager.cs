using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {

	List<List<GameObject>> Tile = new List<List<GameObject>>();
	

	// Use this for initialization
	void Start () {

		// for(int i = 0; i < 13; i++)
		// {
		// 	Tile.Add(new List<GameObject>());
		// 	for(int j = 0; j < 17; j++)
		// 	{
		// 		GameObject tileMap = Resources.Load ("Tile") as GameObject;
				
		// 		Tile[i].Add(Instantiate(tileMap, new Vector3(-130 + j * 10,75 - i * 10,0), Quaternion.Euler(-90, 0, 0)));
		// 	}
		// }
		// Debug.Log(Tile.Count);
		// Debug.Log(Tile[0].Count);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
