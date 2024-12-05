using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField] private AudioClip jumpSound, walkSound, throwSound, finishSound, rechargeSound, habilitiesSound;

    public CharacterController controller;
    public Animator anim;
    public Transform cam;

    public float speed = 6;
    public float gravity = -9.81f;
    public float jumpHeight = 3;
    Vector3 velocity;
    bool isGrounded;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public GameObject brick;
    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;
    float shotTime = 0f;
    float stepTime = 0f;
    public float stepTiemLenth;
    bool doThrow;

    // Update is called once per frame
    void Update()
    {
        shotTime -= Time.deltaTime;
        stepTime -= Time.deltaTime;
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            anim.SetTrigger("Jump");
            AudioManager.Instance.PlaySound(jumpSound);
        }
        if (doThrow && !anim.GetCurrentAnimatorStateInfo(0).IsName("Throw"))
        {
            Instantiate(brick, transform.position + new Vector3(-1.5f, 7, 0), Quaternion.identity).GetComponent<Rigidbody>().AddForce(transform.forward * 500, ForceMode.Impulse);
            doThrow = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            //throw
            if (shotTime <= 0)
            {
                anim.SetTrigger("Throw");
                doThrow = true;
                shotTime = 1;
                AudioManager.Instance.PlaySound(throwSound);
            }

        }
        //gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        //walk
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        anim.SetFloat("Speed", direction.magnitude);

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);

            if (stepTime <= 0)
            {
                stepTime = stepTiemLenth;
                AudioManager.Instance.PlaySound(walkSound);
            }
        }
    } 
}