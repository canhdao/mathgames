using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCR_Menu : MonoBehaviour {
	void Start () {
		SCR_Profile.Load ();
	}
	
	void Update () {
	}

	public void OnAddition () {
		SCR_Gameplay.gameMode = GameMode.ADDITION;
		SceneManager.LoadScene ("SCN_Gameplay");
	}

	public void OnSubtraction () {
		SCR_Gameplay.gameMode = GameMode.SUBTRACTION;
		SceneManager.LoadScene ("SCN_Gameplay");
	}

	public void OnMultiplication () {
		SCR_Gameplay.gameMode = GameMode.MULTIPLICATION;
		SceneManager.LoadScene ("SCN_Gameplay");
	}

	public void OnDivision () {
		SCR_Gameplay.gameMode = GameMode.DIVISION;
		SceneManager.LoadScene ("SCN_Gameplay");
	}

	public void OnExponentiation () {
		SCR_Gameplay.gameMode = GameMode.EXPONENTIATION;
		SceneManager.LoadScene ("SCN_Gameplay");
	}

	public void OnSquareRoot () {
		SCR_Gameplay.gameMode = GameMode.SQUARE_ROOT;
		SceneManager.LoadScene ("SCN_Gameplay");
	}
}
