using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameMode {
	ADDITION,
	SUBTRACTION,
	MULTIPLICATION,
	DIVISION,
	EXPONENTIATION,
	SQUARE_ROOT
}

public class SCR_Gameplay : MonoBehaviour {
	private const float TIMEOUT = 2;

	public static GameMode gameMode = GameMode.ADDITION;

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
		SCR_Profile.UpdateBestScore(s_score, gameMode);
	}

	private void NextAddition() {
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
	}

	private void NextSubtraction() {
		while (first == lastFirst && second == lastSecond) {
			first = Random.Range (1, 10);
			second = Random.Range (1, 10);
			first += second;
		}

		lastFirst = first;
		lastSecond = second;

		int r = Random.Range(0, 2);

		if (r == 0) {
			// right answer
			result = first - second;
		}
		else {
			// wrong answer
			r = Random.Range(0, 2);

			if (r == 0) {
				r = -1;
			}

			result = first - second + r;
		}

		question.text = first + " - " + second + "\n= " + result;
	}

	private void NextMultiplication() {
	}

	private void NextDivision() {
	}

	private void NextExponentiation() {
	}

	private void NextSquareRoot() {
	}

	private void NextQuestion() {
		switch (gameMode) {
			case GameMode.ADDITION:
				NextAddition();
				break;
			case GameMode.SUBTRACTION:
				NextSubtraction();
				break;
			case GameMode.MULTIPLICATION:
				NextMultiplication();
				break;
			case GameMode.DIVISION:
				NextDivision();
				break;
			case GameMode.EXPONENTIATION:
				NextExponentiation();
				break;
			case GameMode.SQUARE_ROOT:
				NextSquareRoot();
				break;
		}

		time = 0;
		timeRect.anchorMax = new Vector2(1, timeRect.anchorMax.y);
	}

	private bool CheckAnswer() {
		bool right = true;

		switch (gameMode) {
		case GameMode.ADDITION:
			right = (first + second == result);
			break;
		case GameMode.SUBTRACTION:
			right = (first - second == result);
			break;
		case GameMode.MULTIPLICATION:
			right = (first * second == result);
			break;
		case GameMode.DIVISION:
			right = (first / second == result);
			break;
		case GameMode.EXPONENTIATION:
			right = (Mathf.RoundToInt(Mathf.Pow(first, second)) == result);
			break;
		case GameMode.SQUARE_ROOT:
			right = (Mathf.RoundToInt(Mathf.Sqrt(first)) == result);
			break;
		}

		return right;
	}

	public void OnRight() {
		if (CheckAnswer()) {
			IncreaseScore();
			NextQuestion();
		}
		else {
			SceneManager.LoadScene("SCN_GameOver");
		}
	}
	
	public void OnWrong() {
		if (!CheckAnswer()) {
			IncreaseScore();
			NextQuestion();
		}
		else {
			SceneManager.LoadScene("SCN_GameOver");
		}
	}
}
