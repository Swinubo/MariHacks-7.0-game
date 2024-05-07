using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setThrowFalse : MonoBehaviour
{
    
    private Animator anim;

    private void Start()
    {
        anim = GameObject.Find("Arm").GetComponent<Animator>();
    }

    private void setFalse()
    {
        anim.SetBool("throwing", false);
    }
}
