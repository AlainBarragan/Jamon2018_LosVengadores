using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_AgujeroNegro : MonoBehaviour {

    GameObject TargetForce;

    public float Force = 2f;

	// Use this for initialization
	void Start () {
        TargetForce = null;
    }

    private void FixedUpdate()
    {
        if (TargetForce!=null)
        {
            Vector3 force = (transform.position - TargetForce.gameObject.transform.position).normalized;
            TargetForce.transform.Translate(force* Force*Time.deltaTime,Space.World);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("OnRange");
            TargetForce = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TargetForce = null;
        }
    }
}
