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
	
	private int first = 0;
	private int second = 0;
	private int result = 0;

	private int lastFirst = 0;
	private int lastSecond = 0;
	
	private float time = 0;

	void Start() {
		SCR_Profile.Load();
		
		s_score = 0;

		NextQuestion();
	}
	
	void Update() {
		if (time < TIMEOUT) {
			time += Time.deltaTime;
			if (time >= TIMEOUT) time = TIMEOUT;
			timeRect.anchorMax = new Vector2((TIMEOUT - time) / TIMEOUT, timeRect.anchorMax.y);
		}
		else {
			SceneManager.LoadScene("SCN_GameOver");
		}
	}
	
	private void IncreaseScore() {
		s_score++;
		score.text = s_score.ToString();
		SCR_Profile.UpdateBestScore(s_score);
	}
	
	private void NextQuestion() {
		while (first == lastFirst && second == lastSecond) {
			first = Random.Range (1, 10);
			second = Random.Range (1, 10);
		}

		lastFirst = first;
		lastSecond = second;

		int r = Random.Range(0, 2);

		if (r == 0) {
			// right answer
			result = first + second;
		}
		else {
			// wrong answer
			r = Random.Range(0, 2);

			if (r == 0) {
				r = -1;
			}

			result = first + second + r;
		}

		question.text = first + " + " + second + "\n= " + result;
		
		time = 0;
		timeRect.anchorMax = new Vector2(1, timeRect.anchorMax.y);
	}
	
	public void OnRight() {
		if (first + second == result) {
			IncreaseScore();
			NextQuestion();
		}
		else {
			SceneManager.LoadScene("SCN_GameOver");
		}
	}
	
	public void OnWrong() {
		if (first + second != result) {
			IncreaseScore();
			NextQuestion();
		}
		else {
			SceneManager.LoadScene("SCN_GameOver");
		}
	}
}
