using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SCR_GameOver : MonoBehaviour {
	public Text score;
	public Text best;

	// Use this for initialization
	void Start () {
		score.text = "Score: " + SCR_Gameplay.s_score.ToString ();
		best.text = "Best: " + SCR_Profile.GetBestScore ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void OnPlay () {
		SceneManager.LoadScene ("SCN_Gameplay");
	}
	
	public void OnMenu () {
		SceneManager.LoadScene ("SCN_Menu");
	}
}
