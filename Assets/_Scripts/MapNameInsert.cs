using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapNameInsert : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

        Button btn = this.gameObject.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void TaskOnClick()
    {
        Debug.Log(this.gameObject.name);
        MapManager.Instance.sp = this.gameObject.GetComponent<Image>().sprite;
        MapManager.Instance.CurrentTileNumber = this.gameObject.name;
        MapManager.Instance.CurSprite.GetComponent<SpriteRenderer>().sprite = this.gameObject.GetComponent<Image>().sprite;
    }

}
