using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerDuckieBoom : MonoBehaviour {

	public GameObject[] Items;
	public Collider2D[] colliders;
	float delay, timer;
	private float x, y;
    private int order, a;
    bool flip = false;
    float c;
	
	void Start()
	{
		delay = 0.3f;
		timer = delay;
	}
	
	void Update()
	{
		if(!BarraPuntiDuckieBoom.Win)
		{
			timer -= Time.deltaTime;
			if (timer <= 0)
			{
                c = Random.value;
				if (c <= 0.25)
				{
					x = Random.Range(6.4f, -2.5f);
                    y = -3.55f;
					order = 6;
                    flip = false;
				}
				else if(c > 0.25 && c <= 0.5)
				{
					x = Random.Range(-6.4f, 2.5f);
                    y = -2.45f;
					order = 4;
                    flip = true;
				}
                else if(c > 0.5 && c <= 0.75)
				{
					x = Random.Range(6.4f, -2.5f);
                    y = -1.35f;
					order = 2;
                    flip = false;
				}
                else if(c > 0.75 && c <= 1)
				{
					x = Random.Range(-6.4f, 2.5f);
                    y = -0.3f;
					order = 0;
                    flip = true;
				}
				Vector3 itemPos = new Vector3(x, y, 0);
				colliders=Physics2D.OverlapCircleAll(itemPos, 1f);
                if (colliders.Length == 0)
				{
                	a = Random.Range(0, 2);
					var tempobj=Instantiate(Items[a], itemPos, transform.rotation);
					tempobj.GetComponent<SpriteRenderer>().sortingOrder = order;
                	if (flip)
                	{
                    	tempobj.GetComponent<SpriteRenderer>().flipX = true;
                	}
				}
				timer = delay;
			}
		}
	}
}
