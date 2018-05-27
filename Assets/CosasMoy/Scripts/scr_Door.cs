using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Door : MonoBehaviour {

    Animator Anim;

	// Use this for initialization
	void Start () {
        Anim = GetComponent<Animator>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Anim.SetBool("Open", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Anim.SetBool("Open", false);
        }
    }
}
