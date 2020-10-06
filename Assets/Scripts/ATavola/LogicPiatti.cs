using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogicPiatti : MonoBehaviour {

	public int score;
	int scoreold;
	public bool counting = false;
	int scorecounter;
	float duration = 0.8f;
	TextMeshProUGUI text;
	
	void Start () 
	{
		score = 0;
		scoreold = 0;
		scorecounter = 0;
		text = gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
		text.text = scorecounter.ToString() + " kcal";
	}

	void Update () 
	{
		if(score != scoreold && !counting)
		{
			//duration =(((score - scoreold) / 3) / 100);
			StartCoroutine(CountTo(scoreold, score));
		}
	}

	IEnumerator CountTo (int start, int target) 
	{
		counting = true;
		scoreold = score;
		for (float timer = 0; timer < duration; timer += Time.deltaTime) 
		{
			float progress = timer / duration;
			scorecounter = (int)Mathf.Lerp (start, target, progress);
			text.text = scorecounter.ToString() + " kcal";
			yield return null;
		}
		scorecounter = target;
		text.text = scorecounter.ToString() + " kcal";
		counting = false;
	}
}
