using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System;

public class Menu : MonoBehaviour {

	public GameObject Loading;
	public List<CanvasGroup> Pagine = new List<CanvasGroup>();
	public Text[] StatText;
	public String[] StatValues;
	public CanvasGroup Freccette, ModalDial, QuitDial, Volume, Stats;
	public Sprite[] VolSprite;
	public AudioSource[] Musica, FX;
	public Image VolMusica, VolFX;
	public AudioSource MusicaMenu;
	AudioSource SuonoFX;
	public int countpag = 0;
	int volt = 0;
	bool updated = false;
	private int volmus, volfx;

	void Start () 
	{
 		if(SceneManager.GetActiveScene().name == "Menu")
		{
			Pagine[countpag].alpha = 0;
			Pagine[countpag].interactable = false;
			Pagine[countpag].blocksRaycasts = false;
			countpag = PlayerPrefs.GetInt("Menupage", 0);
			Pagine[countpag].alpha = 1;
			Pagine[countpag].interactable = true;
			Pagine[countpag].blocksRaycasts = true;
			SuonoFX = gameObject.GetComponent<AudioSource>();
			SuonoFX.volume = PlayerPrefs.GetFloat("VolFX", 0.6f);
			MusicaMenu.volume = PlayerPrefs.GetFloat("VolMusica", 0.6f);
		}
		foreach(var m in Musica)
		{
			m.volume *= PlayerPrefs.GetFloat("VolMusica", 0.6f);
		}
		foreach(var f in FX)
		{
			f.volume *= PlayerPrefs.GetFloat("VolFX", 0.6f);
		}
	}

	public void pgAvanti()
	{
		EventSystem.current.currentSelectedGameObject.GetComponent<AudioSource>().Play();
		EventSystem.current.currentSelectedGameObject.GetComponent<Animator>().Play("Pressed", -1, 0f);
		Pagine[countpag].alpha = 0;
		Pagine[countpag].interactable = false;
		Pagine[countpag].blocksRaycasts = false;
		if(countpag == Pagine.Count - 1)
		{
			countpag = 0;
		}
		else
		{
			countpag++;
		}
		Pagine[countpag].alpha = 1;
		Pagine[countpag].interactable = true;
		Pagine[countpag].blocksRaycasts = true;
		volt = 0;
	}

	public void pgIndietro()
	{
		EventSystem.current.currentSelectedGameObject.GetComponent<AudioSource>().Play();
		EventSystem.current.currentSelectedGameObject.GetComponent<Animator>().Play("Pressed", -1, 0f);
		Pagine[countpag].alpha = 0;
		Pagine[countpag].interactable = false;
		Pagine[countpag].blocksRaycasts = false;
		if(countpag == 0)
		{
			countpag = Pagine.Count - 1;
		}
		else
		{
			countpag--;
		}
		Pagine[countpag].alpha = 1;
		Pagine[countpag].interactable = true;
		Pagine[countpag].blocksRaycasts = true;
		volt = 0;
	}

	public void LoadMenu()
	{
		switch(SceneManager.GetActiveScene().name)
        {
            case "TheMask":
               	PlayerPrefs.SetFloat("TimerTheMask", (PlayerPrefs.GetFloat("TimerTheMask") + gameObject.GetComponent<StatTimer>().timerstat));
               	break;
			case "ATavola":
               	PlayerPrefs.SetFloat("TimerATavola", (PlayerPrefs.GetFloat("TimerATavola") + gameObject.GetComponent<StatTimer>().timerstat));
               	break;
			case "Bubbles":
               	PlayerPrefs.SetFloat("TimerBubbles", (PlayerPrefs.GetFloat("TimerBubbles") + gameObject.GetComponent<StatTimer>().timerstat));
               	break;
			case "CartoonWorld":
               	PlayerPrefs.SetFloat("TimerCartoonWorld", (PlayerPrefs.GetFloat("TimerCartoonWorld") + gameObject.GetComponent<StatTimer>().timerstat));
               	break;
			case "DuckieBoom":
               	PlayerPrefs.SetFloat("TimerDuckieBoom", (PlayerPrefs.GetFloat("TimerDuckieBoom") + gameObject.GetComponent<StatTimer>().timerstat));
               	break;
			case "ForestRide":
               	PlayerPrefs.SetFloat("TimerForestRide", (PlayerPrefs.GetFloat("TimerForestRide") + gameObject.GetComponent<StatTimer>().timerstat));
               	break;
			case "JellyPop":
               	PlayerPrefs.SetFloat("TimerJellyPop", (PlayerPrefs.GetFloat("TimerJellyPop") + gameObject.GetComponent<StatTimer>().timerstat));
               	break;
			case "Memory":
               	PlayerPrefs.SetFloat("TimerMemory", (PlayerPrefs.GetFloat("TimerMemory") + gameObject.GetComponent<StatTimer>().timerstat));
               	break;
			case "OmbreTerrificanti":
               	PlayerPrefs.SetFloat("TimerOmbreTerrificanti", (PlayerPrefs.GetFloat("TimerOmbreTerrificanti") + gameObject.GetComponent<StatTimer>().timerstat));
               	break;
			case "Riciclando":
               	PlayerPrefs.SetFloat("TimerRiciclando", (PlayerPrefs.GetFloat("TimerRiciclando") + gameObject.GetComponent<StatTimer>().timerstat));
               	break;
			case "Shape":
               	PlayerPrefs.SetFloat("TimerShape", (PlayerPrefs.GetFloat("TimerShape") + gameObject.GetComponent<StatTimer>().timerstat));
               	break;
			case "Suoni":
               	PlayerPrefs.SetFloat("TimerSuoni", (PlayerPrefs.GetFloat("TimerSuoni") + gameObject.GetComponent<StatTimer>().timerstat));
               	break;
			case "UnderTheSea":
               	PlayerPrefs.SetFloat("TimerUnderTheSea", (PlayerPrefs.GetFloat("TimerUnderTheSea") + gameObject.GetComponent<StatTimer>().timerstat));
               	break;
			case "WorldCreator":
               	PlayerPrefs.SetFloat("TimerWorldCreator", (PlayerPrefs.GetFloat("TimerWorldCreator") + gameObject.GetComponent<StatTimer>().timerstat));
               	break;
			case "XiloPlay":
               	PlayerPrefs.SetFloat("TimerXiloPlay", (PlayerPrefs.GetFloat("TimerXiloPlay") + gameObject.GetComponent<StatTimer>().timerstat));
               	break;
		}
		StartCoroutine(LoadingScene("Menu"));
	}

	public void LoadTheMask()
	{
		PlayerPrefs.SetInt("Menupage", countpag);
		StartCoroutine(LoadingScene("TheMask"));
	}

	public void LoadATavola()
	{
		PlayerPrefs.SetInt("Menupage", countpag);
		StartCoroutine(LoadingScene("ATavola"));
	}

	public void LoadBubbles()
	{
		PlayerPrefs.SetInt("Menupage", countpag);
		StartCoroutine(LoadingScene("Bubbles"));
	}

	public void LoadCartoonWorld()
	{
		PlayerPrefs.SetInt("Menupage", countpag);
		StartCoroutine(LoadingScene("CartoonWorld"));
	}

	public void LoadDuckieBoom()
	{
		PlayerPrefs.SetInt("Menupage", countpag);
		StartCoroutine(LoadingScene("DuckieBoom"));
	}

	public void LoadForestRide()
	{
		PlayerPrefs.SetInt("Menupage", countpag);
		StartCoroutine(LoadingScene("ForestRide"));
	}

	public void LoadJellyPop()
	{
		PlayerPrefs.SetInt("Menupage", countpag);
		StartCoroutine(LoadingScene("JellyPop"));
	}

	public void LoadMemory()
	{
		PlayerPrefs.SetInt("Menupage", countpag);
		StartCoroutine(LoadingScene("Memory"));
	}

	public void LoadOmbreTerrificanti()
	{
		PlayerPrefs.SetInt("Menupage", countpag);
		StartCoroutine(LoadingScene("OmbreTerrificanti"));
	}

	public void LoadRiciclando()
	{
		PlayerPrefs.SetInt("Menupage", countpag);
		StartCoroutine(LoadingScene("Riciclando"));
	}

	public void LoadShape()
	{
		PlayerPrefs.SetInt("Menupage", countpag);
		StartCoroutine(LoadingScene("Shape"));
	}

	public void LoadSuoni()
	{
		PlayerPrefs.SetInt("Menupage", countpag);
		StartCoroutine(LoadingScene("Suoni"));
	}

	public void LoadUnderTheSea()
	{
		PlayerPrefs.SetInt("Menupage", countpag);
		StartCoroutine(LoadingScene("UnderTheSea"));
	}

	public void LoadWorldCreator()
	{
		PlayerPrefs.SetInt("Menupage", countpag);
		StartCoroutine(LoadingScene("WorldCreator"));
	}

	public void LoadXiloPlay()
	{
		PlayerPrefs.SetInt("Menupage", countpag);
		StartCoroutine(LoadingScene("XiloPlay"));
	}

	private IEnumerator LoadingScene(string a)
    {
		foreach(var m in Musica)
		{
			m.volume = 0;
		}
		foreach(var f in FX)
		{
			f.volume = 0;
		}
		var tmp = Instantiate(Loading);
		if(SceneManager.GetActiveScene().name == "WorldCreator" || SceneManager.GetActiveScene().name == "CartoonWorld")
		{
			var tmp2 = Instantiate(Loading, new Vector2(0, 15), Quaternion.identity);
		}
        AsyncOperation operation = SceneManager.LoadSceneAsync(a);
        while(!operation.isDone)
        {
            yield return null;
        }
    }

	public void Replay()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void VolTouch()
	{
		volt++;
		if(volt == 10)
		{
			PlayerPrefs.SetInt("Menupage", countpag);
			Pagine[countpag].alpha = 0;
			Pagine[countpag].interactable = false;
			Pagine[countpag].blocksRaycasts = false;
			Freccette.alpha = 0;
			Freccette.interactable = false;
			Freccette.blocksRaycasts = false;
			VolMusica.sprite = VolSprite[VolumeToValue(PlayerPrefs.GetFloat("VolMusica", 0.6f))];
			VolFX.sprite = VolSprite[VolumeToValue(PlayerPrefs.GetFloat("VolFX", 0.6f))];
			Volume.alpha = 1;
			Volume.interactable = true;
			Volume.blocksRaycasts = true;
			volmus = VolumeToValue(PlayerPrefs.GetFloat("VolMusica", 0.6f));
			volfx = VolumeToValue(PlayerPrefs.GetFloat("VolFX", 0.6f));
			volt = 0;
		}
	}

	public void VolMusicaSu()
	{
		if (volmus < 5)
		{
			volmus++;
			PlayerPrefs.SetFloat("VolMusica", ValueToVolume(volmus));
			VolMusica.sprite = VolSprite[volmus];
			MusicaMenu.volume = ValueToVolume(volmus);
			SuonoFX.Play();
		}
		else
		{
			Debug.Log("volmus al max");
		}
	}

	public void VolMusicaGiu()
	{
		if (volmus > 0)
		{
			volmus--;
			PlayerPrefs.SetFloat("VolMusica", ValueToVolume(volmus));
			VolMusica.sprite = VolSprite[volmus];
			MusicaMenu.volume = ValueToVolume(volmus);
			SuonoFX.Play();
		}
		else
		{
			Debug.Log("volmus al min");
		}
	}

	public void VolFXSu()
	{
		if (volfx < 5)
		{
			volfx++;
			PlayerPrefs.SetFloat("VolFX", ValueToVolume(volfx));
			VolFX.sprite = VolSprite[volfx];
			SuonoFX.volume = ValueToVolume(volfx);
			SuonoFX.Play();
		}
		else
		{
			Debug.Log("volfx al max");
		}
	}

	public void VolFXGiu()
	{
		if (volfx > 0)
		{
			volfx--;
			PlayerPrefs.SetFloat("VolFX", ValueToVolume(volfx));
			VolFX.sprite = VolSprite[volfx];
			SuonoFX.volume = ValueToVolume(volfx);
			SuonoFX.Play();
		}
		else
		{
			Debug.Log("volfx al min");
		}
	}

	public void ChangeOrientation()
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			if (Screen.orientation == ScreenOrientation.LandscapeRight)
			{
				Screen.orientation = ScreenOrientation.LandscapeLeft;
				PlayerPrefs.SetInt("Orientation", 1);
			}
			else
			{
				Screen.orientation = ScreenOrientation.LandscapeRight;
				PlayerPrefs.SetInt("Orientation", 0);
			}
		}
	}

	public void ExitVolume()
	{
		Volume.alpha = 0;
		Volume.interactable = false;
		Volume.blocksRaycasts = false;
		countpag = PlayerPrefs.GetInt("Menupage");
		Pagine[countpag].alpha = 1;
		Pagine[countpag].interactable = true;
		Pagine[countpag].blocksRaycasts = true;
		if(Pagine.Count > 1)
		{
			Freccette.alpha = 1;
			Freccette.interactable = true;
			Freccette.blocksRaycasts = true;
		}
		foreach(var f in FX)
		{
			f.volume = PlayerPrefs.GetFloat("VolFX", 0.6f);
		}
		volt = 0;
	}
	
	public void OpenStats()
	{
		Volume.alpha = 0;
		Volume.interactable = false;
		Volume.blocksRaycasts = false;
		UpdateStats();
		UpdateColors();
		Stats.alpha = 1;
		Stats.interactable = true;
		Stats.blocksRaycasts = true;
	}

	public void DisplayResetDial()
	{
		Stats.blocksRaycasts = false;
		ModalDial.alpha = 1;
		ModalDial.interactable = true;
		ModalDial.blocksRaycasts = true;
	}

	public void ConfirmResetDial()
	{
		for(int i = 0; i < 15; i++)
		{
			PlayerPrefs.SetFloat(StatValues[i], 0);
		}
		UpdateStats();
		Stats.blocksRaycasts = true;
		ModalDial.alpha = 0;
		ModalDial.interactable = false;
		ModalDial.blocksRaycasts = false;
	}

	public void DenyResetDial()
	{
		Stats.blocksRaycasts = true;
		ModalDial.alpha = 0;
		ModalDial.interactable = false;
		ModalDial.blocksRaycasts = false;
	}

	void UpdateColors()
	{
		foreach(var n in StatText)
		{
			if(PlayerPrefs.GetInt(n.gameObject.name.Substring(0, n.gameObject.name.Length - 4), 0) == 1)
			{
				n.color = Color.white;
			}
			else
			{
				n.color = Color.black;
			}
		}
	}

	void UpdateStats()
	{
		for(int i = 0; i < 15; i++)
		{
			if(updated)
			{
				StatText[i].text = StatText[i].text.Substring(0, StatText[i].text.Length - 8);
			}
			TimeSpan timeSpan = TimeSpan.FromSeconds(PlayerPrefs.GetFloat(StatValues[i]));
 			StatText[i].text += string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
		}
		updated = true;
	}

	public void DisplayQuitDial()
	{
		Volume.blocksRaycasts = false;
		QuitDial.alpha = 1;
		QuitDial.interactable = true;
		QuitDial.blocksRaycasts = true;
	}

	public void DenyQuitDial()
	{
		Volume.blocksRaycasts = true;
		QuitDial.alpha = 0;
		QuitDial.interactable = false;
		QuitDial.blocksRaycasts = false;
	}

	private float ValueToVolume(int value)
	{
		switch (value)
		{
			case 0 :
				return 0;

			case 1 :
				return 0.2f;

			case 2 :
				return 0.4f;

			case 3 :
				return 0.6f;

			case 4 :
				return 0.8f;

			case 5 :
				return 1;

			default :
				return 0.6f;
		}
	}

	private int VolumeToValue(float volume)
	{
		return Mathf.RoundToInt(volume * 5);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
