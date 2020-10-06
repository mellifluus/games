using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BarraPuntiBolle : MonoBehaviour {

	public Image Barra, Stella1, Stella2, Stella3;
	public SpriteRenderer Sfondo;
	public AudioSource Suono;
	public AudioClip UnoeDue, Tre, VittoriaSuono;
	public Sprite StellaON, SfondoWin;
	public GameObject Stelline, StellaWin, Raggi;
	public static bool Win;
	public CanvasGroup Game, WinCanv;
	public static int punteggio;
	float traduzione;
	int check = 0;
	public Transform StellaC, StellaUNO, StellaDUE;

	void Start () 
	{
		punteggio = 0;
        Win = false;
		Suono.clip = UnoeDue;
	}
	
	void Update () 
	{
		traduzione = punteggio * 0.004f;
		if (traduzione > 0.98f)
		{
			traduzione = 0.98f;
		}
		if (traduzione < 0)
		{
			traduzione = 0;
			punteggio = 0;
		}
		Barra.transform.localScale = new Vector3(traduzione, 1, 1);
		if (traduzione>=0.33 && check==0)
		{
			check = 1;
            Stella1.sprite=StellaON;
			var stellinetemp = Instantiate (Stelline, Stella1.transform.position, Quaternion.identity);
			Destroy(stellinetemp, 1);
			Suono.Play();
		}
		if (traduzione>=0.66 && check==1)
		{
			check = 2;
            Stella2.sprite=StellaON;
			var stellinetemp = Instantiate (Stelline, Stella2.transform.position, Quaternion.identity);
			Destroy(stellinetemp, 1);
			Suono.Play();
		}
		if (traduzione>=0.98 && check==2)
		{
			Win = true;
            check = 3;
            Stella3.sprite=StellaON;
			var stellinetemp = Instantiate (Stelline, Stella3.transform.position, Quaternion.identity);
			Destroy(stellinetemp, 1);
			Suono.clip = Tre;
			Suono.Play();
			Invoke("Vittoria", 1);
		}
	}

	IEnumerator Stelle()
	{
		Instantiate (Raggi, StellaC.transform.position, transform.rotation);
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

	void Vittoria()
    {
        var clones = GameObject.FindGameObjectsWithTag("Bolla");
        foreach (var Bolla in clones)
        {
            Destroy(Bolla);
        }
        WinCanv.alpha = 1;
		WinCanv.interactable = true;
		WinCanv.blocksRaycasts = true;
        Game.alpha = 0;
		Game.interactable = false;
		Game.blocksRaycasts = false;
		Sfondo.sprite = SfondoWin;
		Suono.clip=VittoriaSuono;
		StartCoroutine(Stelle());
		Suono.Play();
    }
}
