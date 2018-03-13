using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SCR_Gameplay : MonoBehaviour {
	private const float TIMEOUT = 2;

	public static int s_score = 0;
	
	public Text question;
	public Text score;
	
	public RectTransform timeRect;
	
	private int first = 1;
	private int second = 1;
	private int result = 2;
	
	private float time = 0;

	// Use this for initialization
	void Start () {
		SCR_Profile.Load ();
		
		s_score = 0;
		question.text = first + " + " + second + "\n= " + result;
	}
	
	// Update is called once per frame
	void Update () {
		if (time < TIMEOUT) {
			time += Time.deltaTime;
			if (time >= TIMEOUT) time = TIMEOUT;
			timeRect.anchorMax = new Vector2((TIMEOUT - time) / TIMEOUT, timeRect.anchorMax.y);
		}
		else {
			SceneManager.LoadScene ("SCN_GameOver");
		}
	}
	
	private void IncreaseScore () {
		s_score++;
		score.text = s_score.ToString ();
		SCR_Profile.UpdateBestScore (s_score);
	}
	
	private void NextQuestion () {
		first = Random.Range (1, 10);
		second = Random.Range (1, 10);
		result = first + second + Random.Range (-1, 2);
		
		question.text = first + " + " + second + "\n= " + result;
		
		time = 0;
		timeRect.anchorMax = new Vector2(1, timeRect.anchorMax.y);
	}
	
	public void OnRight () {
		if (first + second == result) {
			IncreaseScore ();
			NextQuestion ();
		}
		else {
			SceneManager.LoadScene ("SCN_GameOver");
		}
	}
	
	public void OnWrong () {
		if (first + second != result) {
			IncreaseScore ();
			NextQuestion ();
		}
		else {
			SceneManager.LoadScene ("SCN_GameOver");
		}
	}
}
