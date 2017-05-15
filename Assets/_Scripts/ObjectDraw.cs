using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectDraw : MonoBehaviour
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
            int.TryParse(this.gameObject.name, out nameInt);
            arrNumberX = nameInt / 17;
            arrNumberY = nameInt % 17;
            if(!MapManager.Instance.arrMap[arrNumberY, arrNumberX].IsMove)
            {
                return;
            }
            //Debug.Log(this.gameObject.name);
            this.gameObject.GetComponentInChildren<SpriteRenderer>().sprite = ObjectManager.Instance.sp;
            
            ObjectManager.Instance.ArrayInputNumber(arrNumberY, arrNumberX);
        }
    }
	
    void OnMouseDown()
    {
        int.TryParse(this.gameObject.name, out nameInt);
        arrNumberX = nameInt / 17;
        arrNumberY = nameInt % 17;
        if (!MapManager.Instance.arrMap[arrNumberY, arrNumberX].IsMove)
        {
            return;
        }
        //Debug.Log(this.gameObject.name);
        this.gameObject.GetComponentInChildren<SpriteRenderer>().sprite = ObjectManager.Instance.sp;
        ObjectManager.Instance.ArrayInputNumber(arrNumberY, arrNumberX);
    }
}
