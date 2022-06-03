using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controls : MonoBehaviour
{
    public GameObject Controls;

    private bool status = true;

    public void activeControls()
    {
        if(status)
        {
            Controls.SetActive(true);
            status = false;
        }
        else
        {
            Controls.SetActive(false);
            status = true;
        }
    }
}
