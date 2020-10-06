using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitterDuckieBoom : MonoBehaviour {

	Animator anim;
	AudioSource Suono;
	bool cliccato;
	public GameObject Hit;
	
	void Start()
	{
		Suono = gameObject.GetComponent<AudioSource>();
		anim = gameObject.GetComponent<Animator>();
		Suono.volume *= PlayerPrefs.GetFloat("VolFX", 0.6f);
	}

	void Update()
	{
		if (cliccato)
		{
			transform.Translate(new Vector2(0, -2) * 1f * Time.deltaTime);
		}
	}
	
	void OnMouseDown()
	{
		if (!cliccato)
		{
			if(!BarraPuntiDuckieBoom.Win)
			{	
				cliccato = true;
				Suono.Play();
				var tempHit = Instantiate(Hit, transform.position, Quaternion.identity);
				anim.SetTrigger("Hit");
				Destroy(tempHit, tempHit.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
				Destroy(gameObject, 2);
				BarraPuntiDuckieBoom.punteggio += 2;
			}
		}
	}	
}