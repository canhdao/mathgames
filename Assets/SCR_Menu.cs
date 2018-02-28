using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCR_Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnAddition () {
		SceneManager.LoadScene ("SCN_Gameplay");
	}

	public void OnSubtraction () {
		SceneManager.LoadScene ("SCN_Gameplay");
	}

	public void OnMultiplication () {
		SceneManager.LoadScene ("SCN_Gameplay");
	}

	public void OnDivision () {
		SceneManager.LoadScene ("SCN_Gameplay");
	}

	public void OnExponentiation () {
		SceneManager.LoadScene ("SCN_Gameplay");
	}

	public void OnSquareRoot () {
		SceneManager.LoadScene ("SCN_Gameplay");
	}
}
