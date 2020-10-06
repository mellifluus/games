using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RunnerLogic : MonoBehaviour {

	public CanvasGroup CharScreen, Game;
	public GameObject Sfondi;
	public Text tredueuno;
	Vector3 startPos;
	GameObject character;
	bool isJumping = true;
	
	// Use this for initialization
	void Start () {
		startPos = new Vector2(-3.1f, -2.14f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SceltaChar()
	{
		string c = EventSystem.current.currentSelectedGameObject.name;
		character = Instantiate(Resources.Load<GameObject>("ForestRide/" + c), startPos, Quaternion.identity);
		character.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("VolFX");
		CharScreen.alpha = 0;
		CharScreen.interactable = false;
		CharScreen.blocksRaycasts = false;
		Game.alpha = 1;
		Game.interactable = true;
		Game.blocksRaycasts = true;
		StartCoroutine(StartGame());
	}

	IEnumerator StartGame()
	{
		character.GetComponent<Animator>().SetTrigger("StartRunning");
		Sfondi.GetComponent<BackgroundScrollRunner>().enabled = true;
		Game.gameObject.GetComponent<SpawnerRunner>().enabled = true;
		isJumping = false;
		yield return 0;
	}

	public void Jump()
	{
		if(!isJumping && character.GetComponent<DestroyerRunner>().isGrounded)
		{
			isJumping = true;
			character.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 300);
			gameObject.GetComponent<AudioSource>().Play();
			character.GetComponent<Animator>().SetTrigger("Jump");
			character.GetComponent<CapsuleCollider2D>().enabled = true;
			Invoke("ResetJump", character.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
		}
	}

	void ResetJump()
	{
		isJumping = false;
		character.GetComponent<CapsuleCollider2D>().enabled = false;
	}
}
