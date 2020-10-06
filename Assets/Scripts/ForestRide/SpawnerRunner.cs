using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerRunner : MonoBehaviour {

	float timer, delay, minval, maxval;
	public GameObject[] spawns;
	Vector3 newPos;
	
	void Start () 
	{
		delay = 0.1f;
		timer = delay;
		minval = 0f;
		maxval = 0f;
		CheckChar();
	}
	
	void Update () 
	{
		timer -= Time.deltaTime;
		if(timer <= 0 && !BarraPuntiForestRide.Win)
		{
			var tempd = Instantiate(spawns[Random.Range(0, 5)], newPos, Quaternion.identity);
			tempd.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
			delay = Random.Range(1f, 3f);
			timer = delay;
			newPos.y = Random.Range(minval, maxval);
		}
	}

	void CheckChar()
	{
		if(minval == 0f)
		{
			char check = GameObject.FindWithTag("Runner").name[0];
			if(check == 'C')
			{
				gameObject.transform.GetChild(0).position = new Vector2(9.5f, -0.2f);
			}
			else if(check == 'E' || check == 'G')
			{
				gameObject.transform.GetChild(0).position = new Vector2(9.5f, 0.3f);
			}
			else if(check == 'I')
			{
				gameObject.transform.GetChild(0).position = new Vector2(9.5f, 0f);
			}
			else if(check == 'L')
			{
				gameObject.transform.GetChild(0).position = new Vector2(9.5f, 0.15f);
			}
			minval = gameObject.transform.GetChild(0).position.y; 	
			maxval = gameObject.transform.GetChild(0).position.y + 1.75f; 
			newPos = new Vector3(gameObject.transform.GetChild(0).position.x, Random.Range(minval, maxval), gameObject.transform.GetChild(0).position.z);
		}		
	}
}
