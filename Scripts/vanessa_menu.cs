using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vanessa_menu : MonoBehaviour
{

    private bool selectedStatus;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Selected()
    {
        if(selectedStatus)
        {
            anim.SetBool("selected", false);
            selectedStatus = false;
        }
        else
        {
            anim.SetBool("selected", true);
            selectedStatus = true;
        }
    }
}
