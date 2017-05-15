using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwapUI : MonoBehaviour {

    public GameObject mapSwap;
    public GameObject mapBackGround;

    public GameObject objectSwap;
    public GameObject objectBackGround;

    bool IsOnMap;


    // Use this for initialization
    void Start () {
        this.gameObject.GetComponent<Button>().onClick.AddListener(MapAndObjectClick);

        IsOnMap = true;

        mapSwap.SetActive(true);
        mapBackGround.SetActive(true);

        objectSwap.SetActive(false);
        objectBackGround.SetActive(false);
    }

    void MapAndObjectClick()
    {
        if (IsOnMap)
        {
            objectSwap.SetActive(true);
            objectBackGround.SetActive(true);

            mapSwap.SetActive(false);
            IsOnMap = false;
            return;
        }

        objectSwap.SetActive(false);
        objectBackGround.SetActive(false);

        mapSwap.SetActive(true);
        IsOnMap = true;
    }
}
