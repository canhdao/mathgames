using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SCR_GameOver : MonoBehaviour {
	public Text score;
	public Text best;

	// Use this for initialization
	void Start() {
		string mode = "";
		switch (SCR_Gameplay.gameMode) {
		case GameMode.ADDITION:
			mode = "(+)";
			break;
		case GameMode.SUBTRACTION:
			mode = "(-)";
			break;
		case GameMode.MULTIPLICATION:
			mode = "(*)";
			break;
		case GameMode.DIVISION:
			mode = "(/)";
			break;
		case GameMode.EXPONENTIATION:
			mode = "(^)";
			break;
		case GameMode.SQUARE_ROOT:
			mode = "(√)";
			break;
		}

		score.text = "Score: " + SCR_Gameplay.s_score.ToString();
		best.text = "Best " + mode + ": " + SCR_Profile.GetBestScore(SCR_Gameplay.gameMode);
	}
	
	// Update is called once per frame
	void Update() {
		
	}
	
	public void OnPlay() {
		SceneManager.LoadScene("SCN_Gameplay");
	}
	
	public void OnMenu() {
		SceneManager.LoadScene("SCN_Menu");
	}
}
