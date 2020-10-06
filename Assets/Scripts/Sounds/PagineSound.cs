using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PagineSound : MonoBehaviour
{
    int pg = 0;
    public CanvasGroup[] Pagine;

    //DUE FUNZIONI DEDICATE ALLA NAVIGAZIONE DELLE PAGINE DELLA SOUNDBOARD, LE PAGINE 
    //HANNO UN INDEX CHE VA DA 0 A 2. DOPO AVER DECRETATO IL VALORE DI pg, VIENE CHIAMATA
    //PgLoad() CHE IN BASE AL VALORE DI pg ATTIVA E DISATTIVA CERTE PAGINE
    
    public void PgUp()
    {
        EventSystem.current.currentSelectedGameObject.GetComponent<AudioSource>().Play();
		EventSystem.current.currentSelectedGameObject.GetComponent<Animator>().Play("Pressed", -1, 0f);
        Pagine[pg].alpha = 0;
        Pagine[pg].interactable = false;
        Pagine[pg].blocksRaycasts = false;
        AudioSource[] ChildrenAudio = Pagine[pg].GetComponentsInChildren<AudioSource>();
        foreach(var a in ChildrenAudio)
        {
            a.Stop();
        }
        if (pg==2)
        {
            pg = 0;
        }
        else
        {
            pg++;
        }
        Pagine[pg].alpha = 1;
        Pagine[pg].interactable = true;
        Pagine[pg].blocksRaycasts = true;
    }
    
    public void PgDown()
    {
        EventSystem.current.currentSelectedGameObject.GetComponent<AudioSource>().Play();
		EventSystem.current.currentSelectedGameObject.GetComponent<Animator>().Play("Pressed", -1, 0f);
        Pagine[pg].alpha = 0;
        Pagine[pg].interactable = false;
        Pagine[pg].blocksRaycasts = false;
        AudioSource[] ChildrenAudio = Pagine[pg].GetComponentsInChildren<AudioSource>();
        foreach(var a in ChildrenAudio)
        {
            a.Stop();
        }
        if (pg==0)
        {
            pg = 2;
        }
        else
        {
            pg--;
        }
        Pagine[pg].alpha = 1;
        Pagine[pg].interactable = true;
        Pagine[pg].blocksRaycasts = true;
    }
}
