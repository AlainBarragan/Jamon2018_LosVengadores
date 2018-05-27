using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Start()
    {
        ResetAchivements();
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
        string achivement = "Logro Desbloqueado: ";
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
        Debug.Log(achivement);
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
