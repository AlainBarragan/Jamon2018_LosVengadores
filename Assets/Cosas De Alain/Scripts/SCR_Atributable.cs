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
    PhysicMaterial phMat, normal;
    Rigidbody rb;

    bool startGravity;
    Vector3 StartPosition;
    Vector3 StartScale;
    Vector3 StartVelocity;
    Quaternion StartRotation;
    ATRIBUTO StartAtributo;

    private void Start()
    {
        phMat = GameManager.phMat;
        normal = GameManager.normal;
        rb = this.GetComponent<Rigidbody>();
        startGravity = rb.useGravity;
        atributo = ATRIBUTO.Neutral;
        this.GetComponent<BoxCollider>().material = normal;
        StartPosition = transform.position;
        StartScale = transform.localScale;
        StartRotation = transform.rotation;
        StartVelocity = rb.velocity;
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
                    //Flotar();
                }
                break;
            case ATRIBUTO.Rebotable:
                break;
            default:
                break;
        }
    }

    public void ResetObject()
    {
        atributo = StartAtributo;
        transform.position = StartPosition;
        transform.rotation = StartRotation;
        transform.localScale = StartScale;
        rb.useGravity = startGravity;
        rb.velocity = StartVelocity;
        this.GetComponent<BoxCollider>().material = normal;
    }

    void Flotar()
    {
        rb.useGravity = false;
        this.transform.Translate(Vector3.up * Time.deltaTime);
    }

    void Atraer()
    {
        if (magnetico.Length > 0)
        {
            for (int i = 0; i < magnetico.Length; i++)
            {
                magnetico[i].GetComponent<Rigidbody>().useGravity = false;
                //magnetico[i].transform.position = Vector3.MoveTowards(magnetico[i].transform.position, this.transform.position, 5 * Time.deltaTime);
                Vector3 direction = (transform.position - magnetico[i].transform.position).normalized;
                magnetico[i].GetComponent<Rigidbody>().MovePosition(magnetico[i].transform.position+(direction*2f * Time.deltaTime));
                if (magnetico[i].GetComponent<scr_plataform>())
                    magnetico[i].GetComponent<scr_plataform>().MovePlayer( new Vector3(direction.x,0f,direction.z)* 1.8f*Time.deltaTime);
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
        if (atr != 0)
            GameManager.GM.SetObjeto(this.gameObject);
        switch (atr)
        {
            case 1:
                {
                    atributo = ATRIBUTO.Iman;
                    Debug.Log("Soy muy atractivo ;)");
                }
                break;
            case 2:
                {
                    atributo = ATRIBUTO.Girar;
                    Debug.Log("Estoy girando yay");
                    Girar();
                }
                break;
            case 3:
                {
                    atributo = ATRIBUTO.Rebotable;
                    Rebotable();
                }
                break;
            case 4:
                {
                    atributo = ATRIBUTO.Gravedad;
                    rb.useGravity = !rb.useGravity;
                    if (!rb.useGravity)
                    {
                        rb.AddForce(Vector3.up, ForceMode.Impulse);
                    }
                    Debug.Log("Aqui todos Flotan");
                }
                break;
            default:
                {
                    atributo = ATRIBUTO.Neutral;
                    Debug.Log("Todo vuelve a la normalidad");
                }
                break;
        }

        if (atributo != ATRIBUTO.Gravedad)
        {
            rb.useGravity = startGravity;
        }

        if (atributo != ATRIBUTO.Iman)
        {
            if (magnetico.Length > 0)
            {
                for (int i = 0; i < magnetico.Length; i++)
                {
                    magnetico[i].GetComponent<Rigidbody>().useGravity = startGravity;
                }
            }
        }
        if (atributo != ATRIBUTO.Rebotable)
        {
            this.GetComponent<BoxCollider>().material = normal;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (rb.velocity.magnitude>2)
        {
            Destroy(Instantiate(GameManager.Fx_Dost, collision.contacts[0].point, Quaternion.identity),2f);
        }
        Rigidbody orb = collision.gameObject.GetComponent<Rigidbody>();
        if (atributo == ATRIBUTO.Rebotable && orb != null)
        {
            if (orb.velocity.magnitude < 10)
                orb.velocity *= 1.5f;

        }
    }
}
