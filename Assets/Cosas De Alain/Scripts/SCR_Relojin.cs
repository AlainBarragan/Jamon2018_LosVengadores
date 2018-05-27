using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCR_Relojin : MonoBehaviour 
{
    public Text hora;

    private void Update()
    {
        int timeH = System.DateTime.Now.Hour;
        int timeM = System.DateTime.Now.Minute;
        string s_timeH, s_timeM;

        if (timeH < 10)
            s_timeH = "0" + timeH.ToString();
        else
            s_timeH = timeH.ToString();

        if (timeM < 10)
            s_timeM = "0" + timeM.ToString();
        else
            s_timeM = timeM.ToString();

        hora.text = s_timeH + " : " + s_timeM;
    }
}
