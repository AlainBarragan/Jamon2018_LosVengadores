using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Atributable : MonoBehaviour
{
    public enum ATRIBUTO
    {
        Neutral,
        Iman,
        Girar,
        Rebotable,
        Gravedad
    }

    public ATRIBUTO atributo;
    public GameObject[] magnetico; 

    GameObject[] gos;

    private void Start()
    {
        atributo = ATRIBUTO.Neutral;

    }

    private void Update()
    {
        if (atributo == ATRIBUTO.Neutral)
            return;

        switch (atributo)
        {
            case ATRIBUTO.Iman:
                {
                    Atraer();
                }
                break;
            case ATRIBUTO.Girar:
                break;
            case ATRIBUTO.Gravedad:
                {
                    Flotar();
                }
                break;
            case ATRIBUTO.Rebotable:
                break;
            default:
                break;
        }
    }

    void Flotar()
    {
        this.GetComponent<Rigidbody>().useGravity = false;
        this.transform.Translate(Vector3.up);
    }

    void Atraer()
    {

    }

    void Girar()
    {
        this.transform.Rotate(0, 0, 15);
    }

    private void OnCollisionEnter(Collision c)
    {
        if (atributo == ATRIBUTO.Rebotable)
        {
            Vector3 dir = c.contacts[0].point - transform.position;
            dir = -dir.normalized;
            GetComponent<Rigidbody>().AddForce(dir * 10);
            Debug.Log("Boing");
        }
    }

    public void CambiarAtributo(int atr)
    {
        switch (atr)
        {
            case 1:
                atributo = ATRIBUTO.Iman;
                Debug.Log("Soy muy atractivo ;)");
                break;
            case 2:
                atributo = ATRIBUTO.Girar;
                Debug.Log("Estoy girando yay");
                Girar();
                break;
            case 3:
                atributo = ATRIBUTO.Rebotable;
                break;
            case 4:
                atributo = ATRIBUTO.Gravedad;
                Debug.Log("Aqui todos Flotan");
                break;
            default:
                atributo = ATRIBUTO.Neutral;
                Debug.Log("Todo vuelve a la normalidad");
                break;
        }
        if (atributo != ATRIBUTO.Gravedad)
        {
            this.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
