using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundClick : MonoBehaviour
{
	AudioSource Suono;
	public GameObject Onda;
	bool isPlaying, isShaking;
	Vector2 startPos;

	//SCRIPT ASSEGNATO ALLA PRESSIONE DI UN ELEMENTO DELLA SOUNDBOARD
	//SE isPlaying==false SI PROCEDE, E SI ASSEGNA true A isPlaying
	//SI AVVIA QUINDI IL SUONO E SI INVOCA falsePlaying() ALLA FINE DEL SUONO
	//SI ISTANZIA UN PREFAB Onda IN POSIZIONE DELL'ELEMENTO CLICCATO
	//E LO SI DITRUGGE ALLA FINE DELLA SUA ANIMAZIONE
	
	void Start()
	{
		Suono = gameObject.GetComponent<AudioSource>();
		isPlaying = false;
		isShaking = false;
		startPos = transform.position;
	}

	void Update()
	{
		if(isShaking)
		{
			transform.position = new Vector2(startPos.x + (Mathf.Sin(Time.time * 100) * 0.02f), startPos.y + (Mathf.Sin(Time.time * 100) * 0.02f));
		}
	}
	
	public void click()
	{
		if (!isPlaying && !isShaking)
		{
			isShaking = true;
			isPlaying = true;
			Suono.Play();
			Invoke("falsePlaying", Suono.clip.length);
			var ondasonora = Instantiate(Onda, gameObject.transform.position, transform.rotation);
			Destroy(ondasonora, ondasonora.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
		}
	}
	
	//PERMETTE NUOVAMENTE IL CLICK DELL'OGGETTO
	
	void falsePlaying()
	{
		isPlaying = false;
		isShaking = false;
		transform.position = startPos;
	}

	IEnumerator Shake()
	{
		yield return new WaitForSeconds(0.2f);
	}
}