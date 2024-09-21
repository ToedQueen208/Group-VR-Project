using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_MenuQuit : MonoBehaviour {

    public GameObject MenuQuit;
    public GameObject CreditScroll;

    public void MenuQuitPopUp ()
    {
        CreditScroll.SetActive(false);
        MenuQuit.SetActive(true);
        Cursor.visible = true;
    }
}
