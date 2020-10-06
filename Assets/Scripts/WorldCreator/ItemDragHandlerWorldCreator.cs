using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class ItemDragHandlerWorldCreator : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler {

	Vector3 startPos;
	public GameObject A, B, C;
	public Sprite[] SpriteA, SpriteB, SpriteC;
	SpriteRenderer temp;
	public AudioSource Suono;
	public GameObject Nascita;

	void Start () 
	{
		startPos = transform.position;
    }

	public void OnBeginDrag(PointerEventData eventData)
	{
		gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
	}

	public void OnDrag(PointerEventData eventData)
	{
		Vector3 screenPos = Input.mousePosition;
        screenPos.z = 10.0f;
        transform.position = Camera.main.ScreenToWorldPoint(screenPos);
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		transform.position = startPos;
		gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0;
		RaycastHit2D ray = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay (Input.mousePosition));
		if(ray.transform.gameObject.name[0] != 'I' && gameObject.name[5]==ray.transform.gameObject.name[2])
		{
			ray.transform.gameObject.GetComponent<SpriteRenderer>().sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
			int p = ((Int32.Parse(ray.transform.gameObject.name[0].ToString()) * 10) + Int32.Parse(ray.transform.gameObject.name[1].ToString()));
			Project(p);
		}
	}

	void Project(int posplocale)
	{
		
		int indp = (Int32.Parse(gameObject.name[6].ToString()) * 10) + Int32.Parse(gameObject.name[7].ToString());
		if(gameObject.name[5] == 'A')
		{
			temp = A.transform.GetChild(posplocale).gameObject.GetComponent<SpriteRenderer>();
			temp.sprite = SpriteA[indp];
		}
		else if(gameObject.name[5] == 'B')
		{
			temp = B.transform.GetChild(posplocale).gameObject.GetComponent<SpriteRenderer>();
			temp.sprite = SpriteB[indp];
		}
		else if(gameObject.name[5] == 'C')
		{
			temp = C.transform.GetChild(posplocale).gameObject.GetComponent<SpriteRenderer>();
			temp.sprite = SpriteC[indp];
		}
		Suono.Play();
		var tempinst = Instantiate(Nascita, temp.transform.position, Quaternion.identity);
		Destroy(tempinst, tempinst.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
		StartCoroutine(FadeIn(temp));
	}

	IEnumerator FadeIn(SpriteRenderer temp)
	{
		Color tmp;
		float i = 0;
		while(i <= 1)
		{
			tmp = temp.color;
			tmp.a = i;
			temp.color = tmp;
			i += 0.1f;	
			yield return new WaitForSeconds(0.05f);
		}
		tmp = temp.color;
		tmp.a = 1;
		temp.color = tmp;
	}
}
