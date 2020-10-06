using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class XiloPlayLogic : MonoBehaviour {

	void Start () 
	{
		
	}
	
	void Update () 
	{
		
	}

	public void SuonaNota()
	{
		EventSystem.current.currentSelectedGameObject.GetComponent<AudioSource>().Play();
		//EventSystem.current.currentSelectedGameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().SetTrigger("Hit");
	}
}
