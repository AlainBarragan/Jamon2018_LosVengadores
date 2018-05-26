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

    [HideInInspector]
    int TypeShoot;

    // Use this for initialization
    void Start () {
        TypeShoot = 0;

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("NextW"))
        {
            TypeShoot++;
            if (TypeShoot > 3)
                TypeShoot = 0;
            T_TypeW.text = TypeShoot.ToString();
        }

        if (Input.GetButtonDown("PrevW"))
        {
            TypeShoot--;
            if (TypeShoot < 0)
                TypeShoot = 3;
            T_TypeW.text = TypeShoot.ToString();
        }

        if (CD > 0f)
            CD -= Time.deltaTime;

        if (Input.GetButtonDown("Fire1") || Input.GetAxis("Fire1")<-0.5f)
        {
            if (CD<=0f)
            {
                Debug.Log("Shoot 0");
                Ray shoot = new Ray(Cannon.transform.position, Cannon.transform.forward);
                RaycastHit hit;
                Physics.Raycast(shoot, out hit, MaskShoot);
                if (hit.transform != null)
                {
                    Debug.Log("Shoot 1");
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

        Debug.DrawRay(Cannon.transform.position, Cannon.transform.forward, Color.yellow);
    }
}
