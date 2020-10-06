using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolleInstantiate : MonoBehaviour {

	public GameObject[] Bolle;
    public Collider2D[] colliders;
    public float delay, timer;
    float scaleval;

    void Start () 
    {
        delay = 0.1f;
        timer = delay;
	}

    void Update ()
    {
		if (BarraPuntiBolle.Win == false)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                scaleval = Random.Range(0.4f, 0.7f);
                Vector3 bollaPos = new Vector3(Random.Range(-5.2f, 5.2f), Random.Range(-11f, -5.7f), 10f);
                colliders=Physics2D.OverlapCircleAll(bollaPos, 1f);
                if (colliders.Length == 0)
                {
                    int r = Random.Range(0, 10);
					var tempobj = Instantiate(Bolle[r], bollaPos, transform.rotation);
                    tempobj.transform.localScale = new Vector3(scaleval, scaleval, 1);
                }        
                delay = 0.1f;
                timer = delay;
            }
       }
    }
}
