using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour {

    public float Speed = 1;
    public List<SpriteRenderer> sprites = new List<SpriteRenderer>();
    private float heightCamera;
    private float widthCamera;
    private Vector3 PositionCam;
    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
        float aspect = 16f/9f;
        //heightCamera = 2f * cam.orthographicSize;
        heightCamera = 8f;
        widthCamera = heightCamera * aspect;	
    }

    void Update ()
    {
        foreach (var item in sprites)
        {
            if (item.transform.position.x - item.bounds.size.x / 2 > cam.transform.position.x + (widthCamera / 2) + 2)
            {
                SpriteRenderer sprite = sprites[0];
                foreach (var i in sprites)
                {
                    if (i.transform.position.x < sprite.transform.position.x)
					{
                        sprite = i;
                    }
                }
                item.transform.position = new Vector2((sprite.transform.position.x - (sprite.bounds.size.x / 2) - (item.bounds.size.x / 2)), sprite.transform.position.y);
            }
            item.transform.Translate(new Vector2(Time.deltaTime * Speed, 0));
        }
    }
}
