using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandlerRiciclando : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler {

	Vector3 startPos;
	RiciclandoLogic val;
	public GameObject Pof;
	public AudioSource Suono;
	public AudioClip corretto, errore, inserisco;
	public SpriteRenderer si, no;
	
	void Start () 
	{
		startPos = transform.position;
		val = transform.parent.gameObject.GetComponent<RiciclandoLogic>();
	}
	
	void Update () 
	{
		
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		
	}

	public void OnDrag(PointerEventData eventData)
	{
		Vector3 screenPos = Input.mousePosition;
        screenPos.z = 10.0f;
        transform.position = Camera.main.ScreenToWorldPoint(screenPos);
		float scaleval = Mathf.Lerp(100, 40, Mathf.InverseLerp(145.0f, -170.0f, transform.localPosition.y));
		transform.localScale = new Vector3(scaleval, scaleval, scaleval);
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		RaycastHit2D ray = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay (Input.mousePosition), 100f, 1 << 10);
		if(ray)
		{
			if(ray.transform.gameObject.name[0] == gameObject.GetComponent<SpriteRenderer>().sprite.name[0])
			{
				StartCoroutine(EndOfDrag(1, ray.transform.gameObject));
			}
			else
			{
				StartCoroutine(EndOfDrag(0, ray.transform.gameObject));
			}
		}
		else
		{
			transform.position = startPos;
			transform.localScale = new Vector3(100, 100, 100);
		}
	}

	IEnumerator EndOfDrag(int a, GameObject b)
	{
		gameObject.GetComponent<BoxCollider2D>().enabled = false;
		if(a == 1)
		{
			Suono.Play();
			var tempinst1 = Instantiate(Pof, b.transform.position, Quaternion.identity);
			Destroy(tempinst1, tempinst1.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
			gameObject.GetComponent<SpriteRenderer>().sprite = null;
			transform.position = startPos;
			transform.localScale = new Vector3(100, 100, 100);
			yield return new WaitForSeconds(0.8f);
			Suono.clip = corretto;
			Suono.Play();
			BarraPuntiRiciclando.punteggio += 1;
			si.color += new Color (0, 0, 0, 195);
			yield return new WaitForSeconds(1.5f);
			si.color -= new Color (0, 0, 0, 195);
		}
		else
		{
			Suono.Play();
			var tempinst2 = Instantiate(Pof, b.transform.position, Quaternion.identity);
			Destroy(tempinst2, tempinst2.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
			gameObject.GetComponent<SpriteRenderer>().sprite = null;
			transform.position = startPos;
			transform.localScale = new Vector3(100, 100, 100);
			yield return new WaitForSeconds(0.8f);
			Suono.clip = errore;
			Suono.Play();
			no.color += new Color (0, 0, 0, 195);
			yield return new WaitForSeconds(1.5f);
			no.color -= new Color (0, 0, 0, 195);
		}
		yield return new WaitForSeconds(0.2f);
		if(!BarraPuntiRiciclando.Win)
		{
			val.next = true;
			gameObject.GetComponent<BoxCollider2D>().enabled = true;
			yield return new WaitForSeconds(0.8f);
			Suono.clip = inserisco;
		}
	}
}
