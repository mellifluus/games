using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour {
	
	public Joystick joystick;
	Rigidbody2D rigid2d;
	public float speed;

	public void Start()
	{
		if (Display.displays.Length > 1)
        {
            Display.displays[1].Activate();
        }
		joystick=FindObjectOfType<Joystick>();
		rigid2d = GetComponent<Rigidbody2D>();
	}

	public void Update()
	{
		rigid2d.velocity = new Vector3 (joystick.Horizontal * speed, joystick.Vertical * speed);
	}
}