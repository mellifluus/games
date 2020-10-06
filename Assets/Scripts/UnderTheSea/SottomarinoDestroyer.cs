using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SottomarinoDestroyer : MonoBehaviour {

    public GameObject Esplosione, PesceEsplosione;
    Vector3 getPos = new Vector3();
    AudioSource Suono;
    public AudioClip[] s;
    public int collcheck = 0;
    int localcheck;

    void Start()
    {
        Suono = gameObject.GetComponent<AudioSource>();
        localcheck = collcheck;
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        //QUANDO NEL COLLIDER DEL PESCE ENTRA UN TRIGGER COLLIDER, CONTROLLO CHE IL TAG
        //DELL'OGGETTO POSSESSORE DEL TRIGGER SIA GAMBERETTO. SE SI AGGIUNGO UNO ALLA
        //VARIABILE p DELLA CLASSE PuntiGamberetto, ASSEGNO ALLA VARIABILE getPos LA
        //POSIZIONE DEL GAMBERETTO, PER POI INSTANZIARCI UN PREFAB ESPLOSIONE. QUINDI
        //DISTRUGGO IL GAMBERETTO E SUBITO DOPO L'ESPLOSIONE, DOPO UN DELAY=ANIMATION.LENGTH
        if (col.gameObject.CompareTag("Stella"))
        {
            BarraPuntiUnderTheSea.punteggio += 1;
            Suono.clip = s[0];
            Suono.Play();
            getPos = col.transform.position;
            var explosion = Instantiate(Esplosione, getPos, transform.rotation);
            Destroy(col.gameObject);
            Destroy(explosion, explosion.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        }
        else
        {
            //SE IL TAG DEL COLLIDER IN QUESTIONE NON E' GAMBERETTO, SIAMO SICURI SI TRATTI
            //DI UN NEMICO. CONTROLLO CHE IL BOOL HIT SIA FALSE (PER EVITARE PERDITE DI PUNTI
            //IN SUCCESSIONE), ASSEGNO TRUE A HIT E POI TOLGO UN PUNTO DALLA VARIABILE PuntiGamberetto.p.
            //ASSEGNO ALLA VARIABILE getPos LA POSIZIONE DEL NEMICO E CI ISTANZIO UN PREFAB SCOSSA
            //DISTRUGGO QUINDI LA SCOSSA AL TERMINE DELL'ANIMAZIONE, E INVOCO UNA FUNZIONE CHE
            //RI-SETTA HIT IN FALSE DOPO 1 SECONDO SEMPRE PER EVITARE PERDITE DI PUNTI CONTINUATIVE
            BarraPuntiUnderTheSea.punteggio -= 1;
            Suono.clip = s[1];
            Suono.Play();
            getPos = col.transform.position;
            getPos.z = 10f;
            Destroy(col.gameObject);
            var expclone = Instantiate(PesceEsplosione, getPos, transform.rotation);
            Destroy(expclone, expclone.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if(collcheck != localcheck)
        {
            if(col.gameObject.name[8] == 'R')
            {
                gameObject.transform.Translate(-0.2f, 0, 0);
            }
            if(col.gameObject.name[8] == 'B')
            {
                gameObject.transform.Translate(0, 0.2f, 0);
            }
            if(col.gameObject.name[8] == 'S')
            {
                gameObject.transform.Translate(0.2f, 0, 0);
            }
            if(col.gameObject.name[8] == 'T')
            {
                gameObject.transform.Translate(0, -0.2f, 0);
            }
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        localcheck = collcheck;
    }
}
