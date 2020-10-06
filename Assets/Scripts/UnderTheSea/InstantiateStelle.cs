using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateStelle : MonoBehaviour {

    public GameObject Stella;
    public Collider2D[] colliders = new Collider2D[5]; 
    public float delay, timer;
    float scaleval;

    //PER ISTANZIARE PERIODICAMENTE, USO UN timer CHE SI SETTA AL VALORE DI delay, CHE INIZIALMENTE 
    //E' DI 0.1 SECONDI PER GARANTIRE L'INIZIO DEL GIOCO VELOCEMENTE. IN Update(), PER OGNI FRAME, 
    //A timer VIENE SOTTRATTO Time.deltaTime (IL TEMPO IMPIEGATO A ELABORARE IL FRAME)
    //QUANDO TIMER RAGGUNGE 0, ASSEGNO UN VALORE CASUALE IN UN RANGE A scaleval E CREO UN VETTORE
    //gamberettoPos CON UNA X FISSA MA CON UNA Y RANDOM IN UN RANGE (UN PO MENO DI SCREEN HEIGHT).
    //ISTANZIO QUINDI IL GAMBERETTO IN POSIZIONE gamberettoPos E SUBITO DOPO LO SCALO PER IL VALORE 
    //DI SCALEVAL, SIA PER X SIA PER Y. ASSEGNO UN NUOVO VALORE CASUALE A delay IN UN RANGE E 
    //RIEQUALIZZO TIMER A DELAY.
    
    void Start()
    {
        delay = 0.1f;
        timer = delay;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && !BarraPuntiUnderTheSea.Win)
        {
            scaleval = Random.Range(1f, 1.4f);
            Vector3 instPos = new Vector3(Random.Range(-100f, -200f), Random.Range(100f, Screen.height - 100f), 10f);
            if(Physics2D.OverlapCircleNonAlloc(Camera.main.ScreenToWorldPoint(instPos), 0.7f, colliders) == 0)
            {
                Instantiate(Stella, Camera.main.ScreenToWorldPoint(instPos), transform.rotation);
                Stella.transform.localScale = new Vector3(scaleval, scaleval, 1);
            }
            delay = Random.Range(0.3f, 0.8f);
            timer = delay;
        }
    }
}
