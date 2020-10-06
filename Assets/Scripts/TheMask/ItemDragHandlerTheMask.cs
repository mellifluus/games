using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandlerTheMask : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler {

	TheMaskLogic GetVal;
	int checkchange;
	Vector3 collp, collg;

	void Start () 
	{
		GetVal = gameObject.transform.parent.gameObject.GetComponent<TheMaskLogic>();
		checkchange = GetVal.countmaschere;
		collp = new Vector3 (1.6f, 1.3f, 0);
		collg = new Vector3 (5f, 3f, 0);
	}
	
	void Update () 
	{
		if(GetVal.countmaschere!=checkchange)
		{
			ResetMaschera();
			checkchange = GetVal.countmaschere;
		}
	}


	public void OnBeginDrag(PointerEventData eventData)
	{
		if (gameObject.GetComponent<SpriteRenderer>().sortingOrder == 1)
		{
			ReplaceBig();
			ResetMaschera();
			gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
			gameObject.GetComponent<BoxCollider2D>().size = collg;
		}
	}

	public void OnDrag(PointerEventData eventData)
	{
		Vector3 screenPos = Input.mousePosition;
        screenPos.z = 10.0f;
        transform.position = Camera.main.ScreenToWorldPoint(screenPos);
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		pos.z = 0;
		if(GetVal.BambiniRenderer.GetComponent<BoxCollider2D>().bounds.Contains(pos))
		{
			transform.position = GetVal.Snap.transform.position;
			GetVal.playsound = (gameObject.name[8] & 0x0f) - 1;
		}
		else
		{
			ReplaceSmall();
			Reset();
		}
		
	}

	void ReplaceSmall()
	{
		int c = gameObject.name[8] & 0x0f;
		c += GetVal.countmaschere - 1;
		gameObject.GetComponent<SpriteRenderer>().sprite = GetVal.MaschereP[c];
	}

	void ReplaceBig()
	{
		int c = gameObject.name[8] & 0x0f;
		c += GetVal.countmaschere - 1;
		gameObject.GetComponent<SpriteRenderer>().sprite = GetVal.MaschereG[c];
	}

	void Reset()
	{
		int c = gameObject.name[8] & 0x0f;
		if(c == 1)
		{
			transform.position = new Vector3(-3.71f, -3.24f, 0);
		}
		else if(c == 2)
		{
			transform.position = new Vector3(-1.86f, -3.24f, 0);
		}
		else if(c == 3)
		{
			transform.position = new Vector3(-0.01f, -3.24f, 0);
		}
		else if(c == 4)
		{
			transform.position = new Vector3(1.85f, -3.24f, 0);
		}
		else if(c == 5)
		{
			transform.position = new Vector3(3.71f, -3.24f, 0);
		}
		gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
		gameObject.GetComponent<BoxCollider2D>().size = collp;
	}

	void ResetMaschera()
	{
		GameObject[] maschere = GameObject.FindGameObjectsWithTag("Mask");
		foreach(var m in maschere)
		{
			if (m.GetComponent<SpriteRenderer>().sortingOrder == 2)
			{
				int c = m.name[8] & 0x0f;
				if(c == 1)
				{
					m.transform.position = new Vector3(-3.71f, -3.24f, 0);
				}
				else if(c == 2)
				{
					m.transform.position = new Vector3(-1.86f, -3.24f, 0);
				}
				else if(c == 3)
				{
					m.transform.position = new Vector3(-0.01f, -3.24f, 0);
				}
				else if(c == 4)
				{
					m.transform.position = new Vector3(1.85f, -3.24f, 0);
				}
				else if(c == 5)
				{
					m.transform.position = new Vector3(3.71f, -3.24f, 0);
				}
			c += GetVal.countmaschere - 1;
			m.GetComponent<SpriteRenderer>().sprite = GetVal.MaschereP[c];
			m.GetComponent<SpriteRenderer>().sortingOrder = 1;
			m.GetComponent<BoxCollider2D>().size = collp;
			}
		}
	}

}
