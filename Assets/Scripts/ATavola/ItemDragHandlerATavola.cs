using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDragHandlerATavola : MonoBehaviour {

	GameObject[] beingDragged = new GameObject[5];
	bool[] check = new bool[5];
	RaycastHit2D ray;
	Vector3 pos;
	Touch touch;
	TouchPhase phase;
	public AudioSource Suono;
	public GameObject Pof;

	void Start () 
	{

	}
	
	void Update ()
    {
        int ntouches = Input.touchCount;
		if(ntouches > 0)
		{
			for(int i = 0; i < ntouches; i++)
			{
				touch = Input.GetTouch(i);
				phase = touch.phase;
				switch(phase)
                {
            		case TouchPhase.Began:
               			ray = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay (touch.position), 100f, 1 << 9);
						if(ray)
						{
							check[touch.fingerId] = true;
							beingDragged[touch.fingerId] = ray.transform.gameObject;
							beingDragged[touch.fingerId].GetComponent<SpriteRenderer>().sortingOrder = 1;
						}
						else
						{
							check[touch.fingerId] = false;
						}
               			break;

            		case TouchPhase.Moved:
						if(check[touch.fingerId])
						{
							pos = touch.position;
							pos.z = 10f;
							beingDragged[touch.fingerId].transform.position = Camera.main.ScreenToWorldPoint(pos);
						}
               			break;

            		case TouchPhase.Stationary:
						if(check[touch.fingerId])
						{
							pos = touch.position;
							pos.z = 10f;
							beingDragged[touch.fingerId].transform.position = Camera.main.ScreenToWorldPoint(pos);
						}
               			break;

            		case TouchPhase.Ended:
						if(check[touch.fingerId])
						{
							ray = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay (touch.position), 100f, 1 << 8);
							if(ray)
							{
								if(!ray.transform.gameObject.GetComponent<LogicPiatti>().counting)
								{
									int val = beingDragged[touch.fingerId].GetComponent<ReturnPos>().val;
									var tempinst = Instantiate(Pof, beingDragged[touch.fingerId].transform.position, Quaternion.identity);
									Destroy(tempinst, tempinst.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
									Destroy(beingDragged[touch.fingerId]);
									beingDragged[touch.fingerId] = null;
									Suono.Play();
									ray.transform.gameObject.GetComponent<LogicPiatti>().score += val;
								}
								else
								{
									beingDragged[touch.fingerId].GetComponent<ReturnPos>().returnpos = true;
									beingDragged[touch.fingerId].GetComponent<SpriteRenderer>().sortingOrder = 0;
								}
							}
							else
							{
								beingDragged[touch.fingerId].GetComponent<ReturnPos>().returnpos = true;
								beingDragged[touch.fingerId].GetComponent<SpriteRenderer>().sortingOrder = 0;
							}
						}
               			break;

            		case TouchPhase.Canceled:
						if(check[touch.fingerId])
						{
							beingDragged[touch.fingerId].GetComponent<ReturnPos>().returnpos = true;
							beingDragged[touch.fingerId].GetComponent<SpriteRenderer>().sortingOrder = 0;
							beingDragged[touch.fingerId] = null;
						}
                		break;
            	}
			}
		}
	}
}
