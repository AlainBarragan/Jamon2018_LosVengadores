using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_Gun : MonoBehaviour {

    public GameObject Cannon;
    public LayerMask MaskShoot;

    float CD = 0f;
    float CD2 = 0f;

    public Animator AnimGun;

    public AudioSource Shoot1;
    public AudioSource Shoot2;
    public AudioSource Recharge;

    public Text T_Type;

    Color[] CT = new Color[4] { Color.yellow, Color.green , Color.red , Color.blue };
    string[] sTypes = new string[4];

    [HideInInspector]
    int TypeShoot;

    // Use this for initialization
    void Start () {
        TypeShoot = 1;
        sTypes[0] = scr_Lang.GetText("txt_game_info_02");
        sTypes[1] = scr_Lang.GetText("txt_game_info_03");
        sTypes[2] = scr_Lang.GetText("txt_game_info_04");
        sTypes[3] = scr_Lang.GetText("txt_game_info_05");
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("NextW"))
        {
            TypeShoot++;
            if (TypeShoot > 4)
                TypeShoot = 1;
            Recharge.Play();
        }

        if (Input.GetButtonDown("PrevW"))
        {
            TypeShoot--;
            if (TypeShoot < 1)
                TypeShoot = 4;
            Recharge.Play();
        }

        if (Input.GetAxis("DpadX") > 0.5)
        {
            Recharge.Play();
            TypeShoot = 1;
        }
        if (Input.GetAxis("DpadX") < -0.5)
        {
            TypeShoot = 2;
            Recharge.Play();
        }
        if (Input.GetAxis("DpadY") < -0.5)
        {
            TypeShoot = 3;
            Recharge.Play();
        }
        if (Input.GetAxis("DpadY") > 0.5)
        {
            TypeShoot = 4;
            Recharge.Play();
        }

        T_Type.text = sTypes[TypeShoot - 1];
        T_Type.color = CT[TypeShoot-1];

        if (CD > 0f)
            CD -= Time.deltaTime;
        if (CD2 > 0f)
            CD2 -= Time.deltaTime;

        if (Input.GetButtonDown("Fire1") || Input.GetAxis("Fire1")<-0.5f)
        {   
            if (CD<=0f)
            {
                Shoot1.Play();
                AnimGun.SetTrigger("Shoot");
                GameObject bullet =  Instantiate(GameManager.Bullet, Cannon.transform.position, Cannon.transform.rotation);
                bullet.GetComponent<scr_bullet>().TypeShoot = TypeShoot;
                CD = 0.5f;
            }
        }
        if (Input.GetButtonDown("Fire2") || Input.GetAxis("Fire2") >0.5f)
        {
            if (CD2 <= 0f)
            {
                Shoot2.Play();
                AnimGun.SetTrigger("Shoot");
                GameObject bullet = Instantiate(GameManager.Bullet, Cannon.transform.position, Cannon.transform.rotation);
                CD2 = 0.5f;
            }
        }

    }
}
