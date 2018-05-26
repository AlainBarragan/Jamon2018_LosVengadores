using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_Gun : MonoBehaviour {

    public GameObject Cannon;
    public LayerMask MaskShoot;
    public GameObject HitEffect;

    public Text T_TypeW;

    float CD = 0f;
    float CD2 = 0f;

    [HideInInspector]
    int TypeShoot;

    // Use this for initialization
    void Start () {
        TypeShoot = 1;

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("NextW"))
        {
            TypeShoot++;
            if (TypeShoot > 4)
                TypeShoot = 1;
        }

        if (Input.GetButtonDown("PrevW"))
        {
            TypeShoot--;
            if (TypeShoot < 1)
                TypeShoot = 4;
        }

        if (Input.GetAxis("DpadX") > 0.5)
            TypeShoot = 1;
        if (Input.GetAxis("DpadX") < -0.5)
            TypeShoot = 2;
        if (Input.GetAxis("DpadY") < -0.5)
            TypeShoot = 3;
        if (Input.GetAxis("DpadY") > 0.5)
            TypeShoot = 4;

        T_TypeW.text = TypeShoot.ToString();

        if (CD > 0f)
            CD -= Time.deltaTime;
        if (CD2 > 0f)
            CD2 -= Time.deltaTime;

        if (Input.GetButtonDown("Fire1") || Input.GetAxis("Fire1")<-0.5f)
        {
            if (CD<=0f)
            {
                Ray shoot = new Ray(Cannon.transform.position, Cannon.transform.forward);
                RaycastHit hit;
                Physics.Raycast(shoot, out hit, MaskShoot);
                if (hit.transform != null)
                {
                    if (hit.transform.gameObject.CompareTag("Atributable"))
                    {
                        hit.transform.gameObject.SendMessage("CambiarAtributo", TypeShoot);
                    }
                    GameObject hitef = Instantiate(HitEffect, hit.point, Quaternion.identity);
                    Destroy(hitef, 0.5f);
                }
                CD = 0.5f;
            }
        }
        if (Input.GetButtonDown("Fire2") || Input.GetAxis("Fire2") >0.5f)
        {
            if (CD2 <= 0f)
            {
                Ray shoot = new Ray(Cannon.transform.position, Cannon.transform.forward);
                RaycastHit hit;
                Physics.Raycast(shoot, out hit, MaskShoot);
                if (hit.transform != null)
                {
                    if (hit.transform.gameObject.CompareTag("Atributable"))
                    {
                        hit.transform.gameObject.SendMessage("CambiarAtributo", 0);
                    }
                    GameObject hitef = Instantiate(HitEffect, hit.point, Quaternion.identity);
                    Destroy(hitef, 0.5f);
                }
                CD2 = 0.2f;
            }
        }

        Debug.DrawRay(Cannon.transform.position, Cannon.transform.forward, Color.yellow);
    }
}
