using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerBolle : MonoBehaviour {

    Animator anim;
    bool cliccato;
    AudioSource Suono;
    
    //OGNI VOLTA CHE SI CLICCA SULLA BOLLA A CUI QUESTO SCRIPT E' ASSEGNATO, OnMouseDown()
    //SI ATTIVA, E DOPO AVER CONTROLLATO CHE CLICCATO SIA FALSE, LA ASSEGNA A TRUE,
    //DI MODO CHE NON SIANO PIU POSSIBILI INTERAZIONI FINO ALLA DISTRUZIONE DI QUESTA BOLLA.
    //FACCIO PARTIRE IL SUONO DELL'ESPLOSIONE QUINDI AZIONO IL TRIGGER "Pop" DELL'ANIMATOR
    //CHE AVVIA L'ANIMAZIONE DI DISTRUZIONE E QUINDI DESTROY CON UN DELAY == ALLA DURATA
    //DELL'ANIMAZIONE. ASSEGNO INFINE UN PUNTO ALLA VARIABILE punteggio DELLA CLASSE BarraPuntiBolle
    
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
		Suono = gameObject.GetComponent<AudioSource>();
        Suono.volume *= PlayerPrefs.GetFloat("VolFX", 0.6f);
    }

    void OnMouseDown()
    {
        if (!cliccato && !BarraPuntiBolle.Win)
        {
            cliccato = true;
            anim.SetTrigger("Pop"); 
            Suono.Play();
            Destroy(gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
            if(gameObject.name == "Bolla(Clone)")
            {
				BarraPuntiBolle.punteggio += 1;
                Camera.main.GetComponent<Easter_Egg>().counte = 0;
            }
            else if(gameObject.name == "BollaBomba(Clone)")
            {
				BarraPuntiBolle.punteggio -= 1;
                if(Camera.main.GetComponent<Easter_Egg>().counte >= 20 && Camera.main.GetComponent<Easter_Egg>().counte <= 24)
                {
                    Camera.main.GetComponent<Easter_Egg>().counte++;
                }
                else
                {
                    Camera.main.GetComponent<Easter_Egg>().counte = 0;
                }
            }
            else if(gameObject.name == "BollaRegalo(Clone)")
            {
				BarraPuntiBolle.punteggio += 5;
                Camera.main.GetComponent<Easter_Egg>().counte = 0;
            }
            else if(gameObject.name == "BollaFragola(Clone)")
            {
                BarraPuntiBolle.punteggio += 2;
                if(Camera.main.GetComponent<Easter_Egg>().counte >= 10 && Camera.main.GetComponent<Easter_Egg>().counte <= 19)
                {
                    Camera.main.GetComponent<Easter_Egg>().counte++;
                }
                else
                {
                    Camera.main.GetComponent<Easter_Egg>().counte = 0;
                }
            }
            else if(gameObject.name == "BollaDolcetto(Clone)")
            {
                BarraPuntiBolle.punteggio += 10;
                if(Camera.main.GetComponent<Easter_Egg>().counte >= 0 && Camera.main.GetComponent<Easter_Egg>().counte <= 9)
                {
                    Camera.main.GetComponent<Easter_Egg>().counte++;
                }
                else
                {
                    Camera.main.GetComponent<Easter_Egg>().counte = 0;
                }
            }
        }
    }
}
