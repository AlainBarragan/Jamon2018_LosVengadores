using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	private float score = 0.0f;

	private int diffcultyLevel = 1;
	private int maxDifficultyLevel = 10;
	private int scoreToNextLevel = 20;
	private bool isDead = false;

	public DeathMenu deathMenu;
	public Text scoreText;

	void Update ()
	{
		if (isDead) 
		{
			return;
		}
		if (score >= scoreToNextLevel)
			LevelUp ();
		
		score += Time.deltaTime * diffcultyLevel;
		scoreText.text = ((int)score).ToString ();	
	}

	void LevelUp()
	{

		if (diffcultyLevel == maxDifficultyLevel)
			return;
		
		scoreToNextLevel *= 2;
		diffcultyLevel++;
		GetComponent <PlayerMotor> ().SetSpeed (diffcultyLevel);

		Debug.Log (diffcultyLevel);
	}
	public void OnDeath()
	{
		isDead = true;
		if (PlayerPrefs.GetFloat ("Highscore") < score)
		PlayerPrefs.SetFloat ("Highscore", score);
		deathMenu.EndMenu(score);
	}
}
