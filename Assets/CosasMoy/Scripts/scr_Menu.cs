using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scr_Menu : MonoBehaviour {

    public Dropdown Lang;
    public Dropdown Reso;
    public Toggle FullScreen;

    public GameObject Loading;

    public static SaveGameFree.scr_DataPalyer MyData;
    public static string fileName = "PlayerData";

    private void Awake()
    {
        MyData = new SaveGameFree.scr_DataPalyer();

        // Initialize the Saver with the default configurations
        SaveGameFree.Saver.Initialize();
        //MyData = new SaveGameFree.Data_player();
        MyData = SaveGameFree.Saver.Load<SaveGameFree.scr_DataPalyer>(fileName);
        scr_Pstatics.Op_Lang = MyData.Op_Lang;
        scr_Lang.setLanguage();
    }

    // Use this for initialization
    void Start () {
        scr_Pstatics.Op_Resol = MyData.Op_Resol;
        scr_Pstatics.Op_Fullscr = MyData.Op_Fullscr;
        SetResolution();

        Lang.value = scr_Pstatics.Op_Lang;
        Reso.value = scr_Pstatics.Op_Resol;
        FullScreen.isOn = scr_Pstatics.Op_Fullscr;
    }

    public void PlayGame()
    {
        StartCoroutine(LoadGame());
    }

    IEnumerator LoadGame()
    {
        Loading.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        //Load Scene
    }

    public void ChangeLeng()
    {
        scr_Pstatics.Op_Lang = Lang.value;
        scr_Lang.setLanguage();
        SaveDataPlayer();
    }

    public void ChangeResolution()
    {
        scr_Pstatics.Op_Resol = Reso.value;
        SetResolution();
        SaveDataPlayer();
    }

    void SetResolution()
    {
        switch (scr_Pstatics.Op_Resol)
        {
            case 1:
                {
                    Screen.SetResolution(1366, 768, scr_Pstatics.Op_Fullscr);
                }
                break;
            case 2:
                {
                    Screen.SetResolution(1440, 900, scr_Pstatics.Op_Fullscr);
                }
                break;
            case 3:
                {
                    Screen.SetResolution(1920, 1080, scr_Pstatics.Op_Fullscr);
                }
                break;
            default:
                {
                    Screen.SetResolution(1024, 768, scr_Pstatics.Op_Fullscr);
                }
                break;
        }
    }

    public void SetFullScr()
    {
        Screen.fullScreen = FullScreen.isOn;
        scr_Pstatics.Op_Fullscr = FullScreen.isOn;
        SaveDataPlayer();
    }

    public void SaveDataPlayer()
    {
        MyData.Op_Fullscr = scr_Pstatics.Op_Fullscr;
        MyData.Op_Lang = scr_Pstatics.Op_Lang;
        MyData.Op_Resol = scr_Pstatics.Op_Resol;
        SaveGameFree.Saver.Save(MyData, fileName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
