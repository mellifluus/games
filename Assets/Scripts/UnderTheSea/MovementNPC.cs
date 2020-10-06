using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementNPC : MonoBehaviour {

    public float speed;

    //SCRIPT ASSEGNATO A GAMBERETTI E NEMICI, DETTA LA DIREZIONE E VELOCITA DEL MOVIMENTO
    //E GRAZIE A OnBecameInvisible() LA LORO AUTODISTRUZIONE ALL'USCITA DAL DISPLAY
    
    void Update()
    {
        transform.Translate(new Vector2(1, 0) * speed * Time.deltaTime);
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
