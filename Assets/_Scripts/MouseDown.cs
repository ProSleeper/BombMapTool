using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseDown : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseEnter()
	{
		if (Input.GetMouseButton(0))
		{
			Debug.Log(this.gameObject.name);
			this.gameObject.GetComponentInChildren<SpriteRenderer>().sprite = MapManager.Instance.sp;
		}
	}
	void OnMouseDown()
	{
		Debug.Log(this.gameObject.name);
		this.gameObject.GetComponentInChildren<SpriteRenderer>().sprite = MapManager.Instance.sp;
	}
}
