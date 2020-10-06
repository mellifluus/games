using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RiciclandoLogic : MonoBehaviour {

	public Sprite[] Oggetti;
	SpriteRenderer Oggetto;
	int[] doppioni = new int[50];
	int i = 0;
	public bool next = false;
	
	void Start () 
	{
		Oggetto = gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
		Oggetto.sprite = Oggetti[RandomGen()];
	}

	void Update () 
	{
		if (i == 47)
		{
			doppioni = new int[50];
			i = 0;
		}
		if (next)
		{
			Oggetto.sprite = Oggetti[RandomGen()];
			next = false;
		}
	}

	int RandomGen()
	{
		int n = UnityEngine.Random.Range(0, 48);
		while (doppioni.Contains(n))
		{
			n = UnityEngine.Random.Range(0, 48);
		}
		doppioni[i] = n;
		i++;
		return n;
	}
}
