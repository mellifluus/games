using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerJellyPop : MonoBehaviour
{

	AudioSource SuonoSalgo;
	public GameObject[] Jellies;
	float tmin = 3f;
	float tmax = 6f;
	int rnd;
	
	void Start () 
	{
		Invoke("Spawn", Random.Range(0.5f, 3f));
		SuonoSalgo = gameObject.GetComponent<AudioSource>();
	}
	
	void Spawn ()
	{
		if (!BarraPuntiJellyPop.Win)
		{
			rnd = Random.Range(0, 6);
			GameObject temp = Instantiate(Jellies[rnd], transform.position, Quaternion.identity);
			SuonoSalgo.Play();
			Destroy(temp, temp.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
			Invoke("Spawn", Random.Range(tmin, tmax));
		}
	}	
}
