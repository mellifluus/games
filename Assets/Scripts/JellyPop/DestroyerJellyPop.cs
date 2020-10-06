using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerJellyPop : MonoBehaviour
{
	
	AudioSource SuonoEsplodo;
	bool clicked = false;
	bool late = false;

	void Start()
	{
		SuonoEsplodo = gameObject.GetComponent<AudioSource>();
		SuonoEsplodo.volume *= PlayerPrefs.GetFloat("VolFX", 0.6f);
	}
	
	void OnMouseDown()
	{
		if (!clicked && !late && !BarraPuntiJellyPop.Win)
		{
			clicked = true;
			gameObject.GetComponent<Animator>().SetTrigger("Pop");
			Destroy(gameObject, gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
			SuonoEsplodo.Play();
			BarraPuntiJellyPop.punteggio+=2;
		}
	}

	void setLate()
	{
		late = true;
	}
}
