using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandlerOmbreTerrificanti : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler {

	GameLogicOmbreTerrificanti GetVal;
	Vector2 startPos;
	
	void Start () 
	{
		GetVal = gameObject.transform.parent.gameObject.GetComponent<GameLogicOmbreTerrificanti>();
		startPos = transform.position;
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		ReplaceBig();
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
		int c;
		if (gameObject.name.Length == 6)
		{
			c = gameObject.name[5] & 0x0f;
		}
		else
		{
			c = gameObject.name[6] & 0x0f;
			c += 10;
		}
		c -= 1;
		Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		pos.z = 0;
		if(GetVal.Ombra.GetComponent<BoxCollider2D>().bounds.Contains(pos))
		{
			if(c == GetVal.nombra)
			{
				ReplaceSmall();
				transform.position = startPos;
				gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0;
				GetVal.suonocheck = 0;
				StartCoroutine(Win());
			}
			else
			{
				ReplaceSmall();
				transform.position = startPos;
				gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0;
				GetVal.suonocheck = 1;
				GetVal.RedLight.SetTrigger("Light");
			}
		}
		else
		{
			ReplaceSmall();
			transform.position = startPos;
			gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0;
		}
	}

	void ReplaceBig()
	{
		int c;
		if (gameObject.name.Length == 6)
		{
			c = gameObject.name[5] & 0x0f;
		}
		else
		{
			c = gameObject.name[6] & 0x0f;
			c += 10;
		}
		c -= 1;
		gameObject.GetComponent<SpriteRenderer>().sprite = GetVal.MostriBig[c];
	}

	void ReplaceSmall()
	{
		int c;
		if (gameObject.name.Length == 6)
		{
			c = gameObject.name[5] & 0x0f;
		}
		else
		{
			c = gameObject.name[6] & 0x0f;
			c += 10;
		}
		c -= 1;
		gameObject.GetComponent<SpriteRenderer>().sprite = GetVal.MostriSmall[c];
	}

	void StopInteractability()
	{
		foreach(var c in GetVal.Colliders)
		{
			c.enabled = false;
		}
	}

	void StartInteractability()
	{
		foreach(var c in GetVal.Colliders)
		{
			c.enabled = true;
		}
	}

	IEnumerator Win()
	{
		GetVal.Ombra.sprite = GetVal.MostriBig[GetVal.nombra]; 
		GetVal.GreenLight.SetTrigger("Light");
		StopInteractability();
		yield return new WaitForSeconds(1.5f);
		GetVal.nombra = Random.Range(0, 15);
		GetVal.Ombra.sprite = GetVal.Ombre[GetVal.nombra];
		StartInteractability(); 
	}
}
