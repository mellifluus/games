using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BarraPuntiUnderTheSea : MonoBehaviour {

	public Image Barra, Stella1, Stella2, Stella3;
	public SpriteRenderer Sfondo, Sottomarino;
	public AudioSource Suono, SommSuono;
	public AudioClip UnoeDue, Tre, VittoriaSuono;
	public Sprite StellaON, Sott2, Sott3;
	public GameObject Stelline, StellaWin, Raggi, SfondiCanv, Bubbles;
    public PolygonCollider2D[] coll;
	public static bool Win;
	public CanvasGroup Game, WinCanv;
	public static int punteggio;
	float traduzione;
	int check, indcoll;
	public Transform StellaC, StellaUNO, StellaDUE;

	void Start () 
	{
		punteggio = 0;
        Win = false;
		Suono.clip = UnoeDue;
        check = 0;
        indcoll = 0;
	}
	
	void Update () 
	{
		traduzione = punteggio * 0.02f;
		if (traduzione>=0.98f)
		{
			traduzione=0.98f;
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
            Sottomarino.sprite = Sott2;
			Bubbles.transform.localPosition = new Vector2(0.73f, -0.3f);
            var tempobj = Instantiate(Stelline, Sottomarino.transform.position, Quaternion.identity);
            Destroy(tempobj, 1);
            coll[indcoll].enabled = false;
            indcoll++;
            coll[indcoll].enabled = true;
			Sottomarino.gameObject.GetComponent<SottomarinoDestroyer>().collcheck = 1;
		}
		if (traduzione>=0.66 && check==1)
		{
			check = 2;
            Stella2.sprite=StellaON;
			var stellinetemp = Instantiate (Stelline, Stella2.transform.position, Quaternion.identity);
			Destroy(stellinetemp, 1);
			Suono.Play();
            Sottomarino.sprite = Sott3;
			Bubbles.transform.localPosition = new Vector2(1.12f, -0.3f);
            var tempobj = Instantiate(Stelline, Sottomarino.transform.position, Quaternion.identity);
            Destroy(tempobj, 1);
            coll[indcoll].enabled = false;
            indcoll++;
            coll[indcoll].enabled = true;
			Sottomarino.gameObject.GetComponent<SottomarinoDestroyer>().collcheck = 2;
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
        var clones = GameObject.FindGameObjectsWithTag("Stella");
        foreach (var s in clones)
        {
            Destroy(s);
        }
		clones = GameObject.FindGameObjectsWithTag("Pesce");
		foreach (var p in clones)
        {
            Destroy(p);
        }
        WinCanv.alpha = 1;
		WinCanv.interactable = true;
		WinCanv.blocksRaycasts = true;
        Game.alpha = 0;
		Game.interactable = false;
		Game.blocksRaycasts = false;
		SommSuono.Stop();
        SfondiCanv.SetActive(false);
        Sfondo.enabled = true;
        Sottomarino.enabled = false;
		Bubbles.SetActive(false);
		Suono.clip=VittoriaSuono;
		StartCoroutine(Stelle());
		Suono.Play();
    }
}
