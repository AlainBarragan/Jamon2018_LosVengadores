using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

	public Text highscoreText;

	void Start ()
	{
		highscoreText.text = "Highscore : " + (int)PlayerPrefs.GetFloat ("Highscore");
	}


	

    public void ToGame()
	{
		SceneManager.LoadScene ("Game");
	}

	public void Quitting()
	{
		Application.Quit ();
	}
}
