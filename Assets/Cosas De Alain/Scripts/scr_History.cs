using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scr_History : MonoBehaviour {

    string[] Dialogos = new string[5];

    int Idx = 0;

    public string Sindex = "";
    public string Stitle = "";

    public Text Show;
    public Text Title;

    public bool Desactivado = false;

    public GameObject Player;
    public GameObject BaseCamera;

    bool IsEnd;

    public AudioSource VOX;

    // Use this for initialization
    void Start () {
        IsEnd = false;
        Sindex = "";
        Idx = 0;
        SetHistory(0);
        Player.SetActive(false);
        BaseCamera.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Run") || Input.GetKeyDown(KeyCode.X))
        {
            NextText();
        }
	}

    IEnumerator TextLoop()
    {
        while(Idx< Dialogos.Length)
        {
            yield return new WaitForSeconds(0.05f);
            if (Title.text.Length < Dialogos[0].Length)
            {
                Title.text += Stitle[0];
                Stitle = Stitle.Substring(1);
            } else if (Show.text.Length < Dialogos[Idx].Length)
            {
                Show.text += Sindex[0];
                Sindex = Sindex.Substring(1);
            }
        }
    }

    public void NextText()
    {
        if (Desactivado)
            return;

        if (Show.text!= Dialogos[Idx])
        {
            Show.text = Dialogos[Idx];
            return;
        }

        Idx++;
        if (Idx<Dialogos.Length)
        {
            Sindex = Dialogos[Idx];
            Show.text = "";
        } else
        {
            Desactivado = true;
            StopAllCoroutines();
            if (!IsEnd)
            {
                Player.SetActive(true);
                BaseCamera.SetActive(false);
                GetComponent<Animator>().SetTrigger("FadeOut");
                scr_UI.UI.StartTutorial();
            } else
            {
                SceneManager.LoadScene("Menu", LoadSceneMode.Single);
            }
        }
    }

    public void SetHistory(int index)
    {
        switch(index)
        {
            case 0:
                {
                    Dialogos[0] = scr_Lang.GetText("txt_history_01");
                    Dialogos[1] = scr_Lang.GetText("txt_history_02");
                    Dialogos[2] = scr_Lang.GetText("txt_history_03");
                    Dialogos[3] = scr_Lang.GetText("txt_history_04");
                    Dialogos[4] = scr_Lang.GetText("txt_history_05");
                }
                break;
            case 1:
                {
                    Dialogos[0] = scr_Lang.GetText("txt_history_06");
                    Dialogos[1] = scr_Lang.GetText("txt_history_07");
                    Dialogos[2] = scr_Lang.GetText("txt_history_08");
                    Dialogos[3] = scr_Lang.GetText("txt_history_09");
                    Dialogos[4] = scr_Lang.GetText("txt_history_10");
                    IsEnd = true;
                }
                break;
            case 2:
                {
                    Dialogos[0] = scr_Lang.GetText("txt_history_11");
                    Dialogos[1] = scr_Lang.GetText("txt_history_12");
                    Dialogos[2] = scr_Lang.GetText("txt_history_13");
                    Dialogos[3] = scr_Lang.GetText("txt_history_14");
                    Dialogos[4] = scr_Lang.GetText("txt_history_15");
                    IsEnd = true;
                    VOX.Play();
                }
                break;
        }
        Desactivado = false;
        Title.text = Stitle = Dialogos[0];
        Idx = 1;
        Sindex = Dialogos[Idx];
        Show.text = "";
        Title.text = "";
        StopAllCoroutines();
        StartCoroutine(TextLoop());
        if (IsEnd)
        {
            Player.SetActive(false);
            BaseCamera.SetActive(true);
            GetComponent<Animator>().SetTrigger("FadeIn");
        }
    }
}
