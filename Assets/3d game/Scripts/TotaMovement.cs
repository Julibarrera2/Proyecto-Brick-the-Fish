using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotaMovement : MonoBehaviour
{
    public Animator anim;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Jump");
        }
    }
        
}   