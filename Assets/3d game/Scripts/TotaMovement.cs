using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotaMovement : MonoBehaviour
{
    public Animator anim;
    public float velRotacion;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetBool("walking", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("walking", false);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetBool("walking", true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetBool("walking", false);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetBool("walking", true);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetBool("walking", false);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetBool("walking", true);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetBool("walking", false);
        }
    }
        
}