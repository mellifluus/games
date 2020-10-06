using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TheMaskLogic : MonoBehaviour {

	public SpriteRenderer BambiniRenderer;
	public Sprite[] MaschereP, MaschereG, Bambini;
	public SpriteRenderer[] Occhi, Maschere;
	public int countbambini, countmaschere;
	public Transform Snap;
	AudioSource Suono;
	public AudioClip[] AnimaliSound;
	public int playsound = -1;
	public Button Avanti, Indietro;

	void Start () 
	{
		countbambini = 0;
		countmaschere = 0;
		Suono = gameObject.GetComponent<AudioSource>();
		LoadMaschere();
	}
	
	void Update () {
		if(playsound!=-1)
		{
			playsound += countmaschere;
			Suono.clip = AnimaliSound[playsound];
			Suono.Play();
			playsound = -1;
		}
	}

	public void BambiniAvanti()
	{
		EventSystem.current.currentSelectedGameObject.GetComponent<AudioSource>().Play();
		EventSystem.current.currentSelectedGameObject.GetComponent<Animator>().Play("Pressed", -1, 0f);
		Occhi[countbambini].enabled = false;
		if(countbambini == 7)
		{
			countbambini = 0;
		}
		else
		{
			countbambini++;
		}
		BambiniRenderer.sprite = Bambini[countbambini];
		Occhi[countbambini].enabled = true;
	}

	public void BambiniIndietro()
	{
		EventSystem.current.currentSelectedGameObject.GetComponent<AudioSource>().Play();
		EventSystem.current.currentSelectedGameObject.GetComponent<Animator>().Play("Pressed", -1, 0f);
		Occhi[countbambini].enabled = false;
		if(countbambini == 0)
		{
			countbambini = 7;
		}
		else
		{
			countbambini--;
		}
		BambiniRenderer.sprite = Bambini[countbambini];
		Occhi[countbambini].enabled = true;
	}

	public void MaschereAvanti()
	{
		if(countmaschere != 15)
		{
			EventSystem.current.currentSelectedGameObject.GetComponent<AudioSource>().Play();
			EventSystem.current.currentSelectedGameObject.GetComponent<Animator>().Play("Pressed", -1, 0f);
			countmaschere++;
			LoadMaschere();
			if(countmaschere == 15)
			{
				Avanti.interactable = false;
			}
			if(countmaschere == 1)
			{
				Indietro.interactable = true;
			}
		}
	}

	public void MaschereIndietro()
	{
		if(countmaschere != 0)
		{
			EventSystem.current.currentSelectedGameObject.GetComponent<AudioSource>().Play();
			EventSystem.current.currentSelectedGameObject.GetComponent<Animator>().Play("Pressed", -1, 0f);
			countmaschere--;
			LoadMaschere();
			if(countmaschere == 0)
			{
				Indietro.interactable = false;
			}
			if(countmaschere == 14)
			{
				Avanti.interactable = true;
			}
		}
	}

	public void LoadMaschere()
	{
		foreach(var m in Maschere)
		{
			m.sprite = MaschereP[countmaschere];
			countmaschere++;
		}
		countmaschere -= 5;
	}
}
