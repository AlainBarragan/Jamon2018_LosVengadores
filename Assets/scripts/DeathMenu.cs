using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeathMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	public void EndMenu (float score)
	{
		gameObject.SetActive (true);
	}

	public void Restart()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void Quit()
	{
		Application.Quit ();
	}
}
