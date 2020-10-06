using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnPos : MonoBehaviour {

	Vector2 startPos;
	public bool returnpos;
	public int val;
	
	void Start () 
	{
		startPos = transform.position;	
		returnpos = false;
	}
	
	void Update () 
	{
		if(returnpos)
		{
			transform.position = startPos;
			returnpos = false;
		}
	}
}
