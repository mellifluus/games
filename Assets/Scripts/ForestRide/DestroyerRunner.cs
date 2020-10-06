using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerRunner : MonoBehaviour {

	AudioSource Suono;
	public GameObject Poff;
	public bool isGrounded = true;
	
	void Start()
	{
		Suono = gameObject.GetComponent<AudioSource>();
		Suono.volume = PlayerPrefs.GetFloat("VolFX", 0.6f);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		BarraPuntiForestRide.punteggio += 1;
		Suono.Play();
		var temppoff = Instantiate(Poff, col.transform.position, Quaternion.identity);
		temppoff.transform.localScale = new Vector3(2f, 2f, 1f);
		Destroy(col.gameObject);
		Destroy(temppoff, temppoff.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
	}

	void OnCollisionEnter2D(Collision2D col)
 	{
     	if (col.gameObject.name == "ColliderGround")
     	{
         	isGrounded = true;
     	}
 	}

	void OnCollisionExit2D(Collision2D col)
 	{
    	if (col.gameObject.name == "ColliderGround")
    	{
        	isGrounded = false;
    	}
 	}
}
