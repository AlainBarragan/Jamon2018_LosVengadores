using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Player : MonoBehaviour {

    [HideInInspector]
    public GameObject LastCheckPoint;

    public bool Death;

    public static int Deaths = 0;

    SCR_Achivements achivements;

	// Use this for initialization
	void Start () {
        Death = false;
        achivements = FindObjectOfType<SCR_Achivements>();
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Restart") && LastCheckPoint!=null )
        {
            foreach(SCR_Atributable obj in FindObjectsOfType<SCR_Atributable>())
            {
                obj.ResetObject();
            }
            transform.position = LastCheckPoint.transform.position;
            transform.rotation = Quaternion.identity;
            if (Death)
            {
                GetComponent<scr_Gun>().enabled = true;
                GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
                Death = false;
                scr_UI.UI.GameOver.SetActive(false);
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KillZone") && !Death)
        {
            Die();
        }
        if (other.CompareTag("ChekPoint"))
        {
            LastCheckPoint = other.gameObject;
        }
        if (other.gameObject.CompareTag("Atributable"))
        {
            if (other.gameObject.GetComponent<SCR_Atributable>().atributo == SCR_Atributable.ATRIBUTO.Rebotable && other.transform.position.y<transform.position.y)
                gameObject.SendMessage("Jump", 18f);
        }
        if (other.CompareTag("WinGame"))
        {
            scr_UI.UI.Hystory.SetHistory(1);
            achivements.CheckAchivement(4);
        }
        if (other.CompareTag("OtherEnd"))
        {
            scr_UI.UI.Hystory.SetHistory(2);
            achivements.CheckAchivement(5);
        }
    }

    public void Die()
    {
        GetComponent<scr_Gun>().enabled = false;
        GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
        Death = true;
        Deaths++;
        scr_UI.UI.GameOver.SetActive(true);
    }

}
