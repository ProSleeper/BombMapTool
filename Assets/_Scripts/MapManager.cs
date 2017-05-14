using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour {

	const int BlockWidth = 17;
	const int BlockHeight = 13;

    List<List<GameObject>> Tile = new List<List<GameObject>>();
	
	string[,] arrBinary = new string[17, 13];

    public Button SaveMap;
    public Button ResetMap;

    public List<Button> TileButton;
    public Sprite ResetBlockSp;
    [HideInInspector]
    public Sprite sp;
    public GameObject CurSprite;
    public GameObject MapBackGround;
    int TileNumber;
    public string CurrentTileNumber;

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
        SaveMap.onClick.AddListener(SaveData);
        ResetMap.onClick.AddListener(ResetBlock);

        GameObject tileMap = Resources.Load("Block") as GameObject;
        TileNumber = 0;
        CurrentTileNumber = "0";
        for (int i = 0; i < BlockHeight; i++)
        {
            Tile.Add(new List<GameObject>());
            for (int j = 0; j < BlockWidth; j++)
            {
                arrBinary[j,i] = "0";
                //tileMap.gameObject.name += (++aa).ToString();
                Tile[i].Add(Instantiate(tileMap, new Vector3(-1.65f + 0.14f * j, 0.85f - i * 0.14f,0), Quaternion.Euler(0, 0, 0)));
				Tile[i][j].name = (TileNumber++).ToString();
                Tile[i][j].transform.parent = MapBackGround.transform;
			}
		}
		// Debug.Log(Tile.Count);
		// Debug.Log(Tile[0].Count);

        sp = Tile[0][0].GetComponentInChildren<SpriteRenderer>().sprite;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(arrBinary[0,0]);
        //Debug.Log(arrBinary[16,12]);
	}

    public void ArrayInputNumber(int x, int y)
    {
        Debug.Log("X: " + x);
        Debug.Log("Y: " + y);
        arrBinary[x,y] = CurrentTileNumber;
    }

    public void WriteData(string strData)
    {
        FileStream  file = new FileStream("MapData.h", FileMode.Create, FileAccess.Write);

        StreamWriter writer = new StreamWriter(file, System.Text.Encoding.Unicode);

        writer.WriteLine(strData);

        writer.Close();
    }

    void SaveData()
    {
        string strData = "";
        strData = "int mapData[13][17] =\n{";
        for (int i = 0; i < BlockHeight; i++)
        {
            strData += "{ ";
            for (int j = 0; j < BlockWidth; j++)
            {
                strData += arrBinary[j,i];
                if (j + 1 != BlockWidth)
                {
                    strData += ", ";
                }
            }
            strData += "}";
            if (i + 1 != BlockHeight)
            {
                
                strData += ",\n";
            }
        }
        strData += "};";
        Debug.Log(strData);
        WriteData(strData);
    }

    void ResetBlock()
    {
        for (int i = 0; i < BlockHeight; i++)
        {
            for (int j = 0; j < BlockWidth; j++)
            {
				Tile[i][j].GetComponentInChildren<SpriteRenderer>().sprite = ResetBlockSp;
			}
		}
    }
}
