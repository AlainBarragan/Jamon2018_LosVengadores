using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SCR_Achivements : MonoBehaviour 
{
    /* 
     * usar grador primera vez = 0
     * usar rebotador primera vez = 1
     * usar gravedad primera vez = 2
     * usar iman primera vez = 3
     * ganar juego = 4
     * final secreto = 5
     * usar maquinita = 6
     * konami code = 7
    */


    public Text achText;
    float timer;
        
    private void Start()
    {
        achText.text = "";
        timer = 0;
        ResetAchivements();
    }

    private void Update()
    {
        if (timer < 5)
            timer += Time.deltaTime;
        else if (timer >= 5)
        {
            achText.text = "";
        }
    }

    public void CheckAchivement(int num)
    {
        string key = "Ach" + num.ToString();
        if (PlayerPrefs.GetInt(key) == 0)
        {
            PlayerPrefs.SetInt(key, 1);
            GetAchivement(num);
        }
    }

    void GetAchivement(int num)
    {
        string achivement = "";
        switch (num)
        {
            case 1:
                {
                    achivement = achivement +  "Boing!!";
                }
                break;
            case 2:
                {
                    achivement = achivement + "Aqui todos floatan";
                }
                break;
            case 3:
                {
                    achivement = achivement + "Que la fuerza te acompañe";
                }
                break;
            case 4:
                {
                    achivement = achivement + "El Fin?";
                }
                break;
            case 5:
                {
                    achivement = achivement + "Un giro inespreado";
                }
                break;
            case 6:
                {
                    achivement = achivement + "Jugador Retro";
                }
                break;
            case 7:
                {
                    achivement = achivement + "Este no es un juego de konami";
                }
                break;
            default:
                achivement = achivement + "y aun asi gira";
                break;
        }
        achText.text =  achivement;
        timer = 0;
    }

    void ResetAchivements()
    {
        for (int i = 0; i < 8; i++)
        {
            string key = "Ach" + i.ToString();
            PlayerPrefs.SetInt(key, 0);
        }
    }
}
