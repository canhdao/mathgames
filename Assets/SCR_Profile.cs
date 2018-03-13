using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Profile {
	private static bool loaded = false;
	private static int best = 0;

	public static void Load () {
		if (!loaded) {
			best = PlayerPrefs.GetInt("best", 0);
			loaded = true;
		}
	}
	
	public static void Save () {
		PlayerPrefs.SetInt("best", best);
	}
	
	public static int GetBestScore () {
		return best;
	}
	
	public static void UpdateBestScore (int score) {
		if (best < score) {
			best = score;
			Save();
		}
	}
}
