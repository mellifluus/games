using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OndeMovement : MonoBehaviour {

	public float speed;
	private int a;
	private float timer=0;
	
	void Start ()
	{
		if (gameObject.name == "Onda1" || gameObject.name == "Onda3")
		{
			a = -1;
		}
		else if (gameObject.name == "Onda2" || gameObject.name == "Onda4")
		{
			a = 1;
		}
	}

	void Update()
	{
		if (timer >= 4)
		{
			a = -a;
			timer = 0;
		}
		timer += Time.deltaTime;
		transform.Translate(new Vector2(a, 0) * speed * Time.deltaTime);
	}
}