using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SCR_Gameplay : MonoBehaviour {
	public static int s_score = 0;

	public Text question;
	public Text score;
	
	private int first = 1;
	private int second = 1;
	private int result = 2;

	// Use this for initialization
	void Start () {
		s_score = 0;
		question.text = first + " + " + second + "\n= " + result;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	private void NextQuestion () {
		first = Random.Range (0, 10);
		second = Random.Range (0, 10);
		result = first + second + Random.Range (-1, 2);
		
		question.text = first + " + " + second + "\n= " + result;
	}
	
	public void OnRight () {
		if (first + second == result) {
			s_score++;
			score.text = s_score.ToString ();
			NextQuestion ();
		}
		else {
			SceneManager.LoadScene ("SCN_GameOver");
		}
	}
	
	public void OnWrong () {
		if (first + second != result) {
			s_score++;
			score.text = s_score.ToString ();
			NextQuestion ();
		}
		else {
			SceneManager.LoadScene ("SCN_GameOver");
		}
	}
}
