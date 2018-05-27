using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_NewWindow : MonoBehaviour {

    public Button NewSelected;

    private void OnEnable()
    {
        NewSelected.Select();
    }
}
