using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCR_PongMeta : MonoBehaviour 
{
    public Text text;

    int puntuacion = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        puntuacion++;
        text.text = puntuacion.ToString();
        reiniciar();
    }

    public void reiniciar()
    {
        SCR_Bolita_Pong bol = FindObjectOfType<SCR_Bolita_Pong>();
        bol.transform.localPosition = Vector2.zero;
        bol.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.right * 30;
    }
}
