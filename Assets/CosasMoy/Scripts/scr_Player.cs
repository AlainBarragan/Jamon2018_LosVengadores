﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Player : MonoBehaviour {

    [HideInInspector]
    public GameObject LastCheckPoint;
    public GameObject pong;

    Camera cam;
    SCR_Maquinita maquinita;
    public bool Death;
    public bool jugando;
    bool hayMaquinita;

    public static int Deaths = 0;

    SCR_Achivements achivements;

    public Animator AnimGun;

    public AudioSource GameOver;
    public AudioSource Restart;

    // Use this for initialization
    void Start ()
    {
        hayMaquinita = true;
        cam = Camera.main;
        maquinita = FindObjectOfType<SCR_Maquinita>();
        if (maquinita == null)
            hayMaquinita = false;
        Death = false;
        achivements = FindObjectOfType<SCR_Achivements>();
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Restart") && LastCheckPoint!=null )
        {
            RestartPlayer();
        }
        if (Input.GetButtonDown("PlayMaquinita") && maquinita.GetEnRango() && !jugando && hayMaquinita)
        {
            jugando = true;
            pong.SetActive(true);
            cam.gameObject.SetActive(false);
            GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
            FindObjectOfType<SCR_PongMeta>().reiniciar();
        }
        else if (Input.GetButtonDown("PlayMaquinita") && jugando)
        {
            jugando = false;
            pong.SetActive(false);
            GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
            cam.gameObject.SetActive(true);
        }

    }

    public void RestartPlayer()
    {
        foreach (SCR_Atributable obj in FindObjectsOfType<SCR_Atributable>())
        {
            obj.ResetObject();
        }
        transform.position = LastCheckPoint.transform.position;
        transform.rotation = Quaternion.identity;
        if (Death)
        {
            GetComponent<scr_Gun>().enabled = true;
            GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
            Death = false;
            scr_UI.UI.GameOver.SetActive(false);
            AnimGun.SetTrigger("Restart");
        }
        Restart.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KillZone") && !Death)
        {
            Die();
        }
        if (other.CompareTag("ChekPoint"))
        {
            LastCheckPoint = other.gameObject;
        }
        if (other.gameObject.CompareTag("Atributable"))
        {
            if (other.gameObject.GetComponent<SCR_Atributable>().atributo == SCR_Atributable.ATRIBUTO.Rebotable && other.transform.position.y<transform.position.y)
                gameObject.SendMessage("Jump", 18f);
        }
        if (other.CompareTag("WinGame"))
        {
            scr_UI.UI.Hystory.SetHistory(1);
            achivements.CheckAchivement(4);
        }
        if (other.CompareTag("OtherEnd"))
        {
            scr_UI.UI.Hystory.SetHistory(2);
            achivements.CheckAchivement(5);
        }
    }

    public void Die()
    {
        GetComponent<scr_Gun>().enabled = false;
        GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
        Death = true;
        AnimGun.SetTrigger("Die");
        Deaths++;
        scr_UI.UI.GameOver.SetActive(true);
        GameOver.Play();
    }

}
