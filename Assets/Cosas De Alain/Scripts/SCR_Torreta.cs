using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Torreta : MonoBehaviour 
{
    public GameObject misil;

    bool disparar;
    float timer;
    Transform player;

    private void Start()
    {
        player = FindObjectOfType<scr_Player>().transform;
        timer = 0;
        disparar = false;
    }

    private void Update()
    {
        if (Vector3.Distance(player.position, this.transform.position) < 50)
            disparar = true;
        else
            disparar = false;

        if (disparar)
        {
            timer += Time.deltaTime;
            if (timer >= 10)
            {
                timer = 0;
                Instantiate(misil, this.transform);
            }
        }
    }
}
