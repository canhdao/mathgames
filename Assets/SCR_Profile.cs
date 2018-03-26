using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Profile {
	private static bool loaded = false;
	private static int bestAddition = 0;
	private static int bestSubtraction = 0;
	private static int bestMultiplication = 0;
	private static int bestDivision = 0;
	private static int bestExponentiation = 0;
	private static int bestSquareRoot = 0;

	public static void Load () {
		if (!loaded) {
			bestAddition = PlayerPrefs.GetInt("bestAddition", 0);
			bestSubtraction = PlayerPrefs.GetInt("bestSubtraction", 0);
			bestMultiplication = PlayerPrefs.GetInt("bestMultiplication", 0);
			bestDivision = PlayerPrefs.GetInt("bestDivision", 0);
			bestExponentiation = PlayerPrefs.GetInt("bestExponentiation", 0);
			bestSquareRoot = PlayerPrefs.GetInt("bestSquareRoot", 0);
			loaded = true;
		}
	}
	
	public static void Save () {
		PlayerPrefs.SetInt("bestAddition", bestAddition);
		PlayerPrefs.SetInt("bestSubtraction", bestSubtraction);
		PlayerPrefs.SetInt("bestMultiplication", bestMultiplication);
		PlayerPrefs.SetInt("bestDivision", bestDivision);
		PlayerPrefs.SetInt("bestExponentiation", bestExponentiation);
		PlayerPrefs.SetInt("bestSquareRoot", bestSquareRoot);
	}
	
	public static int GetBestScore (GameMode gameMode) {
		switch (gameMode) {
		case GameMode.ADDITION:
			return bestAddition;
		case GameMode.SUBTRACTION:
			return bestSubtraction;
		case GameMode.MULTIPLICATION:
			return bestMultiplication;
		case GameMode.DIVISION:
			return bestDivision;
		case GameMode.EXPONENTIATION:
			return bestExponentiation;
		case GameMode.SQUARE_ROOT:
			return bestSquareRoot;
		default:
			return 0;
		}
	}
	
	public static void UpdateBestScore (int score, GameMode gameMode) {
		switch (gameMode) {
		case GameMode.ADDITION:
			if (bestAddition < score) {
				bestAddition = score;
				Save();
			}
			break;
		case GameMode.SUBTRACTION:
			if (bestSubtraction < score) {
				bestSubtraction = score;
				Save();
			}
			break;
		case GameMode.MULTIPLICATION:
			if (bestMultiplication < score) {
				bestMultiplication = score;
				Save();
			}
			break;
		case GameMode.DIVISION:
			if (bestDivision < score) {
				bestDivision = score;
				Save();
			}
			break;
		case GameMode.EXPONENTIATION:
			if (bestExponentiation < score) {
				bestExponentiation = score;
				Save();
			}
			break;
		case GameMode.SQUARE_ROOT:
			if (bestSquareRoot < score) {
				bestSquareRoot = score;
				Save();
			}
			break;
		}
	}
}
