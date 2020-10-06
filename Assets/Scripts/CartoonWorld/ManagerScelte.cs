using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ManagerScelte : MonoBehaviour {

	public Sprite[] MatriceDino, MatriceFattoria, MatriceLaboratorio, SfondiDino, SfondiFattoria, SfondiLaboratorio, SfondiCostruzione;
	public Canvas[] Pagine;
	public SpriteRenderer Sfondo;
	int countpagina = 0;
	GameObject[] poscreature, poscolore, posanimazione, sfondi;
	string scelta = "0000";
	bool animlibero = true;
	bool finallibero = true;
	public Dictionary<string, int> dict = new Dictionary<string, int>();
	int ambiente = 1;
	GameObject tempfinal;
	public AudioSource LoopAudio, FX;
	public AudioClip P, F, L, Scelgo;
	int forb = 0;


	void Start () 
	{
		poscreature = FindObsWithTag("pos1");
		poscolore = FindObsWithTag("pos2");
		posanimazione = FindObsWithTag("pos3");
		sfondi = FindObsWithTag("SpazioSfondi");
		PopulateDictionary();
	}

	public void AvantiPagina()
	{
		if (countpagina == 3)
		{
			GameObject[] edit = GameObject.FindGameObjectsWithTag("Editor");
   			foreach(GameObject e in edit)
			{
				GameObject.Destroy(e);
			}
		}
		Pagine[countpagina].GetComponent<CanvasGroup>().alpha = 0;
		Pagine[countpagina].GetComponent<CanvasGroup>().interactable = false;
		Pagine[countpagina].GetComponent<CanvasGroup>().blocksRaycasts = false;
		countpagina++;
		Sfondo.sprite = SfondiCostruzione[countpagina];
		Pagine[countpagina].GetComponent<CanvasGroup>().alpha = 1;
		Pagine[countpagina].GetComponent<CanvasGroup>().interactable = true;
		Pagine[countpagina].GetComponent<CanvasGroup>().blocksRaycasts = true;
	}

	public void IndietroPagina()
	{
		if (countpagina == 4)
		{
			Destroy (GameObject.FindWithTag("EditorF"));
			InstantiateAnims();
		}
		if(countpagina == 3)
		{
			GameObject[] edit = GameObject.FindGameObjectsWithTag("Editor");
   			foreach(GameObject e in edit)
			{
				GameObject.Destroy(e);
			}
		}
		EventSystem.current.currentSelectedGameObject.GetComponent<AudioSource>().Play();
		Pagine[countpagina].GetComponent<CanvasGroup>().alpha = 0;
		Pagine[countpagina].GetComponent<CanvasGroup>().interactable = false;
		Pagine[countpagina].GetComponent<CanvasGroup>().blocksRaycasts = false;
		countpagina--;	
		Sfondo.sprite = SfondiCostruzione[countpagina];
		Pagine[countpagina].GetComponent<CanvasGroup>().alpha = 1;
		Pagine[countpagina].GetComponent<CanvasGroup>().interactable = true;
		Pagine[countpagina].GetComponent<CanvasGroup>().blocksRaycasts = true;
	}

	public void BackLancia()
	{
		Pagine[countpagina].GetComponent<CanvasGroup>().alpha = 0;
		Pagine[countpagina].GetComponent<CanvasGroup>().interactable = false;
		Pagine[countpagina].GetComponent<CanvasGroup>().blocksRaycasts = false;
		countpagina = 1;
		Sfondo.sprite = SfondiCostruzione[countpagina];
		Pagine[countpagina].GetComponent<CanvasGroup>().alpha = 1;
		Pagine[countpagina].GetComponent<CanvasGroup>().interactable = true;
		Pagine[countpagina].GetComponent<CanvasGroup>().blocksRaycasts = true;
	}

	public void SceltaPreistoria()
	{
		int c = 0;
        foreach (GameObject p in poscreature)
        {
            p.GetComponent<Image>().sprite = MatriceDino[c];
            c += 5;
        }
		if(ambiente!=1)
		{
			c = 0;
			foreach (GameObject s in sfondi)
			{
				s.GetComponent<SpriteRenderer>().sprite = SfondiDino[c];
				c++;
			}
			GameObject[] f = GameObject.FindGameObjectsWithTag("Final");
   			foreach(GameObject e in f)
			{
				GameObject.Destroy(e);
			}
			LoopAudio.clip = P;
			LoopAudio.Play();
			ambiente = 1;
		}
		scelta = scelta.Remove(0, 1);
		scelta = scelta.Insert(0, "1");
		FX.clip = Scelgo;
		FX.Play();
		AvantiPagina();	
	}

	public void SceltaFattoria()
	{
		int c = 0;
        foreach (GameObject p in poscreature)
        {
            p.GetComponent<Image>().sprite = MatriceFattoria[c];
            c += 5;
        }
		if(ambiente!=2)
		{
			c = 0;
			foreach (GameObject s in sfondi)
			{
				s.GetComponent<SpriteRenderer>().sprite = SfondiFattoria[c];
				c++;
			}
			GameObject[] f = GameObject.FindGameObjectsWithTag("Final");
   			foreach(GameObject e in f)
			{
				GameObject.Destroy(e);
			}
			LoopAudio.clip = F;
			LoopAudio.Play();
			ambiente = 2;
		}
		scelta = scelta.Remove(0, 1);
		scelta = scelta.Insert(0, "2");
		FX.clip = Scelgo;
		FX.Play();
		AvantiPagina();
	}

	public void SceltaLaboratorio()
	{
		int c = 0;
        foreach (GameObject p in poscreature)
        {
            p.GetComponent<Image>().sprite = MatriceLaboratorio[c];
            c += 5;
        }
		if(ambiente!=3)
		{
			c = 0;
			foreach (GameObject s in sfondi)
			{
				s.GetComponent<SpriteRenderer>().sprite = SfondiLaboratorio[c];
				c++;
			}
			GameObject[] f = GameObject.FindGameObjectsWithTag("Final");
   			foreach(GameObject e in f)
			{
				GameObject.Destroy(e);
			}
			LoopAudio.clip = L;
			LoopAudio.Play();
			ambiente = 3;
		}
		scelta = scelta.Remove(0, 1);
		scelta = scelta.Insert(0, "3");
		FX.clip = Scelgo;
		FX.Play();
		AvantiPagina();	
	}

	public void SceltaCreatura()
	{
		int value = EventSystem.current.currentSelectedGameObject.name[16] & 0x0f;
		scelta = scelta.Remove(1, 1);
		scelta = scelta.Insert(1, value.ToString());
		value -= 1;
		value *= 5;
		value += 1;
		int tempscelta = scelta[0] & 0x0f;
		if(tempscelta == 1)
		{
        	foreach (GameObject p in poscolore)
        	{
           		p.GetComponent<Image>().sprite = MatriceDino[value];
            	value++;
        	}
		}
		else if(tempscelta == 2)
		{
        	foreach (GameObject p in poscolore)
        	{
           		p.GetComponent<Image>().sprite = MatriceFattoria[value];
            	value++;
        	}
		}
		else if(tempscelta == 3)
		{
        	foreach (GameObject p in poscolore)
        	{
           		p.GetComponent<Image>().sprite = MatriceLaboratorio[value];
            	value++;
        	}
		}
		FX.clip = Scelgo;
		FX.Play();
		AvantiPagina();
	}

	public void SceltaColore()
	{
		int value = EventSystem.current.currentSelectedGameObject.name[14] & 0x0f;
		scelta = scelta.Remove(2, 1);
		scelta = scelta.Insert(2, value.ToString());
		if (!animlibero)
		{
			GameObject[] edit = GameObject.FindGameObjectsWithTag("Editor");
   			foreach(GameObject e in edit)
			{
				GameObject.Destroy(e);
			}
		}
		InstantiateAnims();
		FX.clip = Scelgo;
		FX.Play();
		AvantiPagina();
	}

	public void SceltaAnim()
	{
		int value = EventSystem.current.currentSelectedGameObject.name[18] & 0x0f;
		string path = "Prefabs/" + scelta;
		path = path.Remove(11, 1);
		path = path.Insert(11, value.ToString());
		if(!finallibero)
		{
			Destroy (GameObject.FindWithTag("EditorF"));
		}
		Vector3 pos = GameObject.FindWithTag("pos4").transform.position;
		tempfinal = Instantiate(Resources.Load(path), pos, transform.rotation) as GameObject;
		tempfinal.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
		tempfinal.tag = "EditorF";
		tempfinal.GetComponent<SpriteRenderer>().sortingLayerName = "Back4ground";
		finallibero = false;
		FX.clip = Scelgo;
		FX.Play();
		AvantiPagina();
		scelta = scelta.Remove(3, 1);
		scelta = scelta.Insert(3, value.ToString());
	}

	public void InstantiateAnims()
	{
		int c = 0;
		string path = "Prefabs/" + scelta;
		foreach (GameObject p in posanimazione)
        {
           	c++;
			path = path.Remove(11, 1);
			path = path.Insert(11, c.ToString());	
			Instantiate(Resources.Load(path), p.transform.position, transform.rotation);
        }
		animlibero = false;
	}

	public void Lancia()
	{
		if(dict[scelta]==1)
		{
			if(forb == 0)
			{
				tempfinal.transform.position = new Vector2(-5.2f, 11.3f);
				tempfinal.GetComponent<CartoonMovement>().speed = 1;
				tempfinal.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
				tempfinal.GetComponent<SpriteRenderer>().sortingLayerName = "Foreground";
				forb++;
			}
			else
			{
				tempfinal.transform.position = new Vector2(-5.2f, 13.5f);
				tempfinal.GetComponent<CartoonMovement>().speed = 0.5f;
				tempfinal.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
				tempfinal.GetComponent<SpriteRenderer>().sortingLayerName = "Background";
				forb--;
			}
			tempfinal.GetComponent<CartoonMovement>().dir = 1;
			tempfinal.GetComponent<SpriteRenderer>().flipX = true;
		}
		else if(dict[scelta]==2)
		{
			tempfinal.transform.position = new Vector2(-5.2f, 16.5f);
			tempfinal.GetComponent<CartoonMovement>().speed = 0.5f;
			tempfinal.GetComponent<CartoonMovement>().dir = 1;
			tempfinal.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
			tempfinal.GetComponent<SpriteRenderer>().sortingLayerName = "Background";
			tempfinal.GetComponent<SpriteRenderer>().flipX = true;
		}
		else if(dict[scelta]==3)
		{
			if(forb == 0)
			{
				tempfinal.transform.position = new Vector2(5.2f, 11.3f);
				tempfinal.GetComponent<CartoonMovement>().speed = 2;
				tempfinal.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
				tempfinal.GetComponent<SpriteRenderer>().sortingLayerName = "Foreground";
				forb++;
			}
			else
			{
				tempfinal.transform.position = new Vector2(5.2f, 13.5f);
				tempfinal.GetComponent<CartoonMovement>().speed = 1.5f;
				tempfinal.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
				tempfinal.GetComponent<SpriteRenderer>().sortingLayerName = "Background";
				forb--;
			}
		}
		else if(dict[scelta]==4)
		{
			tempfinal.transform.position = new Vector2(5.2f, 16.5f);
			tempfinal.GetComponent<CartoonMovement>().speed = 1.5f;
			tempfinal.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
			tempfinal.GetComponent<SpriteRenderer>().sortingLayerName = "Background";
		}
		else if(dict[scelta]==5)
		{
			if(forb == 0)
			{
				tempfinal.transform.position = new Vector2(5.2f, 11.3f);
				tempfinal.GetComponent<CartoonMovement>().speed = 1f;
				tempfinal.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
				tempfinal.GetComponent<SpriteRenderer>().sortingLayerName = "Foreground";
				forb++;
			}
			else
			{
				tempfinal.transform.position = new Vector2(5.2f, 13.5f);
				tempfinal.GetComponent<CartoonMovement>().speed = 0.5f;
				tempfinal.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
				tempfinal.GetComponent<SpriteRenderer>().sortingLayerName = "Background";
				forb--;
			}
		}
		else if(dict[scelta]==6)
		{
			tempfinal.transform.position = new Vector2(5.2f, 16.5f);
			tempfinal.GetComponent<CartoonMovement>().speed = 0.5f;
			tempfinal.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
			tempfinal.GetComponent<SpriteRenderer>().sortingLayerName = "Background";
		}
		tempfinal.tag = "Final";
		BackLancia();
	}

	
	
	public GameObject[] FindObsWithTag(string tag)
    {
        GameObject[] foundObs = GameObject.FindGameObjectsWithTag(tag);
        Array.Sort(foundObs, CompareObNames);
        return foundObs;
    }

    public int CompareObNames(GameObject x, GameObject y)
    {
        return x.name.CompareTo(y.name);
    }

	private void PopulateDictionary()
	{
		//PREISTORIA
		dict.Add("1111", 1);
		dict.Add("1112", 1);
		dict.Add("1113", 5);
		dict.Add("1121", 1);
		dict.Add("1122", 1);
		dict.Add("1123", 5);
		dict.Add("1131", 1);
		dict.Add("1132", 1);
		dict.Add("1133", 5);
		dict.Add("1141", 1);
		dict.Add("1142", 1);
		dict.Add("1143", 5);
		dict.Add("1211", 1);
		dict.Add("1212", 4);
		dict.Add("1213", 6);
		dict.Add("1221", 1);
		dict.Add("1222", 4);
		dict.Add("1223", 6);
		dict.Add("1231", 1);
		dict.Add("1232", 4);
		dict.Add("1233", 6);
		dict.Add("1241", 1);
		dict.Add("1242", 4);
		dict.Add("1243", 6);
		dict.Add("1311", 1);
		dict.Add("1312", 1);
		dict.Add("1313", 5);
		dict.Add("1321", 1);
		dict.Add("1322", 1);
		dict.Add("1323", 5);
		dict.Add("1331", 1);
		dict.Add("1332", 1);
		dict.Add("1333", 5);
		dict.Add("1341", 1);
		dict.Add("1342", 1);
		dict.Add("1343", 5);
		dict.Add("1411", 1);
		dict.Add("1412", 3);
		dict.Add("1413", 1);
		dict.Add("1421", 1);
		dict.Add("1422", 3);
		dict.Add("1423", 1);
		dict.Add("1431", 1);
		dict.Add("1432", 3);
		dict.Add("1433", 1);
		dict.Add("1441", 1);
		dict.Add("1442", 3);
		dict.Add("1443", 1);
		dict.Add("1511", 1);
		dict.Add("1512", 3);
		dict.Add("1513", 5);
		dict.Add("1521", 1);
		dict.Add("1522", 3);
		dict.Add("1523", 5);
		dict.Add("1531", 1);
		dict.Add("1532", 3);
		dict.Add("1533", 5);
		dict.Add("1541", 1);
		dict.Add("1542", 3);
		dict.Add("1543", 5);
		dict.Add("1611", 1);
		dict.Add("1612", 3);
		dict.Add("1613", 1);
		dict.Add("1621", 1);
		dict.Add("1622", 3);
		dict.Add("1623", 1);
		dict.Add("1631", 1);
		dict.Add("1632", 3);
		dict.Add("1633", 1);
		dict.Add("1641", 1);
		dict.Add("1642", 3);
		dict.Add("1643", 1);
		//FATTORIA
		dict.Add("2111", 1);
		dict.Add("2112", 5);
		dict.Add("2113", 1);
		dict.Add("2121", 1);
		dict.Add("2122", 5);
		dict.Add("2123", 1);
		dict.Add("2131", 1);
		dict.Add("2132", 5);
		dict.Add("2133", 1);
		dict.Add("2141", 1);
		dict.Add("2142", 5);
		dict.Add("2143", 1);
		dict.Add("2211", 1);
		dict.Add("2212", 3);
		dict.Add("2213", 5);
		dict.Add("2221", 1);
		dict.Add("2222", 3);
		dict.Add("2223", 5);
		dict.Add("2231", 1);
		dict.Add("2232", 3);
		dict.Add("2233", 5);
		dict.Add("2241", 1);
		dict.Add("2242", 3);
		dict.Add("2243", 5);
		dict.Add("2311", 1);
		dict.Add("2312", 3);
		dict.Add("2313", 5);
		dict.Add("2321", 1);
		dict.Add("2322", 3);
		dict.Add("2323", 5);
		dict.Add("2331", 1);
		dict.Add("2332", 3);
		dict.Add("2333", 5);
		dict.Add("2341", 1);
		dict.Add("2342", 3);
		dict.Add("2343", 5);
		dict.Add("2411", 1);
		dict.Add("2412", 1);
		dict.Add("2413", 5);
		dict.Add("2421", 1);
		dict.Add("2422", 1);
		dict.Add("2423", 5);
		dict.Add("2431", 1);
		dict.Add("2432", 1);
		dict.Add("2433", 5);
		dict.Add("2441", 1);
		dict.Add("2442", 1);
		dict.Add("2443", 5);
		dict.Add("2511", 1);
		dict.Add("2512", 3);
		dict.Add("2513", 5);
		dict.Add("2521", 1);
		dict.Add("2522", 3);
		dict.Add("2523", 5);
		dict.Add("2531", 1);
		dict.Add("2532", 3);
		dict.Add("2533", 5);
		dict.Add("2541", 1);
		dict.Add("2542", 3);
		dict.Add("2543", 5);
		dict.Add("2611", 1);
		dict.Add("2612", 1);
		dict.Add("2613", 5);
		dict.Add("2621", 1);
		dict.Add("2622", 1);
		dict.Add("2623", 5);
		dict.Add("2631", 1);
		dict.Add("2632", 1);
		dict.Add("2633", 5);
		dict.Add("2641", 1);
		dict.Add("2642", 1);
		dict.Add("2643", 5);
		//LABORATORIO
		dict.Add("3111", 1);
		dict.Add("3112", 6);
		dict.Add("3113", 4);
		dict.Add("3121", 1);
		dict.Add("3122", 6);
		dict.Add("3123", 4);
		dict.Add("3131", 1);
		dict.Add("3132", 6);
		dict.Add("3133", 4);
		dict.Add("3141", 1);
		dict.Add("3142", 6);
		dict.Add("3143", 4);
		dict.Add("3211", 1);
		dict.Add("3212", 1);
		dict.Add("3213", 5);
		dict.Add("3221", 1);
		dict.Add("3222", 1);
		dict.Add("3223", 5);
		dict.Add("3231", 1);
		dict.Add("3232", 1);
		dict.Add("3233", 5);
		dict.Add("3241", 1);
		dict.Add("3242", 1);
		dict.Add("3243", 5);
		dict.Add("3311", 1);
		dict.Add("3312", 1);
		dict.Add("3313", 1);
		dict.Add("3321", 1);
		dict.Add("3322", 1);
		dict.Add("3323", 1);
		dict.Add("3331", 1);
		dict.Add("3332", 1);
		dict.Add("3333", 1);
		dict.Add("3341", 1);
		dict.Add("3342", 1);
		dict.Add("3343", 1);
		dict.Add("3411", 1);
		dict.Add("3412", 5);
		dict.Add("3413", 1);
		dict.Add("3421", 1);
		dict.Add("3422", 5);
		dict.Add("3423", 1);
		dict.Add("3431", 1);
		dict.Add("3432", 5);
		dict.Add("3433", 1);
		dict.Add("3441", 1);
		dict.Add("3442", 5);
		dict.Add("3443", 1);
		dict.Add("3511", 1);
		dict.Add("3512", 1);
		dict.Add("3513", 5);
		dict.Add("3521", 1);
		dict.Add("3522", 1);
		dict.Add("3523", 5);
		dict.Add("3531", 1);
		dict.Add("3532", 1);
		dict.Add("3533", 5);
		dict.Add("3541", 1);
		dict.Add("3542", 1);
		dict.Add("3543", 5);
		dict.Add("3611", 1);
		dict.Add("3612", 2);
		dict.Add("3613", 2);
		dict.Add("3621", 1);
		dict.Add("3622", 2);
		dict.Add("3623", 2);
		dict.Add("3631", 1);
		dict.Add("3632", 2);
		dict.Add("3633", 2);
		dict.Add("3641", 1);
		dict.Add("3642", 2);
		dict.Add("3643", 2);
	}
}
