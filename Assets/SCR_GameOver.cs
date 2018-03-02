using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCR_GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
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
