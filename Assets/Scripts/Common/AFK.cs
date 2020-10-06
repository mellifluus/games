using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AFK : MonoBehaviour
{

    float timer = 0;
    Vector3 mousepos;

    //SEMPLICE SCRIPT CHE CONTINUA AD AGGIORNARE UN TIMER IN BACKGROUND IN OGNI GIOCO.
    //IL TIMER VIENE AZZERATO OGNI QUALVOLTA IL GIOCO RICEVE UN INPUT QUALSIASI
    //SE NON RICEVE ALCUN INPUT PER 60 SECONDI, IL GIOCO TORNA AL MENU PRINCIPALE
    
    void Update()
    {
        if (Input.anyKeyDown || Input.mousePosition != mousepos)
        {
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }
        if (timer >= 60)
        {
            timer = gameObject.GetComponent<StatTimer>().timerstat - 60;
            switch(SceneManager.GetActiveScene().name)
            {
                case "TheMask":
                    PlayerPrefs.SetFloat("TimerTheMask", (PlayerPrefs.GetFloat("TimerTheMask") + timer));
                    break;
                case "ATavola":
                    PlayerPrefs.SetFloat("TimerATavola", (PlayerPrefs.GetFloat("TimerATavola") + timer));
                    break;
                case "Bubbles":
                    PlayerPrefs.SetFloat("TimerBubbles", (PlayerPrefs.GetFloat("TimerBubbles") + timer));
                    break;
                case "CartoonWorld":
                    PlayerPrefs.SetFloat("TimerCartoonWorld", (PlayerPrefs.GetFloat("TimerCartoonWorld") + timer));
                    break;
                case "DuckieBoom":
                    PlayerPrefs.SetFloat("TimerDuckieBoom", (PlayerPrefs.GetFloat("TimerDuckieBoom") + timer));
                    break;
                case "ForestRide":
                    PlayerPrefs.SetFloat("TimerForestRide", (PlayerPrefs.GetFloat("TimerForestRide") + timer));
                    break;
                case "JellyPop":
                    PlayerPrefs.SetFloat("TimerJellyPop", (PlayerPrefs.GetFloat("TimerJellyPop") + timer));
                    break;
                case "Memory":
                    PlayerPrefs.SetFloat("TimerMemory", (PlayerPrefs.GetFloat("TimerMemory") + timer));
                    break;
                case "OmbreTerrificanti":
                    PlayerPrefs.SetFloat("TimerOmbreTerrificanti", (PlayerPrefs.GetFloat("TimerOmbreTerrificanti") + timer));
                    break;
                case "Riciclando":
                    PlayerPrefs.SetFloat("TimerRiciclando", (PlayerPrefs.GetFloat("TimerRiciclando") + timer));
                    break;
                case "Shape":
                    PlayerPrefs.SetFloat("TimerShape", (PlayerPrefs.GetFloat("TimerShape") + timer));
                    break;
                case "Suoni":
                    PlayerPrefs.SetFloat("TimerSuoni", (PlayerPrefs.GetFloat("TimerSuoni") + timer));
                    break;
                case "UnderTheSea":
                    PlayerPrefs.SetFloat("TimerUnderTheSea", (PlayerPrefs.GetFloat("TimerUnderTheSea") + timer));
                    break;
                case "WorldCreator":
                    PlayerPrefs.SetFloat("TimerWorldCreator", (PlayerPrefs.GetFloat("TimerWorldCreator") + timer));
                    break;
                case "XiloPlay":
                    PlayerPrefs.SetFloat("TimerXiloPlay", (PlayerPrefs.GetFloat("TimerXiloPlay") + timer));
                    break;
		    }
		    SceneManager.LoadScene("Menu");
        }
        mousepos = Input.mousePosition;
    }
}