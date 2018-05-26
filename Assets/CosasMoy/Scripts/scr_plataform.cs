using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_plataform : MonoBehaviour {

    private GameObject target;

    // Use this for initialization
    void Start () {
        target = null;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MovePlayer(Vector3 mov)
    {
        if (target != null)
        {
            target.transform.Translate(mov,Space.World);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log("GetPlayer");
            target = col.gameObject;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            target = null;
        }
    }
}
