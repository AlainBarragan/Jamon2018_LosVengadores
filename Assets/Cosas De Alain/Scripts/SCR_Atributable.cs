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
    public PhysicMaterial phMat;

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
        this.transform.Translate(Vector3.up * Time.deltaTime);
    }

    void Atraer()
    {
        if (magnetico.Length > 0)
        {
            for (int i = 0; i < magnetico.Length; i++)
            {
                magnetico[i].GetComponent<Rigidbody>().useGravity = false;
                magnetico[i].transform.position = Vector3.MoveTowards(magnetico[i].transform.position, this.transform.position, 5 * Time.deltaTime);
            }
        }
    }

    void Girar()
    {
        this.transform.Rotate(0, 0, 15);
    }
    
    void Rebotable()
    {
        this.GetComponent<BoxCollider>().material = phMat;
    }

    public void CambiarAtributo(int atr)
    {
        FindObjectOfType<GameManager>().SetObjeto(this.gameObject);
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
                Rebotable();
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

        if (atributo != ATRIBUTO.Iman)
        {
            if (magnetico.Length > 0)
            {
                for (int i = 0; i < magnetico.Length; i++)
                {
                    magnetico[i].GetComponent<Rigidbody>().useGravity = true;
                }
            }
        }
        if (atributo != ATRIBUTO.Rebotable)
        {
            this.GetComponent<BoxCollider>().material = null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        if (atributo == ATRIBUTO.Rebotable && rb != null)
        {
            if (rb.velocity.magnitude < 10)
                rb.velocity *= 1.5f;
        }

    }
}
