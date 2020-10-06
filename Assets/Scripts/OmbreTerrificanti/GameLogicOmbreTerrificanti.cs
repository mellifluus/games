using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogicOmbreTerrificanti : MonoBehaviour {

	public Sprite[] Ombre, MostriBig, MostriSmall;
	public SpriteRenderer[] Icone;
	public Collider2D[] Colliders;
	public SpriteRenderer Ombra;
	public Animator GreenLight, RedLight;
	public AudioSource Suono;
	public AudioClip[] s;
	public int nombra, suonocheck;
	
	void Start () 
	{
		nombra = Random.Range(0, 15);
		Ombra.sprite = Ombre[nombra];
		suonocheck = -1;
	}

	void Update()
	{
		if(suonocheck != -1)
		{
			Suono.clip = s[suonocheck];
			Suono.Play();
			suonocheck = -1;
		}
	}
}
