using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheShapeScorrimento : MonoBehaviour {

	TheShapeLogic GetVal;
	float timer;
	public float time;
	Vector3 nextStart, bucoStart, finalPos;
	public Transform final;

	void Start () 
	{
		GetVal = gameObject.transform.parent.gameObject.GetComponent<TheShapeLogic>();
		nextStart = gameObject.transform.position;
		bucoStart = GetVal.Buco.transform.position;
		finalPos = final.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(GetVal.startscorri && !BarraPuntiTheShape.Win)
		{
			timer += Time.deltaTime;
			transform.position = Vector3.Lerp(nextStart, bucoStart, timer/time);
			GetVal.Buco.transform.position = Vector3.Lerp(bucoStart, finalPos, timer/time);
			GetVal.tempinst.transform.position = Vector3.Lerp(bucoStart, finalPos, timer/time);	
		}
		if (timer >= 3)
		{
			GetVal.Buco.sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
			GetVal.Buco.transform.position = bucoStart;
			gameObject.transform.position = nextStart;
			Destroy(GetVal.tempinst);
			GetVal.startscorri = false;
			timer = 0;
			EnableColliders();
		}
	}

	void EnableColliders()
	{
		foreach(var i in GetVal.Icone)
		{
			i.GetComponent<BoxCollider2D>().enabled = true;
		}
	}
}
