using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRunner : MonoBehaviour {

	public float speed;

    void Update () 
	{
        transform.Translate(new Vector2(-1, 0) * speed * Time.deltaTime);
	}
    
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
