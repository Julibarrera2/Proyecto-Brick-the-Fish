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
            anim.SetBool("camina", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("camina", false);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetBool("retrocede", true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetBool("retrocede", false);
        }


        if (!anim.GetBool("camina") && !anim.GetBool("retrocede"))
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                anim.SetBool("giraIzq", true);
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                anim.SetBool("giraIzq", false);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                anim.SetBool("giraDer", true);
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                anim.SetBool("giraDer", false);
            }
        }
        else
        {
            anim.SetBool("giraDer", false);
            anim.SetBool("giraIzq", false);
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0, velRotacion, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0, -velRotacion, 0);
            }
        }


    }
}