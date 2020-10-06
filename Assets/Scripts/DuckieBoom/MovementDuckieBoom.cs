using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDuckieBoom : MonoBehaviour
{

	public float speed;
	private int check=0;
    private int dir;

	void Start()
	{
        if (gameObject.GetComponent<SpriteRenderer>().flipX)
        {
            dir = 1;
        }
        else
        {
            dir = -1;
        }
		StartCoroutine(Check());
	}

	IEnumerator Check()
	{
		yield return new WaitForSeconds(1.4f);
		check = 1;
		yield return new WaitForSeconds(5f);
		check = 2;
		yield return new WaitForSeconds(1.4f);
		Destroy(gameObject);
	}
	
	void Update()
	{
		if (check == 0)
		{
			transform.Translate(new Vector2(dir, 2) * speed * Time.deltaTime);
		}

		if (check == 1)
		{
			transform.Translate(new Vector2(dir, 0) * speed * Time.deltaTime);
		}
		
		if (check == 2)
		{
			transform.Translate(new Vector2(dir, -2) * speed * Time.deltaTime);
		}
	}
}
