using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour {

	const int BlockWidth = 17;
	const int BlockHeight = 13;

    List<List<GameObject>> Tile = new List<List<GameObject>>();
	
	int[,] arrBinary = new int[17, 13];

    public List<Button> TileButton;
    public Sprite sp;
    int aa;

    private static MapManager _instance = null;
    
    public static MapManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("cSingleton == null");
            return _instance;
        }
    }
 
    void Awake()
    {
		_instance = this;
    }

    // Use this for initialization
    void Start()
    {
        GameObject tileMap = Resources.Load("Block") as GameObject;
        aa = 0;
        for (int i = 0; i < BlockHeight; i++)
        {
            Tile.Add(new List<GameObject>());
            for (int j = 0; j < BlockWidth; j++)
            {

                //tileMap.gameObject.name += (++aa).ToString();
                Tile[i].Add(Instantiate(tileMap, new Vector3(-1.65f + 0.14f * j, 0.85f - i * 0.14f,0), Quaternion.Euler(0, 0, 0)));
				Tile[i][j].name += (++aa).ToString();
			}
		}
		// Debug.Log(Tile.Count);
		// Debug.Log(Tile[0].Count);

		sp = TileButton[0].GetComponent<Image>().sprite;
		Debug.Log(sp.name);
		Debug.Log(arrBinary.Length);

	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(sp.name);
	}
}
