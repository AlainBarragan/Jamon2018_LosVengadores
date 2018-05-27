using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Door : MonoBehaviour {

    Animator Anim;

    public bool Closed = false;

	// Use this for initialization
	void Start () {
        Anim = GetComponent<Animator>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !Closed)
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
