using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SceltaGiochi : MonoBehaviour
{
    public CanvasGroup[] Menus;
    public GameObject ButtHolder;
    public Text[] Testi;
    public CanvasGroup Stats, ErrorDial, ApplyDial;
    public Button[] Buttons;
    int npag, nbut, resto, cont;

    void Awake()
    {
        
    }

    void Start()
    {
        npag = 0;
        nbut = 0;
        cont = 0;
        ChangeMenu();
        if(gameObject.GetComponent<Menu>().Pagine.Count == 1)
        {
            gameObject.GetComponent<Menu>().Freccette.alpha = 0;
            gameObject.GetComponent<Menu>().Freccette.interactable = false;
            gameObject.GetComponent<Menu>().Freccette.blocksRaycasts = false;
        }     
    }

    void Update()
    {

    }

    public void SelezioneGioco()
    {
        if(EventSystem.current.currentSelectedGameObject.GetComponent<Text>().color == Color.black)
        {
            EventSystem.current.currentSelectedGameObject.GetComponent<Text>().color = Color.white;
        }
        else
        {
            EventSystem.current.currentSelectedGameObject.GetComponent<Text>().color = Color.black;
        }
    }

    public void ApplyChanges()
    {
        DontApplyChanges();
        int nb = 0;
        foreach(var n in Testi)
		{
			if(n.color == Color.white)
			{
                nb++;
			}
		}
        if(nb > 0)
        {
            foreach(var n in Testi)
		    {
			    if(n.color == Color.white)
			    {
				    PlayerPrefs.SetInt(n.gameObject.name.Substring(0, n.gameObject.name.Length - 4), 1);
			    }
                else
                {
                    PlayerPrefs.SetInt(n.gameObject.name.Substring(0, n.gameObject.name.Length - 4), 0);
                }
		    }
            ResetVars();
            ChangeMenu();
            ReturnToMenu();
        }
        else
        {
            DisplayErrorDial();
        }
    }

    void ChangeMenu()
    {
        SetNPag();
        SetButtons();
    }

    void SetNPag()
    {
        foreach(var b in Buttons)
        {
            if(b.gameObject.name == "CartoonWorld" || b.gameObject.name == "WorldCreator")
            {
                if(PlayerPrefs.GetInt(b.gameObject.name, 0) == 1)
                {
                    nbut++;
                }
            }
            else
            {
                if(PlayerPrefs.GetInt(b.gameObject.name, 1) == 1)
                {
                    nbut++;
                }
            }
        }
        if(nbut % 4 == 0)
        {
            npag = nbut / 4;
            resto = 0;
        }
        else
        {
            npag = (nbut / 4) + 1;
            resto = nbut % 4;
        }
        switch(npag)
        {
            case 4:
               	break;
            case 3:
               	gameObject.GetComponent<Menu>().Pagine.RemoveAt(3);
               	break;
            case 2:
               	gameObject.GetComponent<Menu>().Pagine.RemoveAt(3);
                gameObject.GetComponent<Menu>().Pagine.RemoveAt(2);
               	break;
            case 1:
               	gameObject.GetComponent<Menu>().Pagine.RemoveAt(3);
                gameObject.GetComponent<Menu>().Pagine.RemoveAt(2);
                gameObject.GetComponent<Menu>().Pagine.RemoveAt(1);
               	break;
        }
    }

    void SetButtons()
    {
        List<Button> SelectedButtons = new List<Button>();
        foreach(var b in Buttons)
        {
            if(b.gameObject.name == "CartoonWorld" || b.gameObject.name == "WorldCreator")
            {
                if(PlayerPrefs.GetInt(b.gameObject.name, 0) == 1)
                {
                    SelectedButtons.Add(b);
                }
            }
            else
            {
                if(PlayerPrefs.GetInt(b.gameObject.name, 1) == 1)
                {
                    SelectedButtons.Add(b);
                }
            }
        }
        switch(npag)
        {
            case 4:
                for(int i = 0; i < 3; i++)
                {
                    SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[i].gameObject.transform);
                    SelectedButtons[cont].transform.localPosition = new Vector2(-240, 200);
                    cont++;
                    SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[i].gameObject.transform);
                    SelectedButtons[cont].transform.localPosition = new Vector2(240, 200);
                    cont++;
                    SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[i].gameObject.transform);
                    SelectedButtons[cont].transform.localPosition = new Vector2(-240, -200);
                    cont++;
                    SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[i].gameObject.transform);
                    SelectedButtons[cont].transform.localPosition = new Vector2(240, -200);
                    cont++;
                }
                switch(resto)
                {
                    case 0:
                        SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[3].gameObject.transform);
                        SelectedButtons[cont].transform.localPosition = new Vector2(-240, 200);
                        cont++;
                        SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[3].gameObject.transform);
                        SelectedButtons[cont].transform.localPosition = new Vector2(240, 200);
                        cont++;
                        SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[3].gameObject.transform);
                        SelectedButtons[cont].transform.localPosition = new Vector2(-240, -200);
                        cont++;
                        SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[3].gameObject.transform);
                        SelectedButtons[cont].transform.localPosition = new Vector2(240, -200);
                        cont++;
                        break;
                    case 1:
                        SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[gameObject.GetComponent<Menu>().gameObject.GetComponent<Menu>().Pagine.Count - 1].gameObject.transform);
                        SelectedButtons[cont].transform.localPosition = new Vector2(0, 0);
                        cont++; 
                        break;
                    case 2:
                        SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[gameObject.GetComponent<Menu>().gameObject.GetComponent<Menu>().Pagine.Count - 1].gameObject.transform);
                        SelectedButtons[cont].transform.localPosition = new Vector2(-240, 0);
                        cont++; 
                        SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[gameObject.GetComponent<Menu>().gameObject.GetComponent<Menu>().Pagine.Count - 1].gameObject.transform);
                        SelectedButtons[cont].transform.localPosition = new Vector2(240, 0);
                        cont++;
                        break;
                    case 3:
                        SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[gameObject.GetComponent<Menu>().gameObject.GetComponent<Menu>().Pagine.Count - 1].gameObject.transform);
                        SelectedButtons[cont].transform.localPosition = new Vector2(-240, 200);
                        cont++; 
                        SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[gameObject.GetComponent<Menu>().gameObject.GetComponent<Menu>().Pagine.Count - 1].gameObject.transform);
                        SelectedButtons[cont].transform.localPosition = new Vector2(240, 200);
                        cont++;
                        SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[gameObject.GetComponent<Menu>().gameObject.GetComponent<Menu>().Pagine.Count - 1].gameObject.transform);
                        SelectedButtons[cont].transform.localPosition = new Vector2(0, -200);
                        cont++;
                        break;
                }
               	break;
            case 3:
               	for(int i = 0; i < 2; i++)
                {
                    SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[i].gameObject.transform);
                    SelectedButtons[cont].transform.localPosition = new Vector2(-240, 200);
                    cont++;
                    SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[i].gameObject.transform);
                    SelectedButtons[cont].transform.localPosition = new Vector2(240, 200);
                    cont++;
                    SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[i].gameObject.transform);
                    SelectedButtons[cont].transform.localPosition = new Vector2(-240, -200);
                    cont++;
                    SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[i].gameObject.transform);
                    SelectedButtons[cont].transform.localPosition = new Vector2(240, -200);
                    cont++;
                }
                switch(resto)
                {
                    case 0:
                        SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[2].gameObject.transform);
                        SelectedButtons[cont].transform.localPosition = new Vector2(-240, 200);
                        cont++;
                        SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[2].gameObject.transform);
                        SelectedButtons[cont].transform.localPosition = new Vector2(240, 200);
                        cont++;
                        SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[2].gameObject.transform);
                        SelectedButtons[cont].transform.localPosition = new Vector2(-240, -200);
                        cont++;
                        SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[2].gameObject.transform);
                        SelectedButtons[cont].transform.localPosition = new Vector2(240, -200);
                        cont++;
                        break;
                    case 1:
                        SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[gameObject.GetComponent<Menu>().gameObject.GetComponent<Menu>().Pagine.Count - 1].gameObject.transform);
                        SelectedButtons[cont].transform.localPosition = new Vector2(0, 0);
                        cont++; 
                        break;
                    case 2:
                        SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[gameObject.GetComponent<Menu>().gameObject.GetComponent<Menu>().Pagine.Count - 1].gameObject.transform);
                        SelectedButtons[cont].transform.localPosition = new Vector2(-240, 0);
                        cont++; 
                        SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[gameObject.GetComponent<Menu>().gameObject.GetComponent<Menu>().Pagine.Count - 1].gameObject.transform);
                        SelectedButtons[cont].transform.localPosition = new Vector2(240, 0);
                        cont++;
                        break;
                    case 3:
                        SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[gameObject.GetComponent<Menu>().gameObject.GetComponent<Menu>().Pagine.Count - 1].gameObject.transform);
                        SelectedButtons[cont].transform.localPosition = new Vector2(-240, 200);
                        cont++; 
                        SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[gameObject.GetComponent<Menu>().gameObject.GetComponent<Menu>().Pagine.Count - 1].gameObject.transform);
                        SelectedButtons[cont].transform.localPosition = new Vector2(240, 200);
                        cont++;
                        SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[gameObject.GetComponent<Menu>().gameObject.GetComponent<Menu>().Pagine.Count - 1].gameObject.transform);
                        SelectedButtons[cont].transform.localPosition = new Vector2(0, -200);
                        cont++;
                        break;
                }
               	break;
            case 2:
                SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[0].gameObject.transform);
                SelectedButtons[cont].transform.localPosition = new Vector2(-240, 200);
                cont++;
                SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[0].gameObject.transform);
                SelectedButtons[cont].transform.localPosition = new Vector2(240, 200);
                cont++;
                SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[0].gameObject.transform);
                SelectedButtons[cont].transform.localPosition = new Vector2(-240, -200);
                cont++;
                SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[0].gameObject.transform);
                SelectedButtons[cont].transform.localPosition = new Vector2(240, -200);
                cont++;
                switch(resto)
                {
                    case 0:
                        SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[1].gameObject.transform);
                        SelectedButtons[cont].transform.localPosition = new Vector2(-240, 200);
                        cont++;
                        SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[1].gameObject.transform);
                        SelectedButtons[cont].transform.localPosition = new Vector2(240, 200);
                        cont++;
                        SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[1].gameObject.transform);
                        SelectedButtons[cont].transform.localPosition = new Vector2(-240, -200);
                        cont++;
                        SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[1].gameObject.transform);
                        SelectedButtons[cont].transform.localPosition = new Vector2(240, -200);
                        cont++;
                        break;
                    case 1:
                        SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[gameObject.GetComponent<Menu>().gameObject.GetComponent<Menu>().Pagine.Count - 1].gameObject.transform);
                        SelectedButtons[cont].transform.localPosition = new Vector2(0, 0);
                        cont++; 
                        break;
                    case 2:
                        SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[gameObject.GetComponent<Menu>().gameObject.GetComponent<Menu>().Pagine.Count - 1].gameObject.transform);
                        SelectedButtons[cont].transform.localPosition = new Vector2(-240, 0);
                        cont++; 
                        SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[gameObject.GetComponent<Menu>().gameObject.GetComponent<Menu>().Pagine.Count - 1].gameObject.transform);
                        SelectedButtons[cont].transform.localPosition = new Vector2(240, 0);
                        cont++;
                        break;
                    case 3:
                        SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[gameObject.GetComponent<Menu>().gameObject.GetComponent<Menu>().Pagine.Count - 1].gameObject.transform);
                        SelectedButtons[cont].transform.localPosition = new Vector2(-240, 200);
                        cont++; 
                        SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[gameObject.GetComponent<Menu>().gameObject.GetComponent<Menu>().Pagine.Count - 1].gameObject.transform);
                        SelectedButtons[cont].transform.localPosition = new Vector2(240, 200);
                        cont++;
                        SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[gameObject.GetComponent<Menu>().gameObject.GetComponent<Menu>().Pagine.Count - 1].gameObject.transform);
                        SelectedButtons[cont].transform.localPosition = new Vector2(0, -200);
                        cont++;
                        break;
                }
               	break;
            case 1:
               	switch(resto)
                {
                    case 0:
                        SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[0].gameObject.transform);
                        SelectedButtons[cont].transform.localPosition = new Vector2(-240, 200);
                        cont++;
                        SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[0].gameObject.transform);
                        SelectedButtons[cont].transform.localPosition = new Vector2(240, 200);
                        cont++;
                        SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[0].gameObject.transform);
                        SelectedButtons[cont].transform.localPosition = new Vector2(-240, -200);
                        cont++;
                        SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[0].gameObject.transform);
                        SelectedButtons[cont].transform.localPosition = new Vector2(240, -200);
                        cont++;
                        break;
                    case 1:
                        SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[gameObject.GetComponent<Menu>().gameObject.GetComponent<Menu>().Pagine.Count - 1].gameObject.transform);
                        SelectedButtons[cont].transform.localPosition = new Vector2(0, 0); 
                        break;
                    case 2:
                        SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[gameObject.GetComponent<Menu>().gameObject.GetComponent<Menu>().Pagine.Count - 1].gameObject.transform);
                        SelectedButtons[cont].transform.localPosition = new Vector2(-240, 0);
                        cont++; 
                        SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[gameObject.GetComponent<Menu>().gameObject.GetComponent<Menu>().Pagine.Count - 1].gameObject.transform);
                        SelectedButtons[cont].transform.localPosition = new Vector2(240, 0);
                        cont++;
                        break;
                    case 3:
                        SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[gameObject.GetComponent<Menu>().gameObject.GetComponent<Menu>().Pagine.Count - 1].gameObject.transform);
                        SelectedButtons[cont].transform.localPosition = new Vector2(-240, 200);
                        cont++; 
                        SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[gameObject.GetComponent<Menu>().gameObject.GetComponent<Menu>().Pagine.Count - 1].gameObject.transform);
                        SelectedButtons[cont].transform.localPosition = new Vector2(240, 200);
                        cont++;
                        SelectedButtons[cont].transform.SetParent(gameObject.GetComponent<Menu>().Pagine[gameObject.GetComponent<Menu>().gameObject.GetComponent<Menu>().Pagine.Count - 1].gameObject.transform);
                        SelectedButtons[cont].transform.localPosition = new Vector2(0, -200);
                        cont++;
                        break;
                }
               	break; 
        }
    }

    void ResetVars()
    {
        npag = 0;
        nbut = 0;
        resto = 0;
        cont = 0;
        gameObject.GetComponent<Menu>().Pagine.Clear();
        foreach(var m in Menus)
        {
            gameObject.GetComponent<Menu>().Pagine.Add(m);
        }
        foreach(var b in Buttons)
        {
            b.transform.SetParent(ButtHolder.transform);
        }
    }

    public void ReturnToMenu()
    {
        Stats.alpha = 0;
        Stats.interactable = false;
        Stats.blocksRaycasts = false;
        PlayerPrefs.SetInt("Menupage", 0);
        gameObject.GetComponent<Menu>().countpag = 0;
        gameObject.GetComponent<Menu>().Pagine[gameObject.GetComponent<Menu>().countpag].alpha = 1;
        gameObject.GetComponent<Menu>().Pagine[gameObject.GetComponent<Menu>().countpag].interactable = true;
        gameObject.GetComponent<Menu>().Pagine[gameObject.GetComponent<Menu>().countpag].blocksRaycasts = true;
        if(gameObject.GetComponent<Menu>().Pagine.Count > 1)
        {
            gameObject.GetComponent<Menu>().Freccette.alpha = 1;
            gameObject.GetComponent<Menu>().Freccette.interactable = true;
            gameObject.GetComponent<Menu>().Freccette.blocksRaycasts = true;
        }
    }

    public void ReturnToMenuButton()
    {
        int nb = 0;
        foreach(var n in Testi)
		{
			if(n.color == Color.white)
			{
                nb++;
			}
		}
        if(nb != 0)
        {
            Stats.alpha = 0;
            Stats.interactable = false;
            Stats.blocksRaycasts = false;
            gameObject.GetComponent<Menu>().countpag = PlayerPrefs.GetInt("Menupage", 0);
            gameObject.GetComponent<Menu>().Pagine[gameObject.GetComponent<Menu>().countpag].alpha = 1;
            gameObject.GetComponent<Menu>().Pagine[gameObject.GetComponent<Menu>().countpag].interactable = true;
            gameObject.GetComponent<Menu>().Pagine[gameObject.GetComponent<Menu>().countpag].blocksRaycasts = true;
            if(gameObject.GetComponent<Menu>().Pagine.Count > 1)
            {
                gameObject.GetComponent<Menu>().Freccette.alpha = 1;
                gameObject.GetComponent<Menu>().Freccette.interactable = true;
                gameObject.GetComponent<Menu>().Freccette.blocksRaycasts = true;
            }
        }
        else
        {
            DisplayErrorDial();
        }
    }

    public void DisplayErrorDial()
	{
		Stats.blocksRaycasts = false;
		ErrorDial.alpha = 1;
		ErrorDial.interactable = true;
		ErrorDial.blocksRaycasts = true;
	}

	public void AcknowledgeError()
	{
		Stats.blocksRaycasts = true;
		ErrorDial.alpha = 0;
		ErrorDial.interactable = false;
		ErrorDial.blocksRaycasts = false;
	}

    public void DisplayChangesDial()
    {
        Stats.blocksRaycasts = false;
		ApplyDial.alpha = 1;
		ApplyDial.interactable = true;
		ApplyDial.blocksRaycasts = true;
    }

    public void DontApplyChanges()
    {
        Stats.blocksRaycasts = true;
		ApplyDial.alpha = 0;
		ApplyDial.interactable = false;
		ApplyDial.blocksRaycasts = false;
    }
}
