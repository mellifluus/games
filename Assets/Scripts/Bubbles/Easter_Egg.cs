using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Easter_Egg : MonoBehaviour {

	public int counte;
    public GameObject EasterEgg;

	void Start () 
	{
		counte = 0;
	}
	
	void Update()
    {
        if(counte == 25)
        {
            var tempe = Instantiate(EasterEgg, new Vector2(0, 0), Quaternion.identity);
            Destroy(tempe, 10);
			counte = 0;
        }
    }
}
