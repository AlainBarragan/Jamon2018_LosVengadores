using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_bullet : MonoBehaviour {

    public int TypeShoot = 0;

    private void Start()
    {
        transform.GetChild(TypeShoot).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(transform.forward*12f*Time.deltaTime,Space.World);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Atributable"))
        {
            other.gameObject.SendMessage("CambiarAtributo", TypeShoot);
        }
        //transform.GetChild(0).parent = null;
        Destroy(Instantiate(GameManager.Fx_Spark, transform.position, Quaternion.identity),2f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //transform.GetChild(0).parent = null;
        Destroy(Instantiate(GameManager.Fx_Spark, transform.position, Quaternion.identity), 2f);
        Destroy(gameObject);
    }
}
