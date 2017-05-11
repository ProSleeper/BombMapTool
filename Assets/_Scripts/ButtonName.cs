﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonName : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		Button btn = this.gameObject.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void TaskOnClick()
    {
		Debug.Log(this.gameObject.name);
		MapManager.Instance.sp = this.gameObject.GetComponent<Image>().sprite;
    }

}
