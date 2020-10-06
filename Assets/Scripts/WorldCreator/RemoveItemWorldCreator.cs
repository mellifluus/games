using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class RemoveItemWorldCreator : MonoBehaviour, IPointerDownHandler{

	public GameObject A, B, C;
	public AudioSource Suono;
	public GameObject NascitaInv;

	public void OnPointerDown (PointerEventData eventData) 
    {
		if(gameObject.GetComponent<SpriteRenderer>().sprite != null)
		{
			gameObject.GetComponent<SpriteRenderer>().sprite = null;
			int p = (Int32.Parse(gameObject.name[0].ToString()) * 10) + Int32.Parse(gameObject.name[1].ToString());
			GameObject temp = null;
			if(gameObject.name[2] == 'A')
			{
				temp = A.transform.GetChild(p).gameObject;
			}
			else if(gameObject.name[2] == 'B')
			{
				temp = B.transform.GetChild(p).gameObject;
			}
			else if(gameObject.name[2] == 'C')
			{
				temp = C.transform.GetChild(p).gameObject;
			}
			Suono.Play();
			var tmp = Instantiate(NascitaInv, temp.transform.position, Quaternion.identity);
			Destroy(tmp, tmp.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
			StartCoroutine(FadeOut(temp));
		}
    }

	IEnumerator FadeOut(GameObject temp)
	{
		Color tmpcol;
		float i = 1;
		while(i >= 0)
		{
			tmpcol = temp.GetComponent<SpriteRenderer>().color;
			tmpcol.a = i;
			temp.GetComponent<SpriteRenderer>().color = tmpcol;
			i -= 0.1f;	
			yield return new WaitForSeconds(0.05f);
		}
		tmpcol = temp.GetComponent<SpriteRenderer>().color;
		tmpcol.a = 0;
		temp.GetComponent<SpriteRenderer>().color = tmpcol;
		temp.GetComponent<SpriteRenderer>().sprite = null;
	}
}
