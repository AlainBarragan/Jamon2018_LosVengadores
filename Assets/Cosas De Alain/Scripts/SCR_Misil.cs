using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Misil : MonoBehaviour 
{
    Transform player;

    private void Start()
    {
        player = FindObjectOfType<scr_Player>().transform;
    }

    private void Update()
    {
        this.transform.LookAt(player);
        this.transform.position = Vector3.MoveTowards(this.transform.position, player.position, 8f * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision c)
    {
        if(c.gameObject.CompareTag("Player"))
        {
            c.gameObject.SendMessage("Die");
        }
        Destroy(Instantiate(GameManager.Fx_Explo, transform.position, Quaternion.identity), 5f);
        Destroy(this.gameObject);
    }
}
