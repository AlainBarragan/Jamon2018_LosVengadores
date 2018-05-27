using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
    public static GameManager GM;

    GameObject ObjetoAtributo;

    public static PhysicMaterial phMat;
    public static PhysicMaterial normal;
    public static GameObject Bullet;
    public static GameObject Fx_Dost;
    public static GameObject Fx_Spark;
    public static GameObject Fx_Explo;

    private void Awake()
    {
        GM = this;
        scr_Lang.setLanguage();

        phMat = Resources.Load("Boing") as PhysicMaterial;
        if (phMat == null) { Debug.LogError("Error Loading prefab"); }

        normal = Resources.Load("Normal") as PhysicMaterial;
        if (normal == null) { Debug.LogError("Error Loading prefab"); }

        Fx_Spark = Resources.Load("PS_BulletImpact") as GameObject;
        if (Fx_Spark == null) { Debug.LogError("Error Loading prefab"); }

        Bullet = Resources.Load("PS_Bullet") as GameObject;
        if (Bullet == null) { Debug.LogError("Error Loading prefab"); }

        Fx_Dost = Resources.Load("PS_Dust") as GameObject;
        if (Fx_Dost == null) { Debug.LogError("Error Loading prefab"); }

        Fx_Explo = Resources.Load("PS_Explo") as GameObject;
        if (Fx_Explo == null) { Debug.LogError("Error Loading prefab"); }
    }

    public GameObject getObjeto()
    {
        return ObjetoAtributo;
    }

    public void SetObjeto(GameObject go)
    {
        if (go == ObjetoAtributo)
            return;

        if (ObjetoAtributo != null)
            ObjetoAtributo.GetComponent<SCR_Atributable>().CambiarAtributo(0);
        ObjetoAtributo = go;
    }
}
