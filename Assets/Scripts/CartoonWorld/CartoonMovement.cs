using UnityEngine;

public class CartoonMovement : MonoBehaviour {

	public float speed = 0;
	public int dir = -1;
	
	void Update () {
		gameObject.transform.Translate(new Vector2(Time.deltaTime * speed * dir, 0));
	}

	void OnBecameInvisible() 
	{
        Destroy(gameObject);
    }
}