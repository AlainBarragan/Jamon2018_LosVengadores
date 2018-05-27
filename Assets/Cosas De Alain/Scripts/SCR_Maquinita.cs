using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Maquinita : MonoBehaviour 
{
    bool enrRango = false;

    public bool GetEnRango()
    {
        return enrRango;
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("Player"))
            enrRango = true;
    }

    private void OnTriggerExit(Collider c)
    {
        if (c.CompareTag("Player"))
            enrRango = false;
    }
}