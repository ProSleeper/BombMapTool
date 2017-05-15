using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectManager : MonoBehaviour
{

    const int BlockWidth = 17;
    const int BlockHeight = 13;

    List<List<GameObject>> Tile = new List<List<GameObject>>();

    string[,] arrObject = new string[17, 13];
    
    public Button ResetObject;

    public Button saveData;
    public List<Button> TileButton;
    public Sprite ResetBlockSp;
    [HideInInspector]
    public Sprite sp;
    public GameObject CurSprite;
    public GameObject ObjectBackGround;
    public string CurrentTileNumber;

    private static ObjectManager _instance = null;

    public static ObjectManager Instance
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
        saveData.onClick.AddListener(SaveData);
        ResetObject.onClick.AddListener(ResetBlock);

        ObjectInit();
    }

    void ObjectInit()
    {
        int TileNumber = 0;
        GameObject tileMap = Resources.Load("Object") as GameObject;
        CurrentTileNumber = "0";
        for (int i = 0; i < BlockHeight; i++)
        {
            Tile.Add(new List<GameObject>());
            for (int j = 0; j < BlockWidth; j++)
            {
                arrObject[j, i] = "0";
                Tile[i].Add(Instantiate(tileMap, new Vector3(-1.65f + 0.14f * j, 0.85f - i * 0.14f, -3), Quaternion.Euler(0, 0, 0)));
                Tile[i][j].name = (TileNumber++).ToString();
                Tile[i][j].transform.parent = ObjectBackGround.transform;
            }
        }

        sp = Tile[0][0].GetComponentInChildren<SpriteRenderer>().sprite;
    }

    
    public void ArrayInputNumber(int x, int y)
    {
        arrObject[x, y] = CurrentTileNumber;
    }

    void SaveData()
    {
        //맵 정보
        string strData = "";
        strData = "int MapData[13][17] =\n{";
        for (int i = 0; i < BlockHeight; i++)
        {
            strData += "{ ";
            for (int j = 0; j < BlockWidth; j++)
            {
                strData += MapManager.Instance.arrMap[j, i].Map;
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

        WriteData(strData, "MapData.h");

        //오브젝트 정보
        strData = "int objectData[13][17] =\n{";
        for (int i = 0; i < BlockHeight; i++)
        {
            strData += "{ ";
            for (int j = 0; j < BlockWidth; j++)
            {
                strData += arrObject[j, i];
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
        WriteData(strData, "ObjectData.h");
    }

    public void WriteData(string strData, string path)
    {
        FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write);

        StreamWriter writer = new StreamWriter(file, System.Text.Encoding.Unicode);

        writer.WriteLine(strData);

        writer.Close();
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
