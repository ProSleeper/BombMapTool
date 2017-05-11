using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseDown : MonoBehaviour
{

    int nameInt;
    int arrNumberX;
    int arrNumberY;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseEnter()
    {
        if (Input.GetMouseButton(0))
        {
            //Debug.Log(this.gameObject.name);
            this.gameObject.GetComponentInChildren<SpriteRenderer>().sprite = MapManager.Instance.sp;
            int.TryParse(this.gameObject.name, out nameInt);
            arrNumberX = nameInt / 17;
            arrNumberY = nameInt % 17;
            MapManager.Instance.ArrayInputNumber(arrNumberY, arrNumberX);
        }
    }
	
    void OnMouseDown()
    {
        //Debug.Log(this.gameObject.name);
        this.gameObject.GetComponentInChildren<SpriteRenderer>().sprite = MapManager.Instance.sp;
        int.TryParse(this.gameObject.name, out nameInt);
        arrNumberX = nameInt / 17;
        arrNumberY = nameInt % 17;
        MapManager.Instance.ArrayInputNumber(arrNumberY, arrNumberX);
    }
}
