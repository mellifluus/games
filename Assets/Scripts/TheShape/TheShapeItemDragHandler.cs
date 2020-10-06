using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TheShapeItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler {

	TheShapeLogic GetVal;
	
	void Start () {
		GetVal = gameObject.transform.parent.gameObject.GetComponent<TheShapeLogic>();
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
        foreach(GameObject s in GameObject.FindGameObjectsWithTag("Dragging"))
        {
            s.GetComponent<TheShapeItemDragHandler>().Reset();
        }
        gameObject.tag = "Dragging";
		ReplaceBig();
	}

	public void OnDrag(PointerEventData eventData)
	{
		Vector3 screenPos = Input.mousePosition;
        screenPos.z = 10.0f;
        transform.position = Camera.main.ScreenToWorldPoint(screenPos);
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
		int c = gameObject.name[5] & 0x0f;
		c += GetVal.countforme - 1;
		Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		pos.z = 0;
		if(GetVal.Buco.GetComponent<BoxCollider2D>().bounds.Contains(pos))
		{
			if(c == GetVal.nbuco)
			{
				Instantiate(GetVal.FormeS[c], GetVal.Buco.transform.position, Quaternion.identity);
				GetVal.next = true;
				GetVal.Buco.GetComponent<AudioSource>().clip = GetVal.FormaOk;
				GetVal.Buco.GetComponent<AudioSource>().Play();
				ReplaceSmall();
				Reset();
			}
			else
			{
				GetVal.Buco.GetComponent<AudioSource>().clip = GetVal.FormaNo;
				GetVal.Buco.GetComponent<AudioSource>().Play();
				ReplaceSmall();
				Reset();
			}
		}
		else
		{
			ReplaceSmall();
			Reset();
		}
	}

	void ReplaceSmall()
	{
		int c = gameObject.name[5] & 0x0f;
		c += GetVal.countforme - 1;
		gameObject.GetComponent<SpriteRenderer>().sprite = GetVal.IconeF[c];
	}

	void ReplaceBig()
	{
		int c = gameObject.name[5] & 0x0f;
		c += GetVal.countforme - 1;
		gameObject.GetComponent<SpriteRenderer>().sprite = GetVal.Forme[c];
	}

	void Reset()
	{
		int c = gameObject.name[5] & 0x0f;
		if(c == 1)
		{
			transform.position = new Vector3(-4.144f, -3f, 0);
		}
		else if(c == 2)
		{
			transform.position = new Vector3(-2.484f, -3f, 0);
		}
		else if(c == 3)
		{
			transform.position = new Vector3(-0.824f, -3f, 0);
		}
		else if(c == 4)
		{
			transform.position = new Vector3(0.844f, -3f, 0);
		}
		else if(c == 5)
		{
			transform.position = new Vector3(2.504f, -3f, 0);
		}
		else if(c == 6)
		{
			transform.position = new Vector3(4.164f, -3f, 0);
		}
		gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
        gameObject.tag = "Untagged";
	}
}
