using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MapData
{
    public string Map;
    public bool IsMove;
}

public class MapManager : MonoBehaviour {

    const int BlockWidth = 17;
    const int BlockHeight = 13;

    public GameObject CurSprite;
    public GameObject MapBackGround;
    public Button ResetMap;
    public Sprite ResetBlockSp;
    [HideInInspector]
    public Sprite sp;
    public string CurrentTileNumber;

    List<List<GameObject>> Tile = new List<List<GameObject>>();

    public MapData[,] arrMap = new MapData[17, 13];

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

    void Start()
    {
        ResetMap.onClick.AddListener(ResetBlock);
        MapInit();
    }

    void MapInit()
    {
        GameObject tileMap = Resources.Load("Map") as GameObject;
        int TileNumber = 0;
        CurrentTileNumber = "0";
        for (int i = 0; i < BlockHeight; i++)
        {
            Tile.Add(new List<GameObject>());
            for (int j = 0; j < BlockWidth; j++)
            {
                arrMap[j, i] = new MapData();
                arrMap[j, i].Map = "0";
                arrMap[j, i].IsMove = true;
                Tile[i].Add(Instantiate(tileMap, new Vector3(-1.65f + 0.14f * j, 0.85f - i * 0.14f, 0), Quaternion.Euler(0, 0, 0)));
                Tile[i][j].name = (TileNumber++).ToString();
                Tile[i][j].transform.parent = MapBackGround.transform;
            }
        }
        sp = Tile[0][0].GetComponentInChildren<SpriteRenderer>().sprite;
    }
    
    public void ArrayInputNumber(int x, int y)
    {
        arrMap[x,y].Map = CurrentTileNumber;
        int temp;
        int.TryParse(CurrentTileNumber, out temp);

        arrMap[x, y].IsMove = temp < 3 ? true : false;
    }

    void ResetBlock()
    {
        for (int i = 0; i < BlockHeight; i++)
        {
            for (int j = 0; j < BlockWidth; j++)
            {
				Tile[i][j].GetComponentInChildren<SpriteRenderer>().sprite = ResetBlockSp;
                arrMap[j, i].Map = "0";
                arrMap[j, i].IsMove = true;

            }
		}
    }
}
