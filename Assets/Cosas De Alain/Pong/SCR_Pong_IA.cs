using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Pong_IA : MonoBehaviour 
{
    public Transform bolita;

    private void Update()
    {
        this.transform.position = Vector3.MoveTowards(new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z),new Vector3(this.transform.position.x, bolita.transform.position.y, this.transform.position.z), 5 * Time.deltaTime);
    }
}
