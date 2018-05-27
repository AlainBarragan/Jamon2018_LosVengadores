using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_UI : MonoBehaviour {

    public static scr_UI UI;

    public GameObject GameOver;
    public scr_History Hystory;
    public Text Tutorial;
    string tutorial;

    private void Awake()
    {
        UI = this;
    }

    // Use this for initialization
    void Start () {
        tutorial = scr_Lang.GetText("txt_game_info_07");
    }

    IEnumerator ShowTutorial()
    {
        yield return new WaitForSeconds(3f);
        while (Tutorial.text.Length<tutorial.Length)
        {
            yield return new WaitForSeconds(0.05f);
            Tutorial.text += tutorial[0];
            tutorial = tutorial.Substring(1);
        }
        yield return new WaitForSeconds(4f);
        tutorial = scr_Lang.GetText("txt_game_info_08");
        Tutorial.text = "";
        while (Tutorial.text.Length < tutorial.Length)
        {
            yield return new WaitForSeconds(0.05f);
            Tutorial.text += tutorial[0];
            tutorial = tutorial.Substring(1);
        }
        yield return new WaitForSeconds(4f);
        Tutorial.gameObject.SetActive(false);
    }

    public void StartTutorial()
    {
        Tutorial.transform.parent.gameObject.SetActive(true);
        Tutorial.text = "";
        StartCoroutine(ShowTutorial());
    }
	
}
