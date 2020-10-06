using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine.SceneManagement;

public class MemoryLogic : MonoBehaviour
{
	private GameObject[] foundobs;
	public static GameObject[] foundcards;
	private int count = 0;
	public GameObject[] Carte;
	int rnd;
	public static int i;
	private Sprite tempSprite;
	public Sprite SfondoWin;
	private GameObject tempGO;
	public GameObject StellaWin, Raggi;
	int[] doppioni = new int[20];
	int ind = 0;
	public static int wincount=0;
	public static bool DONOT = false;
	public AudioSource Suono;
	public AudioClip Corretta, Errata, Vittoria;
	public static bool suonowin = false;
	public static bool suonoboo = false;
	public CanvasGroup Game, WinCanv;
	public Transform StellaC, StellaUNO, StellaDUE;
	public SpriteRenderer Sfondo;
	

	void Awake()
	{
		foundobs = GameObject.FindGameObjectsWithTag("Carta");
		ShufflePos();
		RandomGen();
        foreach (GameObject go in foundobs)
        {
	        if (count == 2)
	        {
		        RandomGen();
		        count = 0;
	        }
	        Instantiate(Carte[rnd], go.transform.position, transform.rotation);
	        count++;
        }
	}
	
	void Start () 
	{
		i = 0;
		ind = 0;
		foundcards = GameObject.FindGameObjectsWithTag("Card");
		wincount = 0;
		DONOT = false;
	}
	
	void Update () 
	{
		if(suonowin)
		{
			Suono.clip = Corretta;
			Suono.Play();
			suonowin = false;
		}
		if(suonoboo)
		{
			Suono.clip = Errata;
			Suono.Play();
			suonoboo = false;
		}
		if(wincount==9)
			{
				Invoke("MemoryWin", 1);
				wincount++;
			}
	}
	
	public void ShufflePos()
	{
		for (int i = 0; i < foundobs.Length; i++)
		{
			rnd = Random.Range(0, foundobs.Length);
			tempGO = foundobs[rnd];
			foundobs[rnd] = foundobs[i];
			foundobs[i] = tempGO;
		}
	}

	void RandomGen()
	{
		rnd = Random.Range(0, 19);
		while (doppioni.Contains(rnd))
		{
			rnd = Random.Range(0, 19);
		}
		doppioni[ind] = rnd;
		ind++;
	}
	
	public static void CheckCard()
	{
		List<GameObject> c = new List<GameObject>();
		foreach(GameObject go in foundcards)
		{
			if(go.GetComponent<MemoryClick>().state == 1)
			{
				c.Add(go);
			}
		}
		if(c[0].name==c[1].name)
		{
			suonowin = true;
			foreach(GameObject go in foundcards)
			{
				if(go.name==c[0].name || go.name==c[1].name)
				{
					go.GetComponent<MemoryClick>().state = 3;
				}
			}
			
			DONOT = false;
			wincount++;
		}else
		{
			suonoboo = true;
			foreach(GameObject go in foundcards)
			{
				if(go.name==c[0].name || go.name==c[1].name)
				{
					if (go.GetComponent<MemoryClick>().state == 1)
					{
						go.GetComponent<MemoryClick>().state = 2;
					}
				}
			}
		}
		i = 0;
	}

	void MemoryWin() 
	{
		var clones = GameObject.FindGameObjectsWithTag("Card");
        foreach (var Card in clones)
        {
            Destroy(Card);
        }
		WinCanv.alpha = 1;
		WinCanv.interactable = true;
		WinCanv.blocksRaycasts = true;
        Game.alpha = 0;
		Game.interactable = false;
		Game.blocksRaycasts = false;
		Sfondo.sprite = SfondoWin;
		Instantiate(Raggi, StellaC.transform.position, Quaternion.identity);
		Suono.clip=Vittoria;
		StartCoroutine(Stelle());
		Suono.Play();
	}
	
	IEnumerator Stelle()
	{
		var stella = Instantiate (StellaWin, StellaUNO.transform.position, transform.rotation);
		stella.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
		yield return new WaitForSeconds(0.2f);
		stella = Instantiate (StellaWin, StellaDUE.transform.position, transform.rotation);
		stella.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
		yield return new WaitForSeconds(0.2f);
		stella = Instantiate (StellaWin, StellaC.transform.position, transform.rotation);
		stella.transform.localScale = new Vector3(1.6f, 1.6f, 1f);
		yield return new WaitForSeconds(10f);
		SceneManager.LoadScene("Menu");
	}
}
