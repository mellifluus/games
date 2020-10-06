using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MemoryClick : MonoBehaviour {

	Animator anim;
	AudioSource Suono;
	public int state = 0;
	
	void Start () {
		anim = gameObject.GetComponent<Animator>();
		Suono = gameObject.GetComponent<AudioSource>();
		Suono.volume *= PlayerPrefs.GetFloat("VolFX", 0.6f);
	}
	
	void Update () 
	{
		if(state==2)
		{
			state = 0;
			anim.SetTrigger("Reverse");
			Invoke("ResetReverse", anim.GetCurrentAnimatorStateInfo(0).length);
		}
	}
	
	void OnMouseDown()
	{
		if (state==0 && MemoryLogic.DONOT==false && MemoryLogic.i!=2)
		{
			MemoryLogic.i++;
			Suono.Play();
			if(MemoryLogic.i==2)
			{
				MemoryLogic.DONOT=true;
				state = 1;
				anim.SetTrigger("Enable");
				StartCoroutine(waiter());
			}else
			{
				state = 1;
				anim.SetTrigger("Enable");
			}
		}
	}

	void ResetReverse()
	{
		anim.ResetTrigger("Enable");
		anim.ResetTrigger("Reverse");
		MemoryLogic.DONOT = false;
	}
	
	IEnumerator waiter()
	{
    	yield return new WaitForSeconds(1);
		MemoryLogic.CheckCard();
	}
}