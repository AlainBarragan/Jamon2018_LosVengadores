using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_UI : MonoBehaviour {

    public static scr_UI UI;

    public GameObject GameOver;
    public scr_History Hystory;

    private void Awake()
    {
        UI = this;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
