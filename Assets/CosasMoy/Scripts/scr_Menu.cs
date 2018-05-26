using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_Menu : MonoBehaviour {

    public Dropdown Lang;

    private void Awake()
    {
        scr_Lang.setLanguage();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeLeng()
    {
        scr_Lang.language = "English";
        if (Lang.value==1)
            scr_Lang.language = "Spanish";
        scr_Lang.setLanguage();
    }

    public void ChangeResolution()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
