using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TheShapeLogic : MonoBehaviour {

	public SpriteRenderer[] Icone;
	public SpriteRenderer Buco, BucoNext;
	public Sprite[] Buchi, IconeF, Forme;
	public GameObject[] FormeS;
	public int countforme, nbuco;
	int idoppioni = 0;
	int[] doppioni = new int[20];
	public bool next = false;
	public bool startscorri = false;
	public Transform FinalPos;
	public GameObject tempinst;
	AudioSource Suono;
	public AudioClip FormaOk, FormaNo;
	public Button Avanti, Indietro;
	
	void Start () 
	{
		countforme = 0;
		RandomGen();
		LoadIcone();
		Buco.sprite = Buchi[nbuco];
		Suono = gameObject.GetComponent<AudioSource>();
	}
	
	void Update () {
		if (next)
		{
			BarraPuntiTheShape.punteggio += 1;
			DisableColliders();
			PrepareNext();
		}
	}

	public void IconeAvanti()
	{
		if(countforme != 14)
		{
			EventSystem.current.currentSelectedGameObject.GetComponent<AudioSource>().Play();
			EventSystem.current.currentSelectedGameObject.GetComponent<Animator>().Play("Pressed", -1, 0f);
			countforme++;
			LoadIcone();
			if(countforme == 14)
			{
				Avanti.interactable = false;
			}
			if(countforme == 1)
			{
				Indietro.interactable = true;
			}
		}
	}

	public void IconeIndietro()
	{
		if(countforme != 0)
		{
			EventSystem.current.currentSelectedGameObject.GetComponent<AudioSource>().Play();
			EventSystem.current.currentSelectedGameObject.GetComponent<Animator>().Play("Pressed", -1, 0f);
			countforme--;
			LoadIcone();
			if(countforme == 0)
			{
				Indietro.interactable = false;
			}
			if(countforme == 13)
			{
				Avanti.interactable = true;
			}
		}
	}
	
	public void LoadIcone()
	{
		foreach(var i in Icone)
		{
			i.sprite = IconeF[countforme];
			countforme++;
		}
		countforme -= 6;
	}

	void RandomGen()
	{
		nbuco = UnityEngine.Random.Range(0, 20);
		while (doppioni.Contains(nbuco))
		{
			nbuco = UnityEngine.Random.Range(0, 20);
		}
		doppioni[idoppioni] = nbuco;
		idoppioni++;
	}

	void PrepareNext()
	{
		StartCoroutine(StartS());
		RandomGen();
		BucoNext.sprite = Buchi[nbuco];
		tempinst = GameObject.FindWithTag("PForme");
		next = false;
	}

	void DisableColliders()
	{
		foreach(var i in Icone)
		{
			i.GetComponent<BoxCollider2D>().enabled = false;
		}
	}

	IEnumerator StartS()
	{
		yield return new WaitForSeconds(1f);
		startscorri = true;
		Suono.Play();
	}
}
