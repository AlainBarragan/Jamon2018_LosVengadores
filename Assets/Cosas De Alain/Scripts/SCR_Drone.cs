using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Drone : MonoBehaviour 
{
    public GameObject Cannon;
    public LayerMask MaskShoot;

    float dist;
    Transform obj;
    GameManager gm;
    float CD2 = 0f;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }


    private void Update()
    {
        if (CD2 > 0f)
            CD2 -= Time.deltaTime;

        if (GameManager.GM.getObjeto() == null || GameManager.GM.getObjeto().GetComponent<SCR_Atributable>().atributo == SCR_Atributable.ATRIBUTO.Neutral)
            return;

        obj = GameManager.GM.getObjeto().transform;

        if (Vector3.Distance(obj.position, this.transform.position) > 30)
            return;


        this.transform.LookAt(obj);
        if (Vector3.Distance(obj.position, this.transform.position) > 10)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, obj.transform.position, 5 * Time.deltaTime);
        }
        else
        {
            if (CD2 <= 0f)
            {
                int num = 0;
                Ray shoot = new Ray(Cannon.transform.position, Cannon.transform.forward);
                RaycastHit hit;
                Physics.Raycast(shoot, out hit, MaskShoot);
                if (hit.transform != null)
                {
                    if (hit.transform.gameObject.CompareTag("Atributable"))
                    {
                        hit.transform.gameObject.SendMessage("CambiarAtributo", num);
                    }
                    GameObject hitef = Instantiate(GameManager.Fx_Spark, hit.point, Quaternion.identity);
                    Destroy(hitef, 0.5f);
                }
                CD2 = 10.0f;
            }
        }
    }
}