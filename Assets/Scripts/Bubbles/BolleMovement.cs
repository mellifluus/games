using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolleMovement : MonoBehaviour {

    public float speed = 2f;
	
    //SCRIPT ASSEGNATO A TUTTE LE BOLLE, DETTA LA DIREZIONE E VELOCITA DEL MOVIMENTO
    //E GRAZIE A OnBecameInvisible() LA LORO AUTODISTRUZIONE ALL'USCITA DAL DISPLAY
    
    void Update () 
	{
        transform.Translate(new Vector2(0, 1) * speed * Time.deltaTime);
	}
    
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
