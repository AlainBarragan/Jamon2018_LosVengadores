using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
    public static GameManager GM;

    GameObject ObjetoAtributo;

    public static int Leng = 0;

    private void Awake()
    {
        GM = this;
    }

    public void SetObjeto(GameObject go)
    {
        if (ObjetoAtributo != null)
            ObjetoAtributo.GetComponent<SCR_Atributable>().CambiarAtributo(0);
        ObjetoAtributo = go;
    }
}
