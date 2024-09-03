using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float turnSpeed = 10;
    public float movespeed = 3f;
    void Start()
    {

    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput);
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * movespeed);

        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * movespeed);

        transform.Rotate(Vector3.up * horizontalInput * turnSpeed * Time.deltaTime);

    }
}
