using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateNemici : MonoBehaviour {

    public GameObject Nemico;
    public Collider2D[] colliders = new Collider2D[5]; 
    public float delay, timer;

    void Start()
    {
        delay = 1.5f;
        timer = delay;
    }
    //PER ISTANZIARE PERIODICAMENTE, USO UN timer CHE SI SETTA AL VALORE DI delay, CHE INIZIALMENTE 
    //E' DI 1.5 SECONDI PER GARANTIRE L'INIZIO DEL GIOCO VELOCEMENTE. IN Update(), PER OGNI FRAME, 
    //A timer VIENE SOTTRATTO Time.deltaTime (IL TEMPO IMPIEGATO A ELABORARE IL FRAME)
    //QUANDO TIMER RAGGUNGE 0, CREO UN VETTORE nemicoPos CON UNA X FISSA MA CON UNA Y RANDOM IN UN RANGE
    //(UN PO MENO DI SCREEN HEIGHT).
    //ISTANZIO QUINDI IL NEMICO IN POSIZIONE nemicoPos. ASSEGNO UN NUOVO VALORE CASUALE A delay IN UN RANGE E 
    //RIEQUALIZZO TIMER A DELAY.
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && !BarraPuntiUnderTheSea.Win)
        {
            Vector3 nemicoPos = new Vector3(-400f, Random.Range(100f, Screen.height - 100f), 10f);
            if(Physics2D.OverlapCircleNonAlloc(Camera.main.ScreenToWorldPoint(nemicoPos), 0.7f, colliders) == 0)
            {
                Instantiate(Nemico, Camera.main.ScreenToWorldPoint(nemicoPos), transform.rotation);
            }
            delay = Random.Range(1f, 4f);
            timer = delay;
        }
    }
}