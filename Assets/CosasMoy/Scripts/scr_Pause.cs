using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_Pause : MonoBehaviour {

    bool InPause = false;

    public GameObject MenuPause;
    public GameObject Player;
    public GameObject BaseCamera;
    public scr_History History;
	
	// Update is called once per frame
	void Update () {
        if (!History.Desactivado)
            return;

		if (Input.GetButtonDown("Pause"))
        {
            if (InPause)
            {
                Time.timeScale = 1;
            } else
            {
                Time.timeScale = 0;
            }
            InPause = !InPause;
            MenuPause.SetActive(InPause);
            BaseCamera.SetActive(InPause);
            Player.SetActive(!InPause);
        }
	}

    public void Continue()
    {
        Time.timeScale = 1;
        InPause = false;
        MenuPause.SetActive(InPause);
        Player.SetActive(!InPause);
        BaseCamera.SetActive(InPause);
    }

    public void Restart()
    {
        Continue();
        Player.GetComponent<scr_Player>().RestartPlayer();
    }

    public void GoMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
