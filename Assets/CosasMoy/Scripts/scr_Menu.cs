using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scr_Menu : MonoBehaviour {

    public GameObject Loading;

    public Dropdown Resolution;
    public Dropdown Weapon;
    public Toggle FullScr;

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
        scr_Pstatics.WpModel = MyData.Op_ModelWp;
        Resolution.value = scr_Pstatics.Op_Resol;
        FullScr.isOn = scr_Pstatics.Op_Fullscr;
        Weapon.value = scr_Pstatics.WpModel;
        SetResolution();
    }

    public void PlayGame()
    {
        StartCoroutine(LoadGame());
    }

    IEnumerator LoadGame()
    {
        Loading.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("Game");
    }

    public void ChangeLeng(int lan)
    {
        scr_Pstatics.Op_Lang = lan;
        scr_Lang.setLanguage();
        SaveDataPlayer();
    }

    public void ChangeResolution()
    {
        scr_Pstatics.Op_Resol = Resolution.value;
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
        Screen.fullScreen = FullScr.isOn;
        scr_Pstatics.Op_Fullscr = FullScr.isOn;
        SaveDataPlayer();
    }

    public void SetModelWp()
    {
        scr_Pstatics.WpModel = Weapon.value;
        SaveDataPlayer();
    }

    public void SaveDataPlayer()
    {
        MyData.Op_Fullscr = scr_Pstatics.Op_Fullscr;
        MyData.Op_Lang = scr_Pstatics.Op_Lang;
        MyData.Op_Resol = scr_Pstatics.Op_Resol;
        MyData.Op_ModelWp = scr_Pstatics.WpModel;
        SaveGameFree.Saver.Save(MyData, fileName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
