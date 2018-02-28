using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCR_Gameplay : MonoBehaviour {
	public Text question;
	public Text score;
	public Text resultScore;
	public Text resultBest;
	public Text gameOver;

	// Use this for initialization
	void Start () {
		resultScore.enabled = false;
		resultBest.enabled = false;
		gameOver.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
